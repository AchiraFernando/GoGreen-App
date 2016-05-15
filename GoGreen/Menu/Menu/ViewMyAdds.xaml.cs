using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewMyAdds : Page
    {
        private IMobileServiceTable<AllAdds> onlineTable = App.MobileService.GetTable<AllAdds>();

        private async Task RefreshTodoItems()
        {  // MobileServiceCollection<TodoItem, TodoItem> test;
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems

                ListItems.ItemsSource = await onlineTable
                    .Where(todoItem => todoItem.AccID == Account.accID)
                    .ToCollectionAsync();


                // if (items== null) { await new MessageDialog(exception.Message, "Error loading items").ShowAsync(); }

            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //await InitLocalStoreAsync(); // offline sync
            await RefreshTodoItems();



        }

        public ViewMyAdds()
        {
            this.InitializeComponent();
           // HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void myAdd(object sender, TappedRoutedEventArgs e)
        {
            AllAdds myobject = ListItems.SelectedItem as AllAdds;
            Account.addObj = myobject;

            Frame.Navigate(typeof(MyAdd));
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>


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
