// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using Microsoft.OData;

namespace Microsoft.AspNet.OData.Formatter.Deserialization
{
    /// <summary>
    /// Encapsulates an <see cref="ODataDeletedResource"/>.
    /// </summary>
    public sealed class ODataDeletedResourceWrapper : ODataItemBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ODataDeletedResourceWrapper"/>.
        /// </summary>
        /// <param name="item">The wrapped item.</param>
        public ODataDeletedResourceWrapper(ODataDeletedResource item)
            : base(item)
        {
        }

        /// <summary>
        /// Gets the wrapped <see cref="ODataDeletedResource"/>.
        /// </summary>
        public ODataDeletedResource Resource
        {
            get
            {
                return Item as ODataDeletedResource;
            }
        }
    }
}
