﻿#pragma checksum "..\..\..\..\MyWindows\GSM_Base_Params.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "337821F75458F894F26BED02AC663160"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Diplom.MyWindows {
    
    
    /// <summary>
    /// GSM_Base_Params
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class GSM_Base_Params : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cansel;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ok;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox P;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox G;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox L;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Fdl;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Ful;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Diplom;component/mywindows/gsm_base_params.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
            ((Diplom.MyWindows.GSM_Base_Params)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Cansel = ((System.Windows.Controls.Button)(target));
            
            #line 6 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
            this.Cansel.Click += new System.Windows.RoutedEventHandler(this.Cansel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Ok = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\..\MyWindows\GSM_Base_Params.xaml"
            this.Ok.Click += new System.Windows.RoutedEventHandler(this.Ok_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.P = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.G = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.L = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Fdl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Ful = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

