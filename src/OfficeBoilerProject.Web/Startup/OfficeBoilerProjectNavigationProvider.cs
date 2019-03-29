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
                        "Office",
                        L("Office"),
                        url: "Office",
                        icon: "fa fa-tasks"
                        )
                        .AddItem(new MenuItemDefinition(
                            "Office",
                            L("Add Office"),
                            url: "Office/Add",
                            icon: "fa fa-tasks"))
                        .AddItem(new MenuItemDefinition(
                            "Office",
                            L("All Offices"),
                            url: "Office",
                            icon: "fa fa-tasks"))
                        .AddItem(new MenuItemDefinition(
                            "Office",
                            L("Delete Office"),
                            url: "Office/Delete",
                            icon: "fa fa-tasks"))
                        .AddItem(new MenuItemDefinition(
                            "Office",
                            L("Find Office"),
                            url: "Office/Office",
                            icon: "fa fa-tasks"))
                        .AddItem(new MenuItemDefinition(
                            "Office",
                            L("Update Office"),
                            url: "Office/Update",
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
                            L("Find Person"),
                            url: "Person/Person",
                            icon: "fa fa-tasks"))
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
                        .AddItem(new MenuItemDefinition(
                            "Person",
                            L("Delete Person"),
                            url: "Person/Delete",
                            icon: "fa fa-tasks"))
                        .AddItem(new MenuItemDefinition(
                            "Person",
                            L("Update Person"),
                            url: "Person/Update",
                            icon: "fa fa-tasks"))
                    ).AddItem(
                    new MenuItemDefinition(
                        "Device",
                        L("Device"),
                        url: "Device",
                        icon: "fa fa-tasks"
                    )
                    );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, OfficeBoilerProjectConsts.LocalizationSourceName);
        }
    }
}
