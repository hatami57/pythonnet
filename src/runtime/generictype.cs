// ==========================================================================
// This software is subject to the provisions of the Zope Public License,
// Version 2.0 (ZPL).  A copy of the ZPL should accompany this distribution.
// THIS SOFTWARE IS PROVIDED "AS IS" AND ANY AND ALL EXPRESS OR IMPLIED
// WARRANTIES ARE DISCLAIMED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF TITLE, MERCHANTABILITY, AGAINST INFRINGEMENT, AND FITNESS
// FOR A PARTICULAR PURPOSE.
// ==========================================================================

using System;
using System.Reflection;

namespace Python.Runtime {

    /// <summary>
    /// Implements reflected generic types. Note that the Python behavior
    /// is the same for both generic type definitions and constructed open
    /// generic types. Both are essentially factories for creating closed
    /// types based on the required generic type parameters.
    /// </summary>

    internal class GenericType : ClassBase {

        internal GenericType(Type tp) : base(tp) {}

        //====================================================================
        // Implements __new__ for reflected generic types.
        //====================================================================

        public static IntPtr tp_new(IntPtr tp, IntPtr args, IntPtr kw) {
            Exceptions.SetError(Exceptions.TypeError, 
                               "cannot instantiate an open generic type"
                               );
            return IntPtr.Zero;
        }


        //====================================================================
        // Implements __call__ for reflected generic types.
        //====================================================================

        public static IntPtr tp_call(IntPtr ob, IntPtr args, IntPtr kw) {
            Exceptions.SetError(Exceptions.TypeError, 
                                "object is not callable");
            return IntPtr.Zero;
        }
    }

}