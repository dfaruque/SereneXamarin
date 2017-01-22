
namespace SereneXamarin.Navigation
{
    using SereneXamarin.Administration.Entities;
    using Serenity;
    using Serenity.Navigation;
    using System;
    using System.Collections.Generic;
    using System.Web;

    public partial class NavigationModel
    {
        public List<NavigationItem> Items { get; private set; }
        public int[] ActivePath { get; set; }

        public NavigationModel()
        {
            Items = new List<NavigationItem>();

            Items.Add(new NavigationItem { FullPath = "Dashboard", Url = "~/", IconClass = "icon-speedometer" });
            Items.Add(new NavigationItem { FullPath = "Administration", IconClass = "icon-screen-desktop", });
            Items.Add(new NavigationItem { FullPath = "Administration/Languages", Url= "#Administration/Language", IconClass = "icon-bubbles", });
            Items.Add(new NavigationItem { FullPath = "Administration/Translations", Url= "#Administration/Translations", IconClass = "icon-speech", });
            Items.Add(new NavigationItem { FullPath = "Administration/Role", Url= "#Administration/Role", IconClass = "icon-lock", });
            Items.Add(new NavigationItem { FullPath = "Administration/User Management", Url= "#Administration/User", IconClass = "icon-people", });

            //[assembly: NavigationLink(1000, "Dashboard", url: "~/", permission: "", icon: "icon-speedometer")]

            //[assembly: NavigationMenu(9000, "Administration", icon: "icon-screen-desktop")]
            //[assembly: NavigationLink(9000, "Administration/Exceptions Log", url: "~/errorlog.axd", permission: SereneXamarin.Administration.PermissionKeys.Security, icon: "icon-ban", Target = "_blank")]
            //[assembly: NavigationLink(9000, "Administration/Languages", "#Administration/Language", PermissionKeys.Translation, icon: "icon-bubbles")]
            //[assembly: NavigationLink(9000, "Administration/Translations", "#Administration/Translation", PermissionKeys.Translation, icon: "icon-speech")]
            //[assembly: NavigationLink(9000, "Administration/Roles", "#Administration/Role", PermissionKeys.Security, icon: "icon-lock")]
            //[assembly: NavigationLink(9000, "Administration/User Management", "#Administration/User", PermissionKeys.Security, icon: "icon-people")]
        }

    }
}