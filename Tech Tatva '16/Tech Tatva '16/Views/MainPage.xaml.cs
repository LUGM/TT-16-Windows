using Tech_Tatva__16.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Tech_Tatva__16.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public MainPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            EventClass event1 = new EventClass();
            event1.Name = "Hello";
            event1.Image = "ms-appx:///Assets/Square71x71Logo.scale-240.png";
            event1.Fav_Image = "ms-appx:///Assets/fav-icon_enabled.png";

            EventClass event2 = new EventClass();
            event2.Name = "Hello1";
            event2.Image = "ms-appx:///Assets/Square71x71Logo.scale-240.png";
            event2.Fav_Image = "ms-appx:///Assets/fav-icon_disabled.png";

            List<EventClass> l = new List<EventClass>();
            l.Add(event1);
            l.Add(event2);

            List<Day> list = new List<Day>();
            Day day1 = new Day();
            day1.Events = l;
            day1.day = "day 1";

            Day day2 = new Day();
            day2.Events = l;
            day2.day = "day 2";

            Day day3 = new Day();
            day3.Events = l;
            day3.day = "day 3";

            Day day4 = new Day();
            day4.Events = l;
            day4.day = "day 4";


            list.Add(day1);
            list.Add(day2);
            list.Add(day3);
            list.Add(day4);

            List<Results> res = new List<Results>();

            Results results = new Results();
            results.EventName = "Magnet Gun(Round 1)";
            results.Image = "ms-appx:///Assets/Square71x71Logo.scale-240.png";

            res.Add(results);
            res.Add(results);

            this.defaultViewModel["Days"] = list;
            this.defaultViewModel["Insta"] = "ms-appx:///Assets/back.jpg";
            this.defaultViewModel["Results"] = res;

        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion


        private void Day_Clicked(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(EventsPage), e.ClickedItem as Day);
        }
    }
}
