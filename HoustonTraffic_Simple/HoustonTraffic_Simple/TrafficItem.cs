using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HoustonTraffic_Simple
{
    public class TrafficItem
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public TrafficItem(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}
