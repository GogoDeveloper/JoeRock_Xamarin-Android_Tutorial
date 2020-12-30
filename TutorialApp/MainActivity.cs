using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Console = System.Console;

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
            mItems.Add(new Person { FirstName = "Joe", LastName = "Smith", Age = "22", Gender = "Male" });
            mItems.Add(new Person { FirstName = "Tom", LastName = "Tom", Age = "35", Gender = "Male" });
            mItems.Add(new Person { FirstName = "Sally", LastName = "Susan", Age = "88", Gender = "Female" });

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            mListView.Adapter = adapter;
            
            mListView.ItemClick += mListView_ItemClick;
            mListView.ItemLongClick += mListView_ItemLongClick;

            mListView.ItemClick += mListView_ItemClick2;

        }

        private void mListView_ItemClick2(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine("Second Method");
        }

        private void mListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].LastName);
        }

        private void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].FirstName);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}