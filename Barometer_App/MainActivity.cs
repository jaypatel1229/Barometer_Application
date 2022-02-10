using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace Barometer_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",MainLauncher =true)]
    class MainActivity : Activity
    {

        private Button start;
        private Button stop;
        private TextView textV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            UIReference();
            UIClickEvent();
        }

        private void UIClickEvent()
        {
            start.Click += Start_Click;
            stop.Click += Stop_Click;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (!Barometer.IsMonitoring)
            {
                Barometer.ReadingChanged += Barometer_ReadingChanged;
                Barometer.Start(SensorSpeed.UI);

            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (Barometer.IsMonitoring)
            {
                Barometer.ReadingChanged -= Barometer_ReadingChanged;
                Barometer.Stop();
            }
        }



        

        private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            textV.Text = $"Pressure: {e.Reading.PressureInHectopascals} hectopascals";
        }


        private void UIReference()
        {
            start = FindViewById<Button>(Resource.Id.startBtn);
            stop = FindViewById<Button>(Resource.Id.stopBtn);
            textV = FindViewById<TextView>(Resource.Id.txtView1);

        }
    }
}