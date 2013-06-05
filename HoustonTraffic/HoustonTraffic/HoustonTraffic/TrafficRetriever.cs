using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Windows;
using System.Net;
using System;

namespace HoustonTraffic
{
    public class TrafficRetriever
    {
        private const string incidentsUrl = "http://traffic.houstontranstar.org/data/rss/incidents_rss.xml";
        private List<TrafficEvent> incidentList = new List<TrafficEvent>();
        public List<TrafficEvent> FetchIncidents()
        {
            RssClient rssClient = new RssClient(incidentsUrl);
            rssClient.LoadItems();
            return incidentList;
        }


        private const string laneClosuresUrl = "http://traffic.houstontranstar.org/data/rss/laneclosures_rss.xml";
        private List<TrafficEvent> laneClosuresList = new List<TrafficEvent>();
        public List<TrafficEvent> FetchLaneClosures()
        {
            TrafficEvent laneClosure = new TrafficEvent();
            laneClosure.Title = "IH-10 EAST Eastbound Exit Ramp to FEDERAL RD";
            laneClosure.Description = "Closed continuously until 3:00 PM, Wednesday, May 18 - Lanes Affected: TOTAL CLOSURE - Status: Active";
            laneClosuresList.Add(laneClosure);
            return laneClosuresList;
        }

        private const string travelTimeUrl = "http://traffic.houstontranstar.org/data/rss/traveltimes_rss.xml";
        private List<TrafficEvent> travelTimesList = new List<TrafficEvent>();
        public List<TrafficEvent> FetchTravelTimes()
        {
            TrafficEvent travelTime = new TrafficEvent();
            travelTime.Title = "No Travel Times are reported.";
            travelTime.Description = "";
            travelTimesList.Add(travelTime);
            return travelTimesList;
        }

    }

    public class TrafficEvent
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string description;
        public string Description
        { 
            get { return description; }
            set { description = value; }
        }
    }

}
