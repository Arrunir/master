using System;
using System.Threading;
using System.Threading.Tasks;
using static DarkSouls3SaveFileBackUp.AppConstants;

namespace DarkSouls3SaveFileBackUp.FileReader
{
    internal class AutomaticBackUpController
    {
        private DateTime _lastBackUp;
        private const int _retryIntervall = 5;
        private BackUpController _backUpController;
        private int _currentIntervall;

        internal AutomaticBackUpController(BackUpController backUpController)
        {
            _backUpController = backUpController;
            _currentIntervall = Settings.BackUpIntervall;
            _lastBackUp = new DateTime(1900, 1, 1);
        }

        public event EventHandler<SaveDataBackedUpEventArgs> BackedUp;

        public async Task RunAutomaticBackUp(CancellationToken cancellationToken)
        {
            await Task.Factory.StartNew(() => BackUpInternal(cancellationToken), cancellationToken);
        }

        private void BackUpInternal(CancellationToken cancellationToken)
        {
            while (true)
            {
                Thread.Sleep(_retryIntervall * 1000);
                cancellationToken.ThrowIfCancellationRequested();

                var span = DateTime.Now - _lastBackUp;
                if (span.TotalSeconds >= _currentIntervall)
                {
                    BackUp();
                }
            }
        }

        private void BackUp()
        {
            if (_backUpController.BackUpSaveData())
            {
                BackedUp?.Invoke(this, new SaveDataBackedUpEventArgs(_backUpController.LastBackUpPath, DateTime.Now));
                RestIntervall();
                _lastBackUp = DateTime.Now;
                return;
            }

            _currentIntervall = _retryIntervall;
            _lastBackUp = DateTime.Now;
        }

        private void RestIntervall()
        {
            if (_currentIntervall == _retryIntervall)
            {
                _currentIntervall = Settings.BackUpIntervall;
            }
        }
    }
}
