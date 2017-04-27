using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DirectTV.Reciever
{
    public class Reciever
    {
        public string IP;
        public string LocationName;
        public string URL;

        public Reciever(string IPAddr)
        {
            this.IP = IPAddr;
            this.URL = "http://" + IPAddr + ":8080/";
            string reqAddr = this.URL + "info/getLocations";
            WebRequest wrGETURL = WebRequest.Create(reqAddr);
            Stream objStream = wrGETURL.GetResponse().GetResponseStream();
            string jsonResp;
            using (StreamReader reader = new StreamReader(objStream, Encoding.UTF8))
                jsonResp = reader.ReadToEnd();
            Dictionary<string, dynamic> locationResp = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonResp);
            this.LocationName = locationResp["locations"][0]["locationName"];
            return;
        }

        public string GetCurrentShowName()
        {
            string reqAddr = this.URL + "tv/getTuned";
            WebRequest wrGETURL = WebRequest.Create(reqAddr);
            try
            {
                Stream objStream = wrGETURL.GetResponse().GetResponseStream();
                string jsonResp;
                using (StreamReader reader = new StreamReader(objStream, Encoding.UTF8))
                    jsonResp = reader.ReadToEnd();
                Dictionary<string, dynamic> locationResp = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonResp);
                return locationResp["title"];
            }
            catch(Exception) { }
            return "??";
        }

        public bool PressRemoteKey(string key)
        {
            string reqAddr = this.URL + "remote/processKey?key=" + key;
            WebRequest wrGETURL = WebRequest.Create(reqAddr);
            wrGETURL.Timeout = 60;
            try
            {
                Stream objStream = wrGETURL.GetResponse().GetResponseStream();
                return true;
            }
            catch(Exception) { }
            return false;
        }
    }
}
