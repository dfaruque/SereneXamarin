namespace SereneXamarin.Mobile.Fake
{
    using Serenity.Abstractions;

    public class AuthenticationService : IAuthenticationService
    {
        public bool Validate(ref string username, string password)
        {
            return true;
        }
    }
}