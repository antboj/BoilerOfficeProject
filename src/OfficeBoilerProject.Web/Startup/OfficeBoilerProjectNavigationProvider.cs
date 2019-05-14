using Abp.Application.Navigation;
using Abp.Localization;

namespace OfficeBoilerProject.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class OfficeBoilerProjectNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "Home/About",
                        icon: "fa fa-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Login",
                        L("Login"),
                        url: "Home/Login",
                        icon: "fa fa-info"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Logout",
                        L("Logout"),
                        url: "Home/Logout",
                        icon: "fa fa-info",
                        requiresAuthentication:true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Office",
                        L("Office"),
                        url: "Office",
                        icon: "fa fa-tasks"
                        )
                        .AddItem(new MenuItemDefinition(
                            "Office",
                            L("Add New Office"),
                            url: "Office/Add",
                            icon: "fa fa-tasks"))
                        .AddItem(new MenuItemDefinition(
                            "Office",
                            L("All Offices"),
                            url: "Office",
                            icon: "fa fa-tasks"))
                ).AddItem(
                    new MenuItemDefinition(
                        "Person",
                        L("Person"),
                        url: "Person",
                        icon: "fa fa-tasks"
                        )
                        .AddItem(new MenuItemDefinition(
                            "Person",
                            L("Add New Person"),
                            url: "Person/Add",
                            icon: "fa fa-tasks"))
                        .AddItem(new MenuItemDefinition(
                            "Person",
                            L("All Persons"),
                            url: "Person",
                            icon: "fa fa-tasks"))
                    ).AddItem(
                    new MenuItemDefinition(
                        "Device",
                        L("Device"),
                        url: "Device",
                        icon: "fa fa-tasks"
                    )
                        .AddItem(new MenuItemDefinition(
                            "Device",
                            L("Add New Device"),
                            url: "Device/Add",
                            icon: "fa fa-tasks"))
                        .AddItem(new MenuItemDefinition(
                            "Person",
                            L("All Devices"),
                            url: "Device",
                            icon: "fa fa-tasks"))
                    );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, OfficeBoilerProjectConsts.LocalizationSourceName);
        }
    }
}
