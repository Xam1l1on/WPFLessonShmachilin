using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFLessonShmachilin.Infrastructure.Command;

namespace WPFLessonShmachilin.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// Заголовок окна
        /// </summary>
        private string _title = "Самое лучшее приложение";
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title { get => _title; set => SetField(ref _title, value); }

        public MainWindowViewModel() 
        {
            LoadCommand();
        }

        #region Commands
        public ICommand CloseAppCommand { get; private set; }
        private bool CanCloseAppCommandExecute(object p) => true;
        private void OnCloseAppCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion
        public void LoadCommand()
        {
            CloseAppCommand = new RelayCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
        }
    }
}
