using HoustonTraffic.Model;
using System.Collections.Generic;

namespace HoustonTraffic
{
    public class TrafficIncidentsModel : BaseModel
    {
        private List<TrafficEvent> incidentList;
        public List<TrafficEvent> IncidentList
        {
            get { return this.incidentList; }

            set
            {
                if (value != this.incidentList)
                {
                    this.incidentList = value;
                    NotifyPropertyChanged("incidentList");
                }
            }
        }
    }
}
