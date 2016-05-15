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
using Windows.Phone.UI.Input;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
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
    public sealed partial class ViewAdd : Page
    {
        public ViewAdd()
        {
            this.InitializeComponent();
            //HardwareButtons.BackPressed += HardwareButtons_BackPressed;
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
            title.Text = Account.addObj.Title;
            description.Text = Account.addObj.Description;
            sellerNumber.Text = Account.addObj.Number;

            String longi = Account.addObj.Longitude;
            String lati = Account.addObj.Latitude;


            adPosition = new Windows.Devices.Geolocation.BasicGeoposition();
            adPosition.Latitude = Double.Parse(lati);
            adPosition.Longitude = Double.Parse(longi);

          //  imageProgressRing.IsActive = true;

            var myPoint = new Windows.Devices.Geolocation.Geopoint(adPosition);
            if (await sellerMap.TrySetViewAsync(myPoint, 18D))
            {

            }
            AddPushpin(adPosition, "");

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



        public async void Directions(BasicGeoposition start, BasicGeoposition end)
        {


            Geopoint startPoint = new Geopoint(start);
            Geopoint endPoint = new Geopoint(end);
            // Get the route between the points.
            MapRouteFinderResult routeResult =
            await MapRouteFinder.GetDrivingRouteAsync(
              startPoint,
              endPoint,
              MapRouteOptimization.Time,
              MapRouteRestrictions.None,
              290);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                // Use the route to initialize a MapRouteView.
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.Blue;
                viewOfRoute.OutlineColor = Colors.Blue;
                // Add the new MapRouteView to the Routes collection
                // of the MapControl.
                sellerMap.Routes.Add(viewOfRoute);
                // Fit the MapControl to the route.
                await sellerMap.TrySetViewBoundsAsync(
                  routeResult.Route.BoundingBox,
                  null,
                  Windows.UI.Xaml.Controls.Maps.MapAnimationKind.Bow);
            }


        }


        private async void directions_Click(object sender, RoutedEventArgs e)
        {
            //getting current location
            var locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 40;

            mapProgressRing.IsActive = true;

            var position = await locator.GetGeopositionAsync();

            double Long = position.Coordinate.Point.Position.Longitude;
            double Lati = position.Coordinate.Point.Position.Latitude;

            BasicGeoposition startLocation = new BasicGeoposition();
            startLocation.Latitude = Lati;
            startLocation.Longitude = Long;
            BasicGeoposition endLocation = new BasicGeoposition();
            endLocation.Latitude = adPosition.Latitude;
            endLocation.Longitude = adPosition.Longitude;

            Directions(startLocation, endLocation);
            mapProgressRing.IsActive = false;
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
