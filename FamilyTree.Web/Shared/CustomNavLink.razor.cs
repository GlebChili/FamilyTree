using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace FamilyTree.Web.Shared
{
    public partial class CustomNavLink
    {
        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public NavLinkMatch Match { get; set; }
    }
}
