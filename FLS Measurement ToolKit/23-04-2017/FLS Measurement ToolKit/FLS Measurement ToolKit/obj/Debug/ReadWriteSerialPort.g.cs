﻿#pragma checksum "..\..\ReadWriteSerialPort.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8FCEC039C96AD7F505C79903B54128F9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FLS_Measurement_ToolKit;
using MahApps.Metro.Controls;
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


namespace FLS_Measurement_ToolKit {
    
    
    /// <summary>
    /// ReadWriteSerialPort
    /// </summary>
    public partial class ReadWriteSerialPort : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ReadWriteSerialPort.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ReadWriteGrid;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ReadWriteSerialPort.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.MetroProgressBar OnProgressBar;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ReadWriteSerialPort.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label readingAcquirel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ReadWriteSerialPort.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NoItrationRequired;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ReadWriteSerialPort.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStart;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ReadWriteSerialPort.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEnd;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ReadWriteSerialPort.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Ring;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ReadWriteSerialPort.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.ProgressRing OnProgressRing;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ReadWriteSerialPort.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox noItrRequirdTxtBox;
        
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
            System.Uri resourceLocater = new System.Uri("/FLS Measurement ToolKit;component/readwriteserialport.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReadWriteSerialPort.xaml"
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
            this.ReadWriteGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.OnProgressBar = ((MahApps.Metro.Controls.MetroProgressBar)(target));
            return;
            case 3:
            this.readingAcquirel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.NoItrationRequired = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.btnStart = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\ReadWriteSerialPort.xaml"
            this.btnStart.Click += new System.Windows.RoutedEventHandler(this.btnStart_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnEnd = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\ReadWriteSerialPort.xaml"
            this.btnEnd.Click += new System.Windows.RoutedEventHandler(this.btnEnd_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Ring = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.OnProgressRing = ((MahApps.Metro.Controls.ProgressRing)(target));
            return;
            case 9:
            this.noItrRequirdTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
