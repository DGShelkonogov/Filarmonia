#pragma checksum "..\..\RedacAward.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B2B059F866554BD21380E27C57BA2BAB72A9CAB018F772965F31F1C822CF396B"
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
    /// RedacAward
    /// </summary>
    public partial class RedacAward : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\RedacAward.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Poisk;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\RedacAward.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Poisk1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\RedacAward.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeAward;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\RedacAward.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\RedacAward.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Nazad;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RedacAward.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Award;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\RedacAward.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\RedacAward.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Surname;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\RedacAward.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Otchestvo;
        
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
            System.Uri resourceLocater = new System.Uri("/Filarmonia;component/redacaward.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RedacAward.xaml"
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
            
            #line 8 "..\..\RedacAward.xaml"
            ((Filarmonia.RedacAward)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Poisk = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\RedacAward.xaml"
            this.Poisk.Click += new System.Windows.RoutedEventHandler(this.Poisk_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Poisk1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ChangeAward = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\RedacAward.xaml"
            this.ChangeAward.Click += new System.Windows.RoutedEventHandler(this.ChangeAward_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dg1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 14 "..\..\RedacAward.xaml"
            this.dg1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dg1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Nazad = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\RedacAward.xaml"
            this.Nazad.Click += new System.Windows.RoutedEventHandler(this.Nazad_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Award = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Surname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Otchestvo = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

