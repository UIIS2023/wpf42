﻿#pragma checksum "..\..\..\..\Forme\FrmZaposleni.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12ED2D7E4D2E7D348DD042AB83065B255D9256F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SalonLepote.Forme;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SalonLepote.Forme {
    
    
    /// <summary>
    /// FrmZaposleni
    /// </summary>
    public partial class FrmZaposleni : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Forme\FrmZaposleni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Otkazi;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Forme\FrmZaposleni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Sacuvaj;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Forme\FrmZaposleni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImeZaposlenog;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Forme\FrmZaposleni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrezimeZaposlenog;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Forme\FrmZaposleni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKontaktZaposlenog;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SalonLepote;component/forme/frmzaposleni.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forme\FrmZaposleni.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Otkazi = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Forme\FrmZaposleni.xaml"
            this.Otkazi.Click += new System.Windows.RoutedEventHandler(this.Otkazi_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Sacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Forme\FrmZaposleni.xaml"
            this.Sacuvaj.Click += new System.Windows.RoutedEventHandler(this.Sacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtImeZaposlenog = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtPrezimeZaposlenog = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtKontaktZaposlenog = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

