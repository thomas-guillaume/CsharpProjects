﻿#pragma checksum "..\..\V_Recherche.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "52BE75A3C23BB5C24CCE62BDB9F6A839"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MVC_TDFinal_GUILLAUME_Thomas;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace MVC_TDFinal_GUILLAUME_Thomas {
    
    
    /// <summary>
    /// V_Recherche
    /// </summary>
    public partial class V_Recherche : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\V_Recherche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Rechercher;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\V_Recherche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textdate;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\V_Recherche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textquartier;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\V_Recherche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textdescription;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\V_Recherche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Resultats;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\V_Recherche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label date;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\V_Recherche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label quartier;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\V_Recherche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label description;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MVC_TDFinal_GUILLAUME_Thomas;component/v_recherche.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\V_Recherche.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Rechercher = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\V_Recherche.xaml"
            this.Rechercher.Click += new System.Windows.RoutedEventHandler(this.Rechercher_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textdate = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\V_Recherche.xaml"
            this.textdate.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textdate_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textquartier = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\V_Recherche.xaml"
            this.textquartier.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textquartier_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textdescription = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\V_Recherche.xaml"
            this.textdescription.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textdescription_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Resultats = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.date = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.quartier = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.description = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

