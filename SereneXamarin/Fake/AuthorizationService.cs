namespace SereneXamarin.Mobile.Fake
{
    using Serenity.Abstractions;

    public class AuthorizationService : IAuthorizationService
    {
        public bool IsLoggedIn
        {
            get { return true; }
        }

        public string Username
        {
            get { return "FakeUser"; }
        }
    }
}