﻿#pragma checksum "..\..\MenuImpresario.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D3457EC1CDCF89319089F1D1C5C92E0518354A2C823B229A00834E4831141124"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Filarmonia;
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


namespace Filarmonia {
    
    
    /// <summary>
    /// MenuImpresario
    /// </summary>
    public partial class MenuImpresario : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\MenuImpresario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Actor;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MenuImpresario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ever;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MenuImpresario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Spisok_Genre;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MenuImpresario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Spisok_Actor;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MenuImpresario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button M_Genre;
        
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
            System.Uri resourceLocater = new System.Uri("/Filarmonia;component/menuimpresario.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MenuImpresario.xaml"
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
            this.Actor = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\MenuImpresario.xaml"
            this.Actor.Click += new System.Windows.RoutedEventHandler(this.Actor_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Ever = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\MenuImpresario.xaml"
            this.Ever.Click += new System.Windows.RoutedEventHandler(this.Ever_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Spisok_Genre = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\MenuImpresario.xaml"
            this.Spisok_Genre.Click += new System.Windows.RoutedEventHandler(this.Spisok_Genre_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Spisok_Actor = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\MenuImpresario.xaml"
            this.Spisok_Actor.Click += new System.Windows.RoutedEventHandler(this.Spisok_Actor_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.M_Genre = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\MenuImpresario.xaml"
            this.M_Genre.Click += new System.Windows.RoutedEventHandler(this.M_Genre_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

