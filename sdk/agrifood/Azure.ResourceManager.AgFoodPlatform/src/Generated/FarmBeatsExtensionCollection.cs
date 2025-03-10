// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AgFoodPlatform
{
    /// <summary>
    /// A class representing a collection of <see cref="FarmBeatsExtensionResource" /> and their operations.
    /// Each <see cref="FarmBeatsExtensionResource" /> in the collection will belong to the same instance of <see cref="TenantResource" />.
    /// To get a <see cref="FarmBeatsExtensionCollection" /> instance call the GetFarmBeatsExtensions method from an instance of <see cref="TenantResource" />.
    /// </summary>
    public partial class FarmBeatsExtensionCollection : ArmCollection, IEnumerable<FarmBeatsExtensionResource>, IAsyncEnumerable<FarmBeatsExtensionResource>
    {
        private readonly ClientDiagnostics _farmBeatsExtensionClientDiagnostics;
        private readonly FarmBeatsExtensionsRestOperations _farmBeatsExtensionRestClient;

        /// <summary> Initializes a new instance of the <see cref="FarmBeatsExtensionCollection"/> class for mocking. </summary>
        protected FarmBeatsExtensionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FarmBeatsExtensionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FarmBeatsExtensionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _farmBeatsExtensionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AgFoodPlatform", FarmBeatsExtensionResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FarmBeatsExtensionResource.ResourceType, out string farmBeatsExtensionApiVersion);
            _farmBeatsExtensionRestClient = new FarmBeatsExtensionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, farmBeatsExtensionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get farmBeats extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AgFoodPlatform/farmBeatsExtensionDefinitions/{farmBeatsExtensionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FarmBeatsExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="farmBeatsExtensionId"> farmBeatsExtensionId to be queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="farmBeatsExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="farmBeatsExtensionId"/> is null. </exception>
        public virtual async Task<Response<FarmBeatsExtensionResource>> GetAsync(string farmBeatsExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(farmBeatsExtensionId, nameof(farmBeatsExtensionId));

            using var scope = _farmBeatsExtensionClientDiagnostics.CreateScope("FarmBeatsExtensionCollection.Get");
            scope.Start();
            try
            {
                var response = await _farmBeatsExtensionRestClient.GetAsync(farmBeatsExtensionId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FarmBeatsExtensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get farmBeats extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AgFoodPlatform/farmBeatsExtensionDefinitions/{farmBeatsExtensionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FarmBeatsExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="farmBeatsExtensionId"> farmBeatsExtensionId to be queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="farmBeatsExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="farmBeatsExtensionId"/> is null. </exception>
        public virtual Response<FarmBeatsExtensionResource> Get(string farmBeatsExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(farmBeatsExtensionId, nameof(farmBeatsExtensionId));

            using var scope = _farmBeatsExtensionClientDiagnostics.CreateScope("FarmBeatsExtensionCollection.Get");
            scope.Start();
            try
            {
                var response = _farmBeatsExtensionRestClient.Get(farmBeatsExtensionId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FarmBeatsExtensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get list of farmBeats extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AgFoodPlatform/farmBeatsExtensionDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FarmBeatsExtensions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="farmBeatsExtensionIds"> FarmBeatsExtension ids. </param>
        /// <param name="farmBeatsExtensionNames"> FarmBeats extension names. </param>
        /// <param name="extensionCategories"> Extension categories. </param>
        /// <param name="publisherIds"> Publisher ids. </param>
        /// <param name="maxPageSize">
        /// Maximum number of items needed (inclusive).
        /// Minimum = 10, Maximum = 1000, Default value = 50.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FarmBeatsExtensionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FarmBeatsExtensionResource> GetAllAsync(IEnumerable<string> farmBeatsExtensionIds = null, IEnumerable<string> farmBeatsExtensionNames = null, IEnumerable<string> extensionCategories = null, IEnumerable<string> publisherIds = null, int? maxPageSize = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _farmBeatsExtensionRestClient.CreateListRequest(farmBeatsExtensionIds, farmBeatsExtensionNames, extensionCategories, publisherIds, pageSizeHint);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _farmBeatsExtensionRestClient.CreateListNextPageRequest(nextLink, farmBeatsExtensionIds, farmBeatsExtensionNames, extensionCategories, publisherIds, pageSizeHint);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FarmBeatsExtensionResource(Client, FarmBeatsExtensionData.DeserializeFarmBeatsExtensionData(e)), _farmBeatsExtensionClientDiagnostics, Pipeline, "FarmBeatsExtensionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get list of farmBeats extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AgFoodPlatform/farmBeatsExtensionDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FarmBeatsExtensions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="farmBeatsExtensionIds"> FarmBeatsExtension ids. </param>
        /// <param name="farmBeatsExtensionNames"> FarmBeats extension names. </param>
        /// <param name="extensionCategories"> Extension categories. </param>
        /// <param name="publisherIds"> Publisher ids. </param>
        /// <param name="maxPageSize">
        /// Maximum number of items needed (inclusive).
        /// Minimum = 10, Maximum = 1000, Default value = 50.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FarmBeatsExtensionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FarmBeatsExtensionResource> GetAll(IEnumerable<string> farmBeatsExtensionIds = null, IEnumerable<string> farmBeatsExtensionNames = null, IEnumerable<string> extensionCategories = null, IEnumerable<string> publisherIds = null, int? maxPageSize = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _farmBeatsExtensionRestClient.CreateListRequest(farmBeatsExtensionIds, farmBeatsExtensionNames, extensionCategories, publisherIds, pageSizeHint);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _farmBeatsExtensionRestClient.CreateListNextPageRequest(nextLink, farmBeatsExtensionIds, farmBeatsExtensionNames, extensionCategories, publisherIds, pageSizeHint);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FarmBeatsExtensionResource(Client, FarmBeatsExtensionData.DeserializeFarmBeatsExtensionData(e)), _farmBeatsExtensionClientDiagnostics, Pipeline, "FarmBeatsExtensionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AgFoodPlatform/farmBeatsExtensionDefinitions/{farmBeatsExtensionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FarmBeatsExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="farmBeatsExtensionId"> farmBeatsExtensionId to be queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="farmBeatsExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="farmBeatsExtensionId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string farmBeatsExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(farmBeatsExtensionId, nameof(farmBeatsExtensionId));

            using var scope = _farmBeatsExtensionClientDiagnostics.CreateScope("FarmBeatsExtensionCollection.Exists");
            scope.Start();
            try
            {
                var response = await _farmBeatsExtensionRestClient.GetAsync(farmBeatsExtensionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AgFoodPlatform/farmBeatsExtensionDefinitions/{farmBeatsExtensionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FarmBeatsExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="farmBeatsExtensionId"> farmBeatsExtensionId to be queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="farmBeatsExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="farmBeatsExtensionId"/> is null. </exception>
        public virtual Response<bool> Exists(string farmBeatsExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(farmBeatsExtensionId, nameof(farmBeatsExtensionId));

            using var scope = _farmBeatsExtensionClientDiagnostics.CreateScope("FarmBeatsExtensionCollection.Exists");
            scope.Start();
            try
            {
                var response = _farmBeatsExtensionRestClient.Get(farmBeatsExtensionId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AgFoodPlatform/farmBeatsExtensionDefinitions/{farmBeatsExtensionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FarmBeatsExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="farmBeatsExtensionId"> farmBeatsExtensionId to be queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="farmBeatsExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="farmBeatsExtensionId"/> is null. </exception>
        public virtual async Task<NullableResponse<FarmBeatsExtensionResource>> GetIfExistsAsync(string farmBeatsExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(farmBeatsExtensionId, nameof(farmBeatsExtensionId));

            using var scope = _farmBeatsExtensionClientDiagnostics.CreateScope("FarmBeatsExtensionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _farmBeatsExtensionRestClient.GetAsync(farmBeatsExtensionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<FarmBeatsExtensionResource>(response.GetRawResponse());
                return Response.FromValue(new FarmBeatsExtensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AgFoodPlatform/farmBeatsExtensionDefinitions/{farmBeatsExtensionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FarmBeatsExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="farmBeatsExtensionId"> farmBeatsExtensionId to be queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="farmBeatsExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="farmBeatsExtensionId"/> is null. </exception>
        public virtual NullableResponse<FarmBeatsExtensionResource> GetIfExists(string farmBeatsExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(farmBeatsExtensionId, nameof(farmBeatsExtensionId));

            using var scope = _farmBeatsExtensionClientDiagnostics.CreateScope("FarmBeatsExtensionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _farmBeatsExtensionRestClient.Get(farmBeatsExtensionId, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<FarmBeatsExtensionResource>(response.GetRawResponse());
                return Response.FromValue(new FarmBeatsExtensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FarmBeatsExtensionResource> IEnumerable<FarmBeatsExtensionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FarmBeatsExtensionResource> IAsyncEnumerable<FarmBeatsExtensionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
