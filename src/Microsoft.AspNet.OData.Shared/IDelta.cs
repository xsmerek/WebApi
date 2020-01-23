// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.AspNet.OData
{
    /// <summary>
    /// <see cref="IDelta" /> allows and tracks changes to an object.
    /// </summary>
    public interface IDelta
    {
        /// <summary>
        /// Returns the Properties that have been modified through this IDelta as an
        /// enumerable of Property Names
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Not appropriate to be a property")]
        IEnumerable<string> GetChangedPropertyNames();

        /// <summary>
        /// Returns the Properties that have not been modified through this IDelta as an
        /// enumerable of Property Names
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Not appropriate to be a property")]
        IEnumerable<string> GetUnchangedPropertyNames();

        /// <summary>
        /// Attempts to set the Property called <paramref name="name"/> to the <paramref name="value"/> specified.
        /// </summary>
        /// <param name="name">The name of the Property</param>
        /// <param name="value">The new value of the Property</param>
        /// <returns>Returns <c>true</c> if successful and <c>false</c> if not.</returns>
        bool TrySetPropertyValue(string name, object value);

        /// <summary>
        /// Attempts to get the value of the Property called <paramref name="name"/> from the underlying Entity.
        /// </summary>
        /// <param name="name">The name of the Property</param>
        /// <param name="value">The value of the Property</param>
        /// <returns>Returns <c>true</c> if the Property was found and <c>false</c> if not.</returns>
        [SuppressMessage("Microsoft.Design", "CA1007:UseGenericsWhereAppropriate", Justification = "Generics not appropriate here")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Out param is appropriate here")]
        bool TryGetPropertyValue(string name, out object value);

        /// <summary>
        /// Attempts to set the collection of objects deleted from the navigation Property called <paramref name="name"/>.
        /// </summary>
        bool TrySetDeletedPropertyValue(string name, System.Collections.ICollection value);

        /// <summary>
        /// Attempts to get the collection of objects deleted from the navigation Property called <paramref name="name"/>.
        /// </summary>
        bool TryGetDeletedPropertyValue(string name, out System.Collections.ICollection value);

        /// <summary>
        /// Attempts to set the collection of delta objects that have been added or modified for the navigation Property called <paramref name="name"/>.
        /// </summary>
        bool TrySetPropertyCollectionValue(string name, System.Collections.ICollection value);

        /// <summary>
        /// Attempts to get the collection of delta objects that have been added or modified for the navigation Property called <paramref name="name"/>.
        /// </summary>
        bool TryGetPropertyCollectionValue(string name, out System.Collections.ICollection value);

        /// <summary>
        /// Attempts to set the delta object that corresponds to entity referenced by given navigation Property called <paramref name="name"/>.
        /// </summary>
        bool TrySetPropertyReferencedValue(string name, IDelta value);

        /// <summary>
        /// Attempts to get the delta object that corresponds to entity referenced by given navigation Property called <paramref name="name"/>.
        /// </summary>
        bool TryGetPropertyReferencedValue(string name, out IDelta value);

        /// <summary>
        /// Attempts to get the <see cref="Type"/> of the Property called <paramref name="name"/> from the underlying Entity.
        /// </summary>
        /// <param name="name">The name of the Property</param>
        /// <param name="type">The type of the Property</param>
        /// <returns>Returns <c>true</c> if the Property was found and <c>false</c> if not.</returns>
        bool TryGetPropertyType(string name, out Type type);

        /// <summary>
        /// Clears the <see cref="IDelta" />.
        /// </summary>
        void Clear();
    }
}
