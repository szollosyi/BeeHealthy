﻿#pragma checksum "..\..\..\..\userManagement\EditUserWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1FCCFA4B7F5736A0A5F1BB3264AD942A8305207D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BeeHealthyLoginClient.userManagement;
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


namespace BeeHealthyLoginClient.userManagement {
    
    
    /// <summary>
    /// EditUserWindow
    /// </summary>
    public partial class EditUserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\userManagement\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxFelhasznaloNev;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\userManagement\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbxJelszo1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\userManagement\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbxJelszo2;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\userManagement\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxTeljesNev;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\userManagement\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxEmail;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\userManagement\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxPermission;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\userManagement\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbActive;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\userManagement\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgProfilkep;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\userManagement\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbProfilkep;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BeeHealthyLoginClient;component/usermanagement/edituserwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\userManagement\EditUserWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbxFelhasznaloNev = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\..\..\userManagement\EditUserWindow.xaml"
            this.cbxFelhasznaloNev.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxFelhasznaloNev_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pbxJelszo1 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.pbxJelszo2 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.tbxTeljesNev = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbxEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cbxPermission = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cbActive = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.imgProfilkep = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.tbProfilkep = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            
            #line 45 "..\..\..\..\userManagement\EditUserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ImageSelect_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 51 "..\..\..\..\userManagement\EditUserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Modositas_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 52 "..\..\..\..\userManagement\EditUserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Torles_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 53 "..\..\..\..\userManagement\EditUserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Megse_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

