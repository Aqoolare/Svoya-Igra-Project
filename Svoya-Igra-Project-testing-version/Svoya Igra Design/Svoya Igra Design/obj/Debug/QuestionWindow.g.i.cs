﻿#pragma checksum "..\..\QuestionWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5DAE88240AD3029338A88AD8A3F82A19CF2AB1A1BE843608FC2C3D0ACC2A3432"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Svoya_Igra_Design;
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


namespace Svoya_Igra_Design {
    
    
    /// <summary>
    /// QuestionWindow
    /// </summary>
    public partial class QuestionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\QuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuestionTextBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\QuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnswerTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\QuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GiveAnswerButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\QuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WrongAnswerButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\QuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RightAnswerButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\QuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeTB;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\QuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OKButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Svoya Igra Design;component/questionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\QuestionWindow.xaml"
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
            
            #line 9 "..\..\QuestionWindow.xaml"
            ((Svoya_Igra_Design.QuestionWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.QuestionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AnswerTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.GiveAnswerButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\QuestionWindow.xaml"
            this.GiveAnswerButton.Click += new System.Windows.RoutedEventHandler(this.WriteAnswerButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.WrongAnswerButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\QuestionWindow.xaml"
            this.WrongAnswerButton.Click += new System.Windows.RoutedEventHandler(this.WrongAnswerButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RightAnswerButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\QuestionWindow.xaml"
            this.RightAnswerButton.Click += new System.Windows.RoutedEventHandler(this.RightAnswerButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TimeTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.OKButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\QuestionWindow.xaml"
            this.OKButton.Click += new System.Windows.RoutedEventHandler(this.OKButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
