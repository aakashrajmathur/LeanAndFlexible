﻿#pragma checksum "..\..\PriorityUserControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D73883A98E4F653382E95DADB6040036"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NewHorizons;
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
using Xceed.Wpf.Toolkit;


namespace NewHorizons {
    
    
    /// <summary>
    /// PriorityUserControl
    /// </summary>
    public partial class PriorityUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveAsButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label priorityNameLabel;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statusLabel;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider PrioritySlider;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label prioritySliderLabel;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelAlwaysIncluded;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelIncluded;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelNotIncluded;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\PriorityUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelNeverIncluded;
        
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
            System.Uri resourceLocater = new System.Uri("/NewHorizons;component/priorityusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PriorityUserControl.xaml"
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
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\PriorityUserControl.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SaveAsButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\PriorityUserControl.xaml"
            this.SaveAsButton.Click += new System.Windows.RoutedEventHandler(this.saveAsButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\PriorityUserControl.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.priorityNameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.statusLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.PrioritySlider = ((System.Windows.Controls.Slider)(target));
            
            #line 48 "..\..\PriorityUserControl.xaml"
            this.PrioritySlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.prioritySliderLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.StackPanelAlwaysIncluded = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.StackPanelIncluded = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.StackPanelNotIncluded = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.StackPanelNeverIncluded = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

