using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 
        private IMobileServiceTable<DatabaseItems> onlineTable = App.MobileService.GetTable<DatabaseItems>();
        String name;
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            //try
            //{
            //    txtLoginAs.Text = this.name;
            //}
            //catch (NullReferenceException ex)
            //{
            //    await new MessageDialog(ex.Message).ShowAsync();
            //}


            //if (Account.accID != null)
            //{
            //    txtLoginAs.Text = this.name;
            //}
            //else
            //{

            //}


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Account.accID == null)
            {
                Frame.Navigate(typeof(Login));
                Account.scLoc = 0;

                //DatabaseItems myobject =  new DatabaseItems();
                //Account.diObj = myobject;

                //name = Account.diObj.Name;
        }
            else {
                Frame.Navigate(typeof(PostAdd));
            }
}

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Explore));
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (Account.accID == null)
            {
                Frame.Navigate(typeof(Login));
                Account.scLoc = 1;
            }
            else
            {
                Frame.Navigate(typeof(ViewMyAdds));
            }
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(QuickSearch));
        }

    }
}
