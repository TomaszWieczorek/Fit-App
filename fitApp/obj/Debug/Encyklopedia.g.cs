﻿

#pragma checksum "D:\aSTUDIA\fitApp\fitApp\Encyklopedia.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "515921D7E99C78DB80CB46E3D5925428"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fitApp
{
    partial class Encyklopedia : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 30 "..\..\Encyklopedia.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnEncyklopedia_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 31 "..\..\Encyklopedia.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnMenu_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 42 "..\..\Encyklopedia.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.comboBoxProdukt_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 43 "..\..\Encyklopedia.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.comboBoxKategoria_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


