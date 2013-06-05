using System.Windows;
using Microsoft.Phone.Controls;

namespace HoustonTraffic
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (TrafficEvent incident in App.incidentsList)
            {
                IncidentControl incidentControl = new IncidentControl();
                incidentControl.title.Text = incident.Title;
                incidentControl.description.Text = incident.Description;
                //incidentsPanel.Children.Add(incidentControl);
            }

            foreach (TrafficEvent laneClosure in App.laneClosureList)
            {
                IncidentControl laneClosureControl = new IncidentControl();
                laneClosureControl.title.Text = laneClosure.Title;
                laneClosureControl.description.Text = laneClosure.Description;
                laneClosuresPanel.Children.Add(laneClosureControl);
            }

            foreach (TrafficEvent travelTime in App.travelTimesList)
            {
                IncidentControl travelTimeControl = new IncidentControl();
                travelTimeControl.title.Text = travelTime.Title;
                travelTimeControl.description.Text = travelTime.Description;
                travelTimesPanel.Children.Add(travelTimeControl);
            }
        }
    }
}