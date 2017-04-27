using System.Windows;
using System.Windows.Input;
using DirectTV;
using DirectTV.Reciever;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Threading;

namespace DTVRemote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DirectTV.DirectTV DTV = new DirectTV.DirectTV();//new Reciever("192.168.1.18");

        public MainWindow()
        {
            InitializeComponent();
            var bw = new BackgroundWorker();
            bw.DoWork += (o, args) => showTitleUpdateTimer();
            bw.RunWorkerAsync();
        }

        private void showTitleUpdateTimer()
        {
            while (true)
            {
                Thread.Sleep(1000 * 30);//sleep for 30 seconds
                ShowInformationTXTBLK.Dispatcher.Invoke(UpdateTunedShow);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private void UpdateTunedShow()
        {
            if (DTV.hasReciever)
                ShowInformationTXTBLK.Text = DTV.Reciever.GetCurrentShowName();
        }

        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SettingsBTN_Click(object sender, RoutedEventArgs e)
        { 
            Window settingsWin = new SettingsWindow(DTV);
            settingsWin.Show();
        }

        private void LeftArrowBTN_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.LEFT);
        }

        private void UpArrowBTN_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.UP);
        }

        private void DownArrowBTN_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.DOWN);
        }

        private void RightArrowBTN_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.RIGHT);
        }

        private void OneBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.ONE);
        }

        private void TwoBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.TWO);
        }

        private void ThreeBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.THREE);
        }

        private void FourBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.FOUR);
        }

        private void FiveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.FIVE);
        }

        private void SixBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.SIX);
        }

        private void SevenBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.SEVEN);
        }

        private void EightBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.EIGHT);
        }

        private void NineBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.NINE);
        }

        private void DashBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.DASH);
        }

        private void ZeroBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.ZERO);
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.ENTER);
        }

        private void PageDownBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.CHANNELDOWN);
        }

        private void PageUpBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.CHANNELUP);
        }

        private void PreviousBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.PREVIOUS);
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.BACK);
        }

        private void RedBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.RED);
        }

        private void GreenBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.GREEN);
        }

        private void YellowBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.YELLOW);
        }

        private void BlueBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.BLUE);
        }

        private void SelectBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.SELECT);
        }

        private void PlayBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.PLAY);
        }

        private void FastForwardBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.FASTFORWARD);
        }

        private void PauseBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.PAUSE);
        }

        private void RewindBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.REWIND);
        }

        private void StopBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.STOP);
        }

        private void ReplayBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.REPLAY);
        }

        private void SkipBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.ADVANCE);
        }

        private void MenuBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.MENU);
        }

        private void GuideBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.GUIDE);
        }

        private void ListBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.LIST);
        }

        private void InformationBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.INFORMATION);
        }

        private void ActiveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.ACTIVE);
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DTV.hasReciever)
                DTV.Reciever.PressRemoteKey(DirectTV.Remote.Keys.EXIT);
        }
    }
}
