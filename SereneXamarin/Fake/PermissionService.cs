namespace SereneXamarin.Administration
{
    using SereneXamarin.Administration.Entities;
    using Serenity;
    using Serenity.Abstractions;
    using Serenity.Data;
    using System;
    using System.Collections.Generic;

    public class PermissionService : IPermissionService
    {
        public bool HasPermission(string permission)
        {
            return true;
        }
    }
}