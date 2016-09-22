using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tech_Tatva__16.Classes;
using Tech_Tatva_16__Windows_10_.Classes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Tech_Tatva_16__Windows_10_.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsPage : Page
    {


        public ObservableCollection<Day> Days = new ObservableCollection<Day>();
        public ObservableCollection<Day> Favourites = new ObservableCollection<Day>(); 

        public EventsPage()
        {
            this.InitializeComponent();

            Filter_Fav.SelectedIndex = 0;
            EventClass event1 = new EventClass();
            event1.id = 1;
            event1.Name = "Hello";
            event1.Image = "ms-appx:///Assets/Square44x44Logo.scale-200.png";
            event1.Fav_Image = "";

            EventClass event2 = new EventClass();
            event2.id = 2;
            event2.Name = "Hello1";
            event2.Image = "ms-appx:///Assets/Square44x44Logo.scale-200.png";
            event2.Fav_Image = "";

            DatabaseHelperClass db = new DatabaseHelperClass();
            db.DeleteAllEvents();
            db.Insert(event1);
            db.Insert(event2);

            List<EventClass> l1 = new List<EventClass>();
            l1 = db.ReadEvents();

            ObservableCollection<EventClass> l = new ObservableCollection<EventClass>(l1);

            Day day1 = new Day();
            day1.Events = l;
            day1.day = "Day 1";

            this.Days.Add(day1);

            Day dayfav = new Day();
            dayfav.day = "";

            ObservableCollection<EventClass> lis = new ObservableCollection<EventClass>();

            foreach (Day d in Days)
            {
                foreach(EventClass events in d.Events)
                {
                    if (events.Fav_Image.Equals(""))
                    {
                        lis.Add(events);
                    }
                }
            }

            if (lis.Count == 0)
                dayfav.day = "No Favourites Added Yet..";

            dayfav.Events = lis;
            Favourites.Add(dayfav);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            string myPages = "";
            foreach (PageStackEntry page in Frame.BackStack)
            {
                myPages += page.SourcePageType.ToString() + "\n";
            }

            if (Frame.CanGoBack && Frame.BackStackDepth > 1)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }

            if((string)e.Parameter != "" && e.Parameter != null && e.Parameter.GetType() == typeof(string))
            {
                ObservableCollection<EventClass> l = new ObservableCollection<EventClass>();
                DatabaseHelperClass db = new DatabaseHelperClass();
                EventClass eve = db.ReadEventByName((string)e.Parameter);
                if(eve == null)
                {
                    l.Add(eve);
                    Days.Clear();
                    Day day1 = new Day();
                    day1.Events = l;
                    day1.day = "Event Not Found";
                    Days.Add(day1);
                }
                else
                {
                    l.Add(eve);
                    Days.Clear();
                    Day day1 = new Day();
                    day1.Events = l;
                    day1.day = "Event Found";
                    Days.Add(day1);
                }
            }
        }




        private void Event_Clicked(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
            {
                ListViewItem _Item = (sender as ListView).ContainerFromItem(item) as ListViewItem;
                var _Children = AllChildren(_Item);
                var _Name = "DetailsPanel";
                var _Control = (StackPanel)_Children.First(c => c.Name == _Name);

                _Control.Visibility = Visibility.Visible;

                // you will get slected item here. Use that item to get listbox item
            }
            foreach (var item in e.RemovedItems)
            {
                ListViewItem _Item = (sender as ListView).ContainerFromItem(item) as ListViewItem;
                var _Children = AllChildren(_Item);
                var _Name = "DetailsPanel";
                var _Control = (StackPanel)_Children.First(c => c.Name == _Name);

                _Control.Visibility = Visibility.Collapsed;
            }
        }

        public List<StackPanel> AllChildren(DependencyObject parent)
        {
            var _List = new List<StackPanel> { };
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is StackPanel)
                    _List.Add(_Child as StackPanel);

                _List.AddRange(AllChildren(_Child));
            }

            return _List;
        }

        private void Fav_Button_Click(object sender, RoutedEventArgs e)
        {
            EventClass events = new EventClass();
            events = (sender as RadioButton).DataContext as EventClass;

            DatabaseHelperClass db = new DatabaseHelperClass();

            if ((sender as RadioButton).Tag.Equals(""))
            {
                (sender as RadioButton).Tag = ("");
                (sender as RadioButton).Content = "Remove Bookmark";
            }

            else if ((sender as RadioButton).Tag.Equals(""))
            {
                (sender as RadioButton).Tag = ("");
                (sender as RadioButton).Content = "Bookmark Event";
            }

            foreach (Day day in Days)
            {
                foreach (EventClass ev in day.Events)
                {
                    if (ev.Name.Equals(events.Name))
                    {
                        ev.Fav_Image = (sender as RadioButton).Tag.ToString();
                        db.UpdateEvent(ev);
                        break;
                    }
                }
            }

        }

        public List<Control> AllChildrenControls(DependencyObject parent)
        {
            var _List = new List<Control> { };
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is Control)
                    _List.Add(_Child as Control);

                _List.AddRange(AllChildrenControls(_Child));
            }

            return _List;
        }

        private void Filter_Fav_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((sender as ComboBox).SelectedIndex == 1)
            {
                Day dayfav = new Day();
                dayfav.day = "";

                ObservableCollection<EventClass> lis = new ObservableCollection<EventClass>();

                foreach (Day d in Days)
                {
                    foreach (EventClass events in d.Events)
                    {
                        if (events.Fav_Image.Equals(""))
                        {
                            lis.Add(events);
                        }
                    }
                }

                dayfav.Events = lis;

                if (lis.Count == 0)
                    dayfav.day = "No Favourites Added Yet..";

                Favourites.Clear();
                Favourites.Add(dayfav);

                MyPivot.ItemsSource = Favourites;
            }

            if ((sender as ComboBox).SelectedIndex == 0)
            {
                MyPivot.ItemsSource = Days;
            }
        }

        private void Fav_Button_Loaded(object sender, RoutedEventArgs e)
        {
            EventClass eve = (sender as RadioButton).DataContext as EventClass;
            if ((sender as RadioButton).Tag.Equals(""))
            {
                (sender as RadioButton).Content = "Bookmark Event";
            }

            else if ((sender as RadioButton).Tag.Equals(""))
            {
                (sender as RadioButton).Content = "Remove Bookmark";
            }
        }
    }

}
