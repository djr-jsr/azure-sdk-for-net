// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    /// <summary> File source details. </summary>
    public partial class EdgeFileSourceInfo
    {
        /// <summary> Initializes a new instance of EdgeFileSourceInfo. </summary>
        /// <param name="shareId"> File share ID. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareId"/> is null. </exception>
        public EdgeFileSourceInfo(ResourceIdentifier shareId)
        {
            Argument.AssertNotNull(shareId, nameof(shareId));

            ShareId = shareId;
        }

        /// <summary> File share ID. </summary>
        public ResourceIdentifier ShareId { get; set; }
    }
}
