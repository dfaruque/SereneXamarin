namespace SereneXamarin.Administration
{
    using Entities;
    using Repositories;
    using Serenity;
    using Serenity.Abstractions;
    using Serenity.Data;
    using System;

    public class AuthenticationService : IAuthenticationService
    {
        public bool Validate(ref string username, string password)
        {
            return true;
        }
    }
}