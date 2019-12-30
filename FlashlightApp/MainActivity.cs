using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using static Android.Hardware.Camera;
using Java.Lang;
using Android.Util;
using Android.Media;
using System;
using Lamp.Plugin;
using static Android.Resource;
using System.Threading.Tasks;
using Android.Content.PM;

namespace FlashlightApp
{
    [Activity(Label = "FlashlightApp", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        bool loop = false;
        Camera camera;
        Button button;
        bool cameraFlashLightOn;

        protected override void OnCreate(Bundle bundle)
        {
            var v = CrossLamp.Current;
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var button = FindViewById<ImageButton>(Resource.Id.myButton);
            var button1 = FindViewById<Button>(Resource.Id.button1);
            TextView tv = FindViewById<TextView>(Resource.Id.textView1);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            
            button1.Click += delegate
            {
                if (!loop)
                {
                    loop = true;
                    loops();
                }
                else
                {
                    loop = false;

                }
            };
            bool isflashon=false;
            button.Click += delegate {
                if (!isflashon)
                {
                    isflashon = true;
                    CrossLamp.Current.TurnOn();
                    tv.Text = "FlashLight On";
                }
                else
                {
                    isflashon = false;
                    CrossLamp.Current.TurnOff();
                    tv.Text = "FlashLight Off";
                }
                
            };
        }
        public async void loops()
        {
            TextView tv = FindViewById<TextView>(Resource.Id.textView1);
            while (loop)
            {
                CrossLamp.Current.TurnOn();
                tv.Text = "FlashLight On";
                await Task.Delay(700);
                CrossLamp.Current.TurnOff();
                tv.Text = "FlashLight Off";
                await Task.Delay(700);
            }
        }
    }
}


