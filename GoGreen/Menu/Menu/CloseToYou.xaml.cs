using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CloseToYou : Page
    {
        private IMobileServiceTable<AllAdds> onlineTable = App.MobileService.GetTable<AllAdds>();
        public CloseToYou()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            InputScope scope = new InputScope();
            InputScopeName name = new InputScopeName();

            name.NameValue = InputScopeNameValue.Number;
            scope.Names.Add(name);

            txtDis.InputScope = scope;
        }

        private async void find_Click(object sender, RoutedEventArgs e)
        {
            double Long;
            double Lati;
            double accuracy = 0;


                try
                {
                    accuracy = Convert.ToDouble(txtDis.Text);
                }catch( FormatException ex)
                {
                    await new MessageDialog("Please enter the distance").ShowAsync();
                }

               

                /*Getting Current Location*/
                var locator = new Geolocator();
                locator.DesiredAccuracyInMeters = 40;

                ProgressRing.IsActive = true;

                var position = await locator.GetGeopositionAsync();
                //Long = position.Coordinate.Longitude;
                //  GetMap.Center.Position.Longitude;
                //Lati = position.Coordinate.Latitude;

                Long = position.Coordinate.Point.Position.Longitude;
                Lati = position.Coordinate.Point.Position.Latitude;

                //await new MessageDialog(cos.ToString()).ShowAsync();

                /*Getting ads close by*/
                double longMax;
                double longMin;

                double latiMax;
                double latiMin;

                latiMax = (accuracy * 0.01) + Lati ;
                latiMin = Lati - (accuracy * 0.01) ;

                double cos = Math.Cos(Lati * (Math.PI / 180.0));
                        
                longMax = (accuracy*(1/(111.320*cos))) + Long;
                longMin = Long-(accuracy * (1 / (111.320 * cos))) ;

                //await new MessageDialog(latiMax.ToString()).ShowAsync();
                //await new MessageDialog(latiMin.ToString()).ShowAsync();

                ListItems.ItemsSource = await onlineTable
                .Where(todoItem =>
                todoItem.Dlongitude < longMax && todoItem.Dlongitude > longMin
                ||
                todoItem.Dlatitude < latiMax && todoItem.Dlatitude > latiMin
                )
                .ToCollectionAsync();
                ProgressRing.IsActive = false;
        
            

        }

       // public Boolean compare 

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AllAdds myobject = ListItems.SelectedItem as AllAdds;
            Account.addObj = myobject;

            Frame.Navigate(typeof(ViewAdd));
        }
    }
}
