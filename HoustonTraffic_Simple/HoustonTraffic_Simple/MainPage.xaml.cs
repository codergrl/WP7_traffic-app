using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;

namespace HoustonTraffic_Simple
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<TrafficItem> TrafficItems = new ObservableCollection<TrafficItem>();

            for (int i = 0; i < 5; i++)
            {
                TrafficItem item = new TrafficItem("Title " + i.ToString(), "Desc " + i.ToString());
                TrafficItems.Add(item);
            }
        }
    }
}