using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Support.V4.Content;
using Android;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Util;
using Android.Gms.Location;
using System.Threading.Tasks;
using Android.Locations;

namespace GuideApp
{
    [Activity(Label = "GuideApp", MainLauncher = true)]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        FusedLocationProviderClient fusedLocationProviderClient;

        LocationRequest locationRequest = new LocationRequest()
                                      .SetPriority(LocationRequest.PriorityHighAccuracy)
                                      .SetInterval(60 * 1000 * 5)
                                      .SetFastestInterval(60 * 1000 * 2);

        public async void OnMapReady(GoogleMap googleMap)
        {
            async Task GetLastLocationFromDevice()
            {
                FusedLocationProviderCallback fused = new FusedLocationProviderCallback(this);
                //Android.Locations.Location location = await fusedLocationProviderClient.RequestLocationUpdatesAsync(locationRequest, fused);
                //await fusedLocationProviderClient.RequestLocationUpdatesAsync(locationRequest, fused);
                await fusedLocationProviderClient.RequestLocationUpdatesAsync(locationRequest, fused);

                // Do something with the location 
                //Log.Debug("SampleInMain", "The latitude is " + location.Latitude);
                //MarkerOptions markerOptions = new MarkerOptions();
                //markerOptions.SetPosition(fused.ReturnCurrentPosition());
                //markerOptions.SetTitle("Current Position");
                //googleMap.AddMarker(markerOptions);


                //if (location == null)
                //{
                //    // Seldom happens, but should code that handles this scenario
                //}
                //else
                //{

                //}
            }
            await GetLastLocationFromDevice();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Mapa
            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);

            //Lokalizacja
            fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(this);


        }
    }
}

