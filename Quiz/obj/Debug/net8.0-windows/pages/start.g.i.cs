﻿#pragma checksum "..\..\..\..\pages\start.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF09096B8E7B00D29E34C9C9E4A808D37B89DC52"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Quiz.pages;
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


namespace Quiz.pages {
    
    
    /// <summary>
    /// start
    /// </summary>
    public partial class start : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\pages\start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbQuizType;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\pages\start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNumberOfQuestions;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\pages\start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStartQuiz;
        
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
            System.Uri resourceLocater = new System.Uri("/Quiz;V1.0.0.0;component/pages/start.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\pages\start.xaml"
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
            this.cmbQuizType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\..\..\pages\start.xaml"
            this.cmbQuizType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CmbQuizType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtNumberOfQuestions = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\pages\start.xaml"
            this.txtNumberOfQuestions.GotFocus += new System.Windows.RoutedEventHandler(this.TxtNumberOfQuestions_GotFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\pages\start.xaml"
            this.txtNumberOfQuestions.LostFocus += new System.Windows.RoutedEventHandler(this.TxtNumberOfQuestions_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnStartQuiz = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\pages\start.xaml"
            this.btnStartQuiz.Click += new System.Windows.RoutedEventHandler(this.BtnStartQuiz_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

