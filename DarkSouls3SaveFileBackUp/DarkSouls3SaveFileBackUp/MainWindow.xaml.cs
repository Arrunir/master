using DarkSouls3SaveFileBackUp.FileReader;
using System;
using System.ComponentModel;
using System.Windows;
using static DarkSouls3SaveFileBackUp.AppConstants;
using System.Threading;

namespace DarkSouls3SaveFileBackUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackUpController _backUpController;
        private AutomaticBackUpController _automaticBackUpController;
        private BackgroundWorker _worker;
        private CancellationTokenSource _tokenSource;
        private bool _running;

        public MainWindow()
        {
            _backUpController = new BackUpController();
            _automaticBackUpController = new AutomaticBackUpController(_backUpController);
            _automaticBackUpController.BackedUp += AutomaticBackUpController_BackedUp;
            _worker = new BackgroundWorker();
            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            _tokenSource = new CancellationTokenSource();
            InitializeComponent();

            if(RunOnStartUp)
            {
                Start();
            }
        }

        public string SaveIntervall
        {
            get { return GetSaveIntervall(); }
            set { SetSaveIntervall(value); }
        }

        public bool RunOnStartUp
        {
            get { return GetRunOnStartUp(); }
            set { SetRunOnStartUp(value); }
        }

        private async void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(_running)
            {
                _tokenSource.Cancel();
                _running = false;
            }

            try
            {
                await _automaticBackUpController.RunAutomaticBackUp(_tokenSource.Token);
                _running = true;
            }
            catch(OperationCanceledException)
            {
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _running = false;
        }

        private void AutomaticBackUpController_BackedUp(object sender, SaveDataBackedUpEventArgs e)
        {
            var text = string.Format("{0:dd.MM.yyyy HH:mm:ss.fff}: Backed up Save Data to {1}", e.TimeOfBackUp, e.SaveFilePath);
            InfoText.Dispatcher.Invoke(new Action(() => InfoText.Text = text));
        }

        private void SetSaveIntervall(string value)
        {
            var intervall = int.Parse(value);
            Settings.BackUpIntervall = intervall * 60;
            Settings.Save();
        }

        private void SetRunOnStartUp(bool value)
        {
            Settings.RunOnStartUp = value;
            Settings.Save();
        }

        private bool GetRunOnStartUp()
        {
            return Settings.RunOnStartUp;
        }

        private string GetSaveIntervall()
        {
            var intervall = Settings.BackUpIntervall / 60;
            return intervall.ToString();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        private void Start()
        {
            _worker.RunWorkerAsync();
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }

        private void Stop()
        {
            _tokenSource.Cancel();
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
        }
    }
}
