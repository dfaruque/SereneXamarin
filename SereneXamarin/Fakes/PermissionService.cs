namespace SereneXamarin.Mobile.Fake
{
    using Serenity.Abstractions;

    public class PermissionService : IPermissionService
    {
        public bool HasPermission(string permission)
        {
            return true;
        }
    }
}