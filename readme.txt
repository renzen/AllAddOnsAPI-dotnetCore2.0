1. Firts thing to do Open cmd and crate directory: mkdir AllAddOnsAPI
2. cd AllAddOnsAPI
3. run command dotnet new webapi
4. open the visual code and open the AllAddOnsAPI folder
5. Create folder model inside model folder create a model.cs
6. inside model folder create a BaseEntity.cs and AllAddOnContext.cs
7. in startup.cs configure setting add db context
8. in appsetting.json add connection string in database
9. in .csproj file add package what ever version of your .net core sdk
10. Now you can run the migration like this dotnet ef migrations add InitialCreate
11. and the run dotnet ef database update
12. in Controller folder add file AddOnController.cs the code inside it for post, get, put and delete then route it.
13. and test it in postman.


Citrix
t-rbflorendo
157850_PLDT



{
    "addOnName": "Home Boost 15",
    "price": 15,
    "promoDescription": "Enjoy 1GB of data, valid for 1 day.",
    "groupId": 573,
    "isPromoRecurring": "true",
    "recurringPromoId": "NA",
    "spiel": "",
    "id": 3,
    "createdAt": "2018-11-23T14:38:22.2148223",
    "updatedAt": null
}

http://pldtiwsdev02:8001/PLDTServiceBridge/Modules/CSP/DashboardService.svc/rest/InquireWallets/10247402586/1/GSM/S000000HOME/myHome 
 

http://pldtiwsdev02:8001/PLDTServiceBridge/Modules/CSP/DashboardService.svc/rest/InquireWallets/10247335722/1/GSM/S000000HOME/myHome 
 
