using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace TutorialApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private List<Person> mItems;
        private ListView mListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            SetContentView(Resource.Layout.activity_main);

            
            mListView = FindViewById<ListView>(Resource.Id.myListView);

            mItems = new List<Person>();
            mItems.Add(new Person { FirstName = "Joe", LastName = "Müller", Age = "16", Gender = "Male" });
            mItems.Add(new Person { FirstName = "Hans", LastName = "Hunzig", Age = "23", Gender = "Male" });
            mItems.Add(new Person { FirstName = "Mathilde", LastName = "Habsburg", Age = "43", Gender = "Female" });

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            mListView.Adapter = adapter;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}