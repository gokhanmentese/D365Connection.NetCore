# D365Connection.NetCore

This code has been written with only intention to save developer's time while testing Dynamics 365 code which requires connection to CRM organization instances.

As part of initial setup Application User & Azure AD App is required if you don’t have it already please create application user. Once you have all the details, prepare connection string as shown below and use AuthType=ClientSecret here.

All the necessary packages should be installed, package Microsoft.PowerPlatform.Dataverse.Client in order to connect using ClientSecret.

![netcore2](https://user-images.githubusercontent.com/69807493/161758058-592bd683-1bae-408d-a305-87baadfb6d87.png)

![netcore1](https://user-images.githubusercontent.com/69807493/161758088-aa7b11c3-475a-48ed-ae4b-5b6abf9b3cb3.png)



