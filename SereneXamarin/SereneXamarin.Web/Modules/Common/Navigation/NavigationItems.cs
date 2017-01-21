using SereneXamarin.Administration;
using Serenity.Navigation;
using Administration = SereneXamarin.Administration.Pages;

[assembly: NavigationLink(1000, "Dashboard", url: "~/", permission: "", icon: "icon-speedometer")]

[assembly: NavigationMenu(9000, "Administration", icon: "icon-screen-desktop")]
[assembly: NavigationLink(9000, "Administration/Exceptions Log", url: "~/errorlog.axd", permission: SereneXamarin.Administration.PermissionKeys.Security, icon: "icon-ban", Target = "_blank")]
[assembly: NavigationLink(9000, "Administration/Languages", "#Administration/Language", PermissionKeys.Translation, icon: "icon-bubbles")]
[assembly: NavigationLink(9000, "Administration/Translations", "#Administration/Translation", PermissionKeys.Translation, icon: "icon-speech")]
[assembly: NavigationLink(9000, "Administration/Roles", "#Administration/Role", PermissionKeys.Security, icon: "icon-lock")]
[assembly: NavigationLink(9000, "Administration/User Management", "#Administration/User", PermissionKeys.Security, icon: "icon-people")]