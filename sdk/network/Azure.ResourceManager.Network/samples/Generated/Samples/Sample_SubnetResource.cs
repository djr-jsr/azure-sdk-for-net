// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Samples
{
    public partial class Sample_SubnetResource
    {
        // Delete subnet
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_DeleteSubnet()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/SubnetDelete.json
            // this example is just showing the usage of "Subnets_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subid";
            string resourceGroupName = "subnet-test";
            string virtualNetworkName = "vnetname";
            string subnetName = "subnet1";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation
            await subnet.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }

        // Get subnet
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_GetSubnet()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/SubnetGet.json
            // this example is just showing the usage of "Subnets_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subid";
            string resourceGroupName = "subnet-test";
            string virtualNetworkName = "vnetname";
            string subnetName = "subnet1";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation
            SubnetResource result = await subnet.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            SubnetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Get subnet with a delegation
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_GetSubnetWithADelegation()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/SubnetGetWithDelegation.json
            // this example is just showing the usage of "Subnets_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subId";
            string resourceGroupName = "subnet-test";
            string virtualNetworkName = "vnetname";
            string subnetName = "subnet1";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation
            SubnetResource result = await subnet.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            SubnetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Create subnet
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_CreateSubnet()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/SubnetCreate.json
            // this example is just showing the usage of "Subnets_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subid";
            string resourceGroupName = "subnet-test";
            string virtualNetworkName = "vnetname";
            string subnetName = "subnet1";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation
            SubnetData data = new SubnetData()
            {
                AddressPrefix = "10.0.0.0/16",
            };
            ArmOperation<SubnetResource> lro = await subnet.UpdateAsync(WaitUntil.Completed, data);
            SubnetResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            SubnetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Create subnet with a delegation
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_CreateSubnetWithADelegation()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/SubnetCreateWithDelegation.json
            // this example is just showing the usage of "Subnets_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subId";
            string resourceGroupName = "subnet-test";
            string virtualNetworkName = "vnetname";
            string subnetName = "subnet1";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation
            SubnetData data = new SubnetData()
            {
                AddressPrefix = "10.0.0.0/16",
            };
            ArmOperation<SubnetResource> lro = await subnet.UpdateAsync(WaitUntil.Completed, data);
            SubnetResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            SubnetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Create subnet with service endpoints
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_CreateSubnetWithServiceEndpoints()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/SubnetCreateServiceEndpoint.json
            // this example is just showing the usage of "Subnets_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subid";
            string resourceGroupName = "subnet-test";
            string virtualNetworkName = "vnetname";
            string subnetName = "subnet1";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation
            SubnetData data = new SubnetData()
            {
                AddressPrefix = "10.0.0.0/16",
                ServiceEndpoints =
{
new ServiceEndpointProperties()
{
Service = "Microsoft.Storage",
}
},
            };
            ArmOperation<SubnetResource> lro = await subnet.UpdateAsync(WaitUntil.Completed, data);
            SubnetResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            SubnetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Prepare Network Policies
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task PrepareNetworkPolicies_PrepareNetworkPolicies()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/SubnetPrepareNetworkPolicies.json
            // this example is just showing the usage of "Subnets_PrepareNetworkPolicies" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string virtualNetworkName = "test-vnet";
            string subnetName = "subnet1";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation
            PrepareNetworkPoliciesContent content = new PrepareNetworkPoliciesContent()
            {
                ServiceName = "Microsoft.Sql/managedInstances",
            };
            await subnet.PrepareNetworkPoliciesAsync(WaitUntil.Completed, content);

            Console.WriteLine($"Succeeded");
        }

        // Unprepare Network Policies
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task UnprepareNetworkPolicies_UnprepareNetworkPolicies()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/SubnetUnprepareNetworkPolicies.json
            // this example is just showing the usage of "Subnets_UnprepareNetworkPolicies" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string virtualNetworkName = "test-vnet";
            string subnetName = "subnet1";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation
            UnprepareNetworkPoliciesContent content = new UnprepareNetworkPoliciesContent()
            {
                ServiceName = "Microsoft.Sql/managedInstances",
            };
            await subnet.UnprepareNetworkPoliciesAsync(WaitUntil.Completed, content);

            Console.WriteLine($"Succeeded");
        }

        // Get Resource Navigation Links
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetResourceNavigationLinks_GetResourceNavigationLinks()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VirtualNetworkGetResourceNavigationLinks.json
            // this example is just showing the usage of "ResourceNavigationLinks_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string virtualNetworkName = "vnet";
            string subnetName = "subnet";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation and iterate over the result
            await foreach (ResourceNavigationLink item in subnet.GetResourceNavigationLinksAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Get Service Association Links
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetServiceAssociationLinks_GetServiceAssociationLinks()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VirtualNetworkGetServiceAssociationLinks.json
            // this example is just showing the usage of "ServiceAssociationLinks_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubnetResource created on azure
            // for more information of creating SubnetResource, please refer to the document of SubnetResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string virtualNetworkName = "vnet";
            string subnetName = "subnet";
            ResourceIdentifier subnetResourceId = SubnetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualNetworkName, subnetName);
            SubnetResource subnet = client.GetSubnetResource(subnetResourceId);

            // invoke the operation and iterate over the result
            await foreach (ServiceAssociationLink item in subnet.GetServiceAssociationLinksAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
