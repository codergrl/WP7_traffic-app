using System;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace HoustonTraffic
{
    public class RssClient
    {
        /// <summary> URL for the RSS feed
        /// </summary>
        private readonly string _rssUrl;
        public delegate void ItemsReceivedDelegate(RssClient client, IList<TrafficEvent> items);
        public event ItemsReceivedDelegate ItemsReceived;

        /// <summary> Constructor
        /// </summary>
        /// <param name="rssUrl">Url for the RSS feed</param>
        public RssClient(string rssUrl)
        {
            _rssUrl = rssUrl;
        }

        /// <summary> Creates the http web request and sets the response
        /// </summary>
        public void LoadItems()
        {
            var request = (HttpWebRequest)WebRequest.Create(_rssUrl);
            var result = (IAsyncResult)request.BeginGetResponse(ResponseCallback, request);
        }

        /// <summary> Handles the result received from LoadItems()
        /// </summary>
        /// <param name="result"></param>
        void ResponseCallback(IAsyncResult result)
        {
            var request = (HttpWebRequest)result.AsyncState;
            var response = request.EndGetResponse(result);

            var stream = response.GetResponseStream();
            var reader = XmlReader.Create(stream);
            var items = new List<TrafficEvent>(50);

            TrafficEvent item = null;

            while (reader.Read())
            {
                var nodeName = reader.Name;
                var nodeType = reader.NodeType;

                if (nodeName == "item")
                {
                    if (nodeType == XmlNodeType.Element)
                        item = new TrafficEvent();
                    else if (nodeType == XmlNodeType.EndElement)
                        if (item != null)
                        {
                            items.Add(item);
                            item = null;
                        }
                    continue;
                }

                if (nodeType != XmlNodeType.Element)
                    continue;

                if (item == null)

                    continue;

                reader.MoveToContent();
                var nodeValue = reader.ReadElementContentAsString();

                if (nodeName == "title")
                    item.Title = nodeValue;
                else if (nodeName == "description")
                    item.Description = Regex.Replace(nodeValue, @"<(.|\n)*?>", string.Empty);
            }

            if (ItemsReceived != null)
                ItemsReceived(this, items);
            if (items != null)
                App.incidentsList = items;
        }
    }
}
