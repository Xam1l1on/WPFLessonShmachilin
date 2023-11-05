using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFLessonShmachilin.ViewModel
{
    internal abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanaged([CallerMemberName] string PropertyName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        protected virtual bool SetField<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if(Equals(field, value)) return false;
            field = value;
            OnPropertyChanaged(PropertyName);
            return true;
        }
        #region Relize Dispose
        private bool _Disposed;
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool Disposing) 
        {
            if (!Disposing || _Disposed) return;
            _Disposed = true;
        }
        #endregion
    }
}
