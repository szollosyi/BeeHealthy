﻿#pragma checksum "..\..\..\..\medicineManagement\EditMedicineWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C7AD865C8F1EAC8D74FE08B45F339AA38EDB7AED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BeeHealthyLoginClient.medicineManagement;
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


namespace BeeHealthyLoginClient.medicineManagement {
    
    
    /// <summary>
    /// EditMedicineWindow
    /// </summary>
    public partial class EditMedicineWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxGyogyszerNev;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxGyartoId;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxKategoria;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxAdagolas;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxKezelesiIdopont;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DprKezelesIdo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxMegjegyzes;
        
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
            System.Uri resourceLocater = new System.Uri("/BeeHealthyLoginClient;V1.0.0.0;component/medicinemanagement/editmedicinewindow.x" +
                    "aml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
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
            this.tbxGyogyszerNev = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.cbxGyartoId = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.tbxKategoria = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbxAdagolas = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbxKezelesiIdopont = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.DprKezelesIdo = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.tbxMegjegyzes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 31 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Torles);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 32 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Modositas);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 33 "..\..\..\..\medicineManagement\EditMedicineWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Megse);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

