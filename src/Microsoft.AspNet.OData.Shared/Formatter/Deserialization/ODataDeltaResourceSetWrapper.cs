// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.OData;

namespace Microsoft.AspNet.OData.Formatter.Deserialization
{
    /// <summary>
    /// Encapsulates an <see cref="ODataResourceSet"/> and the <see cref="ODataResource"/>'s that are part of it.
    /// </summary>
    public sealed class ODataDeltaResourceSetWrapper : ODataItemBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ODataResourceSetWrapper"/>.
        /// </summary>
        /// <param name="item">The wrapped item.</param>
        public ODataDeltaResourceSetWrapper(ODataDeltaResourceSet item)
            : base(item)
        {
            Resources = new List<ODataResourceWrapper>();
            DeletedResources = new List<ODataDeletedResourceWrapper>();
        }

        /// <summary>
        /// Gets the wrapped <see cref="ODataResourceSet"/>.
        /// </summary>
        public ODataResourceSet ResourceSet
        {
            get
            {
                return Item as ODataResourceSet;
            }
        }

        /// <summary>
        /// Gets the nested resources of this DeltaResourceSet.
        /// </summary>
        public IList<ODataResourceWrapper> Resources { get; private set; }

        /// <summary>
        /// Gets the deleted resources of this DeltaResourceSet.
        /// </summary>
        public IList<ODataDeletedResourceWrapper> DeletedResources { get; private set; }
    }
}
