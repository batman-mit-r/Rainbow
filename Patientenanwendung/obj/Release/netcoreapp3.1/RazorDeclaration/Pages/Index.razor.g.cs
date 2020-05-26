#pragma checksum "D:\Patientenanwendung-end-feature\Patientenanwendung\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efb398ca4a06e9a030c8dd70df53027ab9d5b58e"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Patientenanwendung.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Patientenanwendung-end-feature\Patientenanwendung\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Patientenanwendung-end-feature\Patientenanwendung\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Patientenanwendung-end-feature\Patientenanwendung\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Patientenanwendung-end-feature\Patientenanwendung\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Patientenanwendung-end-feature\Patientenanwendung\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Patientenanwendung-end-feature\Patientenanwendung\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Patientenanwendung-end-feature\Patientenanwendung\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Patientenanwendung-end-feature\Patientenanwendung\_Imports.razor"
using Patientenanwendung;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Patientenanwendung-end-feature\Patientenanwendung\_Imports.razor"
using Patientenanwendung.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Patientenanwendung-end-feature\Patientenanwendung\Pages\Index.razor"
using Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 90 "D:\Patientenanwendung-end-feature\Patientenanwendung\Pages\Index.razor"
       

    private Boolean _Show_Schmerzlevel = false;
    private Boolean _Show_Nahrungsmittel = false;
    private Boolean _Show_Sonstiges = false;
    private String _Text_Nahrung = String.Empty;
    private String _Text_Sonstiges = String.Empty;

    private Bett bett = new Bett();

    private void CreateAnfrage(Bett bettennummer, DateTime dateTime, AnfrageArt anfrageArt, int schmerzlevel, String zusatz)
    {
        Anfrage anfrage = new Anfrage();
        anfrage.Bett = bettennummer;
        anfrage.DateTime = dateTime;
        anfrage.AnfrageArt = anfrageArt;
        anfrage.Schmerzlevel = schmerzlevel;
        anfrage.Zusatz = zusatz;

        AnfrageService.AddAnfrage(anfrage);
    }

    private void Toggle_Schmerz()
    {
        _Show_Schmerzlevel = true;
    }

    private void Toggle_Nahrungsmittel()
    {
        _Show_Nahrungsmittel = true;
    }

    private void Nahrungs_Anfrage()
    {
        CreateAnfrage(bett, DateTime.Now, AnfrageArt.Nahrungsmittel, 0, _Text_Nahrung);
        _Text_Nahrung = String.Empty;
        Toggle_Back();
    }

    private void Toggle_Sonstiges()
    {
        _Show_Sonstiges = true;
    }

    private void Sonstige_Anfrage()
    {
        CreateAnfrage(bett, DateTime.Now, AnfrageArt.Sonstiges, 0, _Text_Sonstiges);
        _Text_Sonstiges = String.Empty;
        Toggle_Back();
    }

    private void Toggle_Back()
    {
        _Show_Schmerzlevel = false;
        _Show_Nahrungsmittel = false;
        _Show_Sonstiges = false;
    }

    private void Medicine()
    {
        CreateAnfrage(bett, DateTime.Now, AnfrageArt.Medikamente, 0, String.Empty);
    }

    private void Toilet()
    {
        CreateAnfrage(bett, DateTime.Now, AnfrageArt.Hygiene, 0, String.Empty);
    }

    private void Schmerzlevel(int level)
    {
        CreateAnfrage(bett, DateTime.Now, AnfrageArt.Schmerzen, level, String.Empty);

        Toggle_Back();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Data.AnfrageService AnfrageService { get; set; }
    }
}
#pragma warning restore 1591