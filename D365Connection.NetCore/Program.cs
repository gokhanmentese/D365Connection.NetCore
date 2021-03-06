using CrmService.CrmHelper;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.PowerPlatform.Dataverse.Client;
using System;

namespace D365Connection.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var crmServiceSingleton = CrmServiceSingleton.GetService();
            ServiceClient crmService = crmServiceSingleton.OrganizationService;

            if (crmService == null)
                System.Console.WriteLine("No Connected to Organization Service!");

            WhoAmIRequest request = new WhoAmIRequest();
            WhoAmIResponse response = (WhoAmIResponse)
            crmService.Execute(request);

            var userId = response.UserId;
        }
    }
}
