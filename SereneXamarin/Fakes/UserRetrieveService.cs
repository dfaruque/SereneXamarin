namespace SereneXamarin.Mobile.Fake
{
    using Serenity;
    using Serenity.Abstractions;

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