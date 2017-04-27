using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using DirectTV.Reciever;
using System.Text;
using Newtonsoft.Json;

namespace DirectTV
{
    /// <summary>
    /// Class for accessing DirectTV functions
    /// </summary>
    public class DirectTV
    {
        public Reciever.Reciever Reciever = null;

        public bool hasReciever
        {
            get
            {
                return Reciever != null;
            }
            set {; }
        }
    }
}
