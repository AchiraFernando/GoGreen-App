using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Phone.UI.Input;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
     
    
    public sealed partial class Register : Page
    {
        //private MobileServiceCollection<DatabaseItems, DatabaseItems> items;
        private IMobileServiceTable<DatabaseItems> onlineTable = App.MobileService.GetTable<DatabaseItems>();

        public Register()
        {
            this.InitializeComponent();
            //HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        

        private async Task InsertDatabaseItems(DatabaseItems databaseItems)
        {
            await onlineTable.InsertAsync(databaseItems);
            //items.Add(databaseItems);
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if(txtPass.Password != txtPassConfirm.Password)
            {
                await new MessageDialog("Passwords do no match").ShowAsync();
            }
            else
            {
                DatabaseItems databaseItems = new DatabaseItems { Name = txtName.Text, Email = txtEmail.Text, Number = txtNumber.Text, Location = txtLocation.Text, Password = txtPass.Password };

                await InsertDatabaseItems(databaseItems);

                await new MessageDialog("Registration Successful").ShowAsync();

                Frame.Navigate(typeof(Login));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        //{
        //    Frame frame = Window.Current.Content as Frame;
        //    if (frame == null)
        //    {
        //        return;
        //    }
        //    if (frame.CanGoBack)
        //    {
        //        frame.GoBack();
        //        e.Handled = true;
        //    }
        //}

        
       
        
    }
}
