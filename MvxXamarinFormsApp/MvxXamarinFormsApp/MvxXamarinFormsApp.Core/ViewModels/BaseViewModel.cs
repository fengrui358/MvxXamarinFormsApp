using System;
using System.Reflection;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvxXamarinFormsApp.Core.MvxBase.MvxPresentationHint;

namespace MvxXamarinFormsApp.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private string _title;
        private bool _isBusy;

        public BaseViewModel()
        {
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        protected bool Close()
        {
            return base.Close(this);
        }

        protected void CloseToViewModel<T>() where T : IMvxViewModel
        {
            CloseToViewModel(typeof(T));
        }

        protected void CloseToViewModel(Type viewModelType)
        {
            if (!typeof(IMvxViewModel).IsAssignableFrom(viewModelType))
            {
                Mvx.Trace(MvxTraceLevel.Error, $"{nameof(viewModelType)}类型错误");
            }
            else
            {
                ViewDispatcher.ChangePresentation(new MvxCloseToViewModelPresentationHint(this, viewModelType));
            }
        }

        protected bool CloseToRoot()
        {
            return ViewDispatcher.ChangePresentation(new MvxCloseToViewModelPresentationHint(this));
        }
    }
}
