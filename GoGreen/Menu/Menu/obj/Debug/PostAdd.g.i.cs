﻿

#pragma checksum "C:\Users\achirafernando\Documents\Visual Studio 2015\Projects\GoGreen\Menu\Menu\PostAdd.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "08E49E0E0989F17E5072EEC6BC921AFF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Menu
{
    partial class PostAdd : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock txtPostAddLabel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock category; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock itemInfo; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox txtAddTitle; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox txtItemDescription; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ComboBox categoryCombo; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock sellingPrice; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox txtSellingPrice; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock contactDetails; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox txtContactNumber; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Maps.MapControl GetMap; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button genLocBut; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock addPhoto; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button uploadPicBut; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ProgressRing ProgressRing1; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Image selectedImage; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button postAddBut; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ProgressRing mapProgressRing; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///PostAdd.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            txtPostAddLabel = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("txtPostAddLabel");
            category = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("category");
            itemInfo = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("itemInfo");
            txtAddTitle = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("txtAddTitle");
            txtItemDescription = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("txtItemDescription");
            categoryCombo = (global::Windows.UI.Xaml.Controls.ComboBox)this.FindName("categoryCombo");
            sellingPrice = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("sellingPrice");
            txtSellingPrice = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("txtSellingPrice");
            contactDetails = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("contactDetails");
            txtContactNumber = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("txtContactNumber");
            GetMap = (global::Windows.UI.Xaml.Controls.Maps.MapControl)this.FindName("GetMap");
            genLocBut = (global::Windows.UI.Xaml.Controls.Button)this.FindName("genLocBut");
            addPhoto = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("addPhoto");
            uploadPicBut = (global::Windows.UI.Xaml.Controls.Button)this.FindName("uploadPicBut");
            ProgressRing1 = (global::Windows.UI.Xaml.Controls.ProgressRing)this.FindName("ProgressRing1");
            selectedImage = (global::Windows.UI.Xaml.Controls.Image)this.FindName("selectedImage");
            postAddBut = (global::Windows.UI.Xaml.Controls.Button)this.FindName("postAddBut");
            mapProgressRing = (global::Windows.UI.Xaml.Controls.ProgressRing)this.FindName("mapProgressRing");
        }
    }
}


