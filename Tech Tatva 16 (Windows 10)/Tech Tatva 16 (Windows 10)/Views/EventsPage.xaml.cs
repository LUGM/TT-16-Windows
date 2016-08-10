using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public EventsPage()
        {
            this.InitializeComponent();
            EventClass event1 = new EventClass();
            event1.Name = "Hello";
            event1.Image = "ms-appx:///Assets/Square44x44Logo.scale-200.png";
            event1.Fav_Image = "";

            EventClass event2 = new EventClass();
            event2.Name = "Hello1";
            event2.Image = "ms-appx:///Assets/Square44x44Logo.scale-200.png";
            event2.Fav_Image = "";

            ObservableCollection<EventClass> l = new ObservableCollection<EventClass>();
            l.Add(event1);
            l.Add(event2);

            Day day1 = new Day();
            day1.Events = l;
            day1.day = "Day 1";

            Day day2 = new Day();
            day2.Events = l;
            day2.day = "Day 2";

            Day day3 = new Day();
            day3.Events = l;
            day3.day = "Day 3";

            Day day4 = new Day();
            day4.Events = l;
            day4.day = "Day 4";

            this.Days.Add(day1);
            this.Days.Add(day2);
            this.Days.Add(day3);
            this.Days.Add(day4);

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
    }

}
