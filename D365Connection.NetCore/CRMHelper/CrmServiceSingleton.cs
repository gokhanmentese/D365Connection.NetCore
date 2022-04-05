using CrmService.AppSetting;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using System;

namespace CrmService.CrmHelper
{
    public class CrmServiceSingleton : IDisposable
    {
        private static CrmServiceSingleton _serviceInstance;
        private ServiceClient _organizationService;
        private Guid _controlID;
        private static object _lockObject = new object();

        public ServiceClient OrganizationService
        {
            get { return _organizationService; }
        }

        public Guid ControlID
        {
            get { return _controlID; }
        }

        private CrmServiceSingleton(Guid controlID)
        {
            _organizationService = GetCrmServiceAppUser();
            _controlID = controlID;
        }

        public static CrmServiceSingleton GetService()
        {
            try
            {
                if (_serviceInstance == null)
                {
                    lock (_lockObject)
                    {
                        if (_serviceInstance == null)
                            _serviceInstance = new CrmServiceSingleton(Guid.NewGuid());
                    }
                }

                return _serviceInstance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static ServiceClient GetCrmServiceAppUser()
        {
            try
            {
                var organizationUri = appKeys.GetOrganizationUri;
                var clientId = appKeys.GetClientId;
                var clientSecret = appKeys.GetClientSecret;

                var _CrmConnectionString = $@"AuthType=ClientSecret;url={organizationUri};ClientId={clientId};ClientSecret={clientSecret}";
                var crmConn = new ServiceClient(_CrmConnectionString);
             
                return crmConn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _organizationService = null;
            _serviceInstance = null;
        }
    }
}
