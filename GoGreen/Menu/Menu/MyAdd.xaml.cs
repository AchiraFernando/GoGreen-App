using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyAdd : Page
    {

        public MyAdd()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 

        BasicGeoposition adPosition;
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            // for displying title and description 


            title.Text = Account.addObj.Title;
            description.Text = Account.addObj.Description;

            //  getting the seller's location and showing it on the map

            String longi = Account.addObj.Longitude;
            String lati = Account.addObj.Latitude;

            adPosition = new Windows.Devices.Geolocation.BasicGeoposition();
            adPosition.Latitude = Double.Parse(lati);
            adPosition.Longitude = Double.Parse(longi);

            var myPoint = new Windows.Devices.Geolocation.Geopoint(adPosition);
            if (await sellerMap.TrySetViewAsync(myPoint, 18D))
            {

            }
            AddPushpin(adPosition, "");

            // accessing the DB for the stored image and displaying it 

            StorageCredentials creds = new StorageCredentials("gogreen", "Komo4vGSQPfw4uvFdaGi1ry9RGFRO/ltBpiabDyfdnd6G9/c04hPrYXe/WCZkziDij7qvctBHKSPLHdWQMdl6w==");
            CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer sampleContainer = client.GetContainerReference("images");

            string[] words = Account.addObj.PictureName.Split('/');


            CloudBlockBlob blockBlob = sampleContainer.GetBlockBlobReference(words[4]);


            ImageSource imgSource = new BitmapImage(blockBlob.Uri);
            addImage.Source = imgSource;

        }

        public void AddPushpin(BasicGeoposition location, string text)
        {
            var pin = new Grid()
            {
                Width = 50,
                Height = 50,
                Margin = new Windows.UI.Xaml.Thickness(-12)
            };

            pin.Children.Add(new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.DodgerBlue),
                Stroke = new SolidColorBrush(Colors.DarkOrange),
                StrokeThickness = 3,
                Width = 25,
                Height = 25
            });

            pin.Children.Add(new TextBlock()
            {
                Text = text,
                FontSize = 12,
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center
            });

            MapControl.SetLocation(pin, new Geopoint(location));
            sellerMap.Children.Add(pin);
        }
        private IMobileServiceTable<AllAdds> onlineTable = App.MobileService.GetTable<AllAdds>();
        private async void deleteAddBut_Click(object sender, RoutedEventArgs e)
        {

            await onlineTable.DeleteAsync(Account.addObj);

        }
    }
}
