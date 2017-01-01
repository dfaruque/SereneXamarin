namespace SereneXamarin.Administration
{
    using Serenity;
    using Serenity.Abstractions;
    using Serenity.Data;
    using System;
    using System.Data;

    public class UserRetrieveService : IUserRetrieveService
    {

        public IUserDefinition ById(string id)
        {
            return new UserDefinition{ UserId = 1, DisplayName= "Fake User", Username="fakeUser", IsActive = 1 };
        }

        public IUserDefinition ByUsername(string username)
        {
            return new UserDefinition { UserId = 1, DisplayName = "Fake User", Username = "fakeUser", IsActive = 1 };

        }
    }
}