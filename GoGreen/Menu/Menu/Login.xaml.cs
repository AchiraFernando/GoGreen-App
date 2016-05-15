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
using Windows.UI.Xaml;
using Windows.Phone.UI.Input;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class Login : Page
    {
        private IMobileServiceTable<DatabaseItems> onlineTable = App.MobileService.GetTable<DatabaseItems>();
       // private MobileServiceCollection<DatabaseItems, DatabaseItems> items = null;
        public Login()
        {
            this.InitializeComponent();
            //HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Register_Button(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void button_Click_1(object sender, RoutedEventArgs e)
        { //var match = null;
            
                //MobileServiceCollection<DatabaseItems, DatabaseItems> arr = null;
                ObservableCollection<DatabaseItems> items = null;

                string email = textBox.Text;
                string password = passwordBox.Password;
                DatabaseItems test = new DatabaseItems();
            //test.Password = password;
            //test.Email = email;

            ProgressRing.IsActive = true;

            items = await onlineTable
                            .Where(databaseItems => databaseItems.Email == email && databaseItems.Password == password)
                            .ToCollectionAsync();

            ProgressRing.IsActive = false;

            if (items.Count == 1)
                {
                    Account.accID = items[0].Id;
                //await new MessageDialog(Account.accID).ShowAsync();
                if (Account.scLoc == 0) { Frame.Navigate(typeof(PostAdd)); }
                if (Account.scLoc == 1) { Frame.Navigate(typeof(ViewMyAdds)); }

            }
                else
                { await new MessageDialog("Entered Email or Password Incorrect").ShowAsync(); }
            
            
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
