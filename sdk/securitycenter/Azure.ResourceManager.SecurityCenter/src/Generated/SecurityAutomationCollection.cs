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

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary>
    /// A class representing a collection of <see cref="SecurityAutomationResource" /> and their operations.
    /// Each <see cref="SecurityAutomationResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="SecurityAutomationCollection" /> instance call the GetSecurityAutomations method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class SecurityAutomationCollection : ArmCollection, IEnumerable<SecurityAutomationResource>, IAsyncEnumerable<SecurityAutomationResource>
    {
        private readonly ClientDiagnostics _securityAutomationAutomationsClientDiagnostics;
        private readonly AutomationsRestOperations _securityAutomationAutomationsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SecurityAutomationCollection"/> class for mocking. </summary>
        protected SecurityAutomationCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityAutomationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SecurityAutomationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityAutomationAutomationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", SecurityAutomationResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SecurityAutomationResource.ResourceType, out string securityAutomationAutomationsApiVersion);
            _securityAutomationAutomationsRestClient = new AutomationsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityAutomationAutomationsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a security automation. If a security automation is already created and a subsequent request is issued for the same automation id, then it will be updated.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations/{automationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="automationName"> The security automation name. </param>
        /// <param name="data"> The security automation resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityAutomationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string automationName, SecurityAutomationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationName, nameof(automationName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityAutomationAutomationsClientDiagnostics.CreateScope("SecurityAutomationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _securityAutomationAutomationsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, automationName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityCenterArmOperation<SecurityAutomationResource>(Response.FromValue(new SecurityAutomationResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a security automation. If a security automation is already created and a subsequent request is issued for the same automation id, then it will be updated.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations/{automationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="automationName"> The security automation name. </param>
        /// <param name="data"> The security automation resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityAutomationResource> CreateOrUpdate(WaitUntil waitUntil, string automationName, SecurityAutomationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationName, nameof(automationName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityAutomationAutomationsClientDiagnostics.CreateScope("SecurityAutomationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _securityAutomationAutomationsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, automationName, data, cancellationToken);
                var operation = new SecurityCenterArmOperation<SecurityAutomationResource>(Response.FromValue(new SecurityAutomationResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about the model of a security automation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations/{automationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationName"> The security automation name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationName"/> is null. </exception>
        public virtual async Task<Response<SecurityAutomationResource>> GetAsync(string automationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationName, nameof(automationName));

            using var scope = _securityAutomationAutomationsClientDiagnostics.CreateScope("SecurityAutomationCollection.Get");
            scope.Start();
            try
            {
                var response = await _securityAutomationAutomationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, automationName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityAutomationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about the model of a security automation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations/{automationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationName"> The security automation name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationName"/> is null. </exception>
        public virtual Response<SecurityAutomationResource> Get(string automationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationName, nameof(automationName));

            using var scope = _securityAutomationAutomationsClientDiagnostics.CreateScope("SecurityAutomationCollection.Get");
            scope.Start();
            try
            {
                var response = _securityAutomationAutomationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, automationName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityAutomationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all the security automations in the specified resource group. Use the 'nextLink' property in the response to get the next page of security automations for the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityAutomationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityAutomationResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _securityAutomationAutomationsRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _securityAutomationAutomationsRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SecurityAutomationResource(Client, SecurityAutomationData.DeserializeSecurityAutomationData(e)), _securityAutomationAutomationsClientDiagnostics, Pipeline, "SecurityAutomationCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all the security automations in the specified resource group. Use the 'nextLink' property in the response to get the next page of security automations for the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityAutomationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityAutomationResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _securityAutomationAutomationsRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _securityAutomationAutomationsRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SecurityAutomationResource(Client, SecurityAutomationData.DeserializeSecurityAutomationData(e)), _securityAutomationAutomationsClientDiagnostics, Pipeline, "SecurityAutomationCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations/{automationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationName"> The security automation name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string automationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationName, nameof(automationName));

            using var scope = _securityAutomationAutomationsClientDiagnostics.CreateScope("SecurityAutomationCollection.Exists");
            scope.Start();
            try
            {
                var response = await _securityAutomationAutomationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, automationName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations/{automationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationName"> The security automation name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationName"/> is null. </exception>
        public virtual Response<bool> Exists(string automationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationName, nameof(automationName));

            using var scope = _securityAutomationAutomationsClientDiagnostics.CreateScope("SecurityAutomationCollection.Exists");
            scope.Start();
            try
            {
                var response = _securityAutomationAutomationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, automationName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations/{automationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationName"> The security automation name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationName"/> is null. </exception>
        public virtual async Task<NullableResponse<SecurityAutomationResource>> GetIfExistsAsync(string automationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationName, nameof(automationName));

            using var scope = _securityAutomationAutomationsClientDiagnostics.CreateScope("SecurityAutomationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _securityAutomationAutomationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, automationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<SecurityAutomationResource>(response.GetRawResponse());
                return Response.FromValue(new SecurityAutomationResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations/{automationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Automations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="automationName"> The security automation name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationName"/> is null. </exception>
        public virtual NullableResponse<SecurityAutomationResource> GetIfExists(string automationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(automationName, nameof(automationName));

            using var scope = _securityAutomationAutomationsClientDiagnostics.CreateScope("SecurityAutomationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _securityAutomationAutomationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, automationName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<SecurityAutomationResource>(response.GetRawResponse());
                return Response.FromValue(new SecurityAutomationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SecurityAutomationResource> IEnumerable<SecurityAutomationResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SecurityAutomationResource> IAsyncEnumerable<SecurityAutomationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
