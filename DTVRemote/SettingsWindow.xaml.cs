using DirectTV.Reciever;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DTVRemote
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public List<Reciever> Recievers;
        private DirectTV.DirectTV DTV = null;

        public bool CancelScan = false;

        public bool _isScanning = true;
        public bool isScanning
        {
            get
            {
                return _isScanning;
            }
            set
            {
                ScanningIndicator.Fill = value ? Brushes.Green : Brushes.Red;
                ScanningUserNotificationLBL.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                if (value)
                    RecieversComboBX.Items.Clear();
                _isScanning = value;
            }
        }

        public SettingsWindow(DirectTV.DirectTV DTV)
        {
            this.DTV = DTV;
            InitializeComponent();
            Recievers = new List<Reciever>();
            var bw = new BackgroundWorker();
            setIsScanning(true);
            bw.DoWork += (o, args) => scanForRecievers();
            bw.RunWorkerCompleted += (o, args) => setIsScanning(false);
            bw.RunWorkerAsync();
        }

        private void CurrentRecieverTXTBX_Loaded(object sender, RoutedEventArgs e)
        {
            updateCurrentRecieverTextBox();
        }

        private void updateCurrentRecieverTextBox()
        {
            CurrentRecieverTXTBX.Content = DTV.hasReciever ? DTV.Reciever.LocationName : "NONE";
        }

        private void RecieversComboBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;
            ComboBoxItem selectedItem = (ComboBoxItem)e.AddedItems[0];
            DTV.Reciever = Recievers.Where(x => x.LocationName == (string)selectedItem.Content).First();
            updateCurrentRecieverTextBox();
        }

        private string getLocalIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        private bool ping(string host, int attempts, int timeout)
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingReply;
            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    pingReply = ping.Send(host, timeout);

                    // If there is a successful ping then return true.
                    if (pingReply != null &&
                        pingReply.Status == System.Net.NetworkInformation.IPStatus.Success)
                        return true;
                }
                catch
                {
                    // Do nothing and let it try again until the attempts are exausted.
                    // Exceptions are thrown for normal ping failurs like address lookup
                    // failed.  For this reason we are supressing errors.
                }
            }
            // Return false if we can't successfully ping the server after several attempts.
            return false;
        }

        private bool validateRecieverAddress(string IPAddr)
        {
            string sURL = "http://" + IPAddr + ":8080/";
            string reqAddr = sURL + "info/getLocations";
            WebRequest wrGETURL = WebRequest.Create(reqAddr);
            try
            {
                Stream objStream = wrGETURL.GetResponse().GetResponseStream();
                return true;
            }
            catch (Exception) { }
            return false;
        }

        public void scanForRecievers()
        {
            string ipString = getLocalIP();
            if (ipString == "?")
                throw new NotImplementedException();
            while (ipString[ipString.Length - 1] != '.')//back up to period
                ipString = ipString.Remove(ipString.Length - 1, 1);
            for (int i = 0; i < 256; i++)//all ips in range
                if (!CancelScan && ping(ipString + i.ToString(), 1, 1))
                    if (validateRecieverAddress(ipString + i.ToString()))
                    {
                        Reciever rcvr = new Reciever(ipString + i.ToString());
                        Recievers.Add(rcvr);//try to get reciever location as final alive test
                        RecieversComboBX.Dispatcher.Invoke((Action<Reciever>)addReciever, rcvr);
                    }
            CancelScan = false;
        }

        public void addReciever(Reciever rcvr)
        {
            ComboBoxItem cbi = new ComboBoxItem();
            cbi.Content = rcvr.LocationName;
            RecieversComboBX.Items.Add(cbi);
        }

        public void setIsScanning(bool started)
        {
            isScanning = started;
        }

        private void CancelScanBTN_Click(object sender, RoutedEventArgs e)
        {
            CancelScan = true;
        }
    }
}
