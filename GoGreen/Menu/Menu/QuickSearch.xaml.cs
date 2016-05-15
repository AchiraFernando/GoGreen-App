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
    public sealed partial class QuickSearch : Page
    {

        private IMobileServiceTable<AllAdds> onlineTable = App.MobileService.GetTable<AllAdds>();


        public QuickSearch()
        {
            this.InitializeComponent();
           // HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private async Task RefreshTodoItems()
        {  // MobileServiceCollection<TodoItem, TodoItem> test;
            MobileServiceInvalidOperationException exception = null;

            String search = txtTitle.Text;
            try
            {

                ProgressRing.IsActive = true;

                ListItems.ItemsSource = await onlineTable
                    .Where(todoItem => todoItem.Title.Contains(search))
                    .ToCollectionAsync();

                ProgressRing.IsActive = false;


            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
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

        private void searchBut_Click(object sender, RoutedEventArgs e)
        {
            RefreshTodoItems();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AllAdds myobject = ListItems.SelectedItem as AllAdds;
            Account.addObj = myobject;

            Frame.Navigate(typeof(ViewAdd));
        }

    }

}