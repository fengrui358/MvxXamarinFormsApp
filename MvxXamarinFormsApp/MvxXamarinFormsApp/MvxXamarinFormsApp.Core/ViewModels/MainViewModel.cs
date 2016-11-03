using MvvmCross.Core.ViewModels;
using MvxXamarinFormsApp.Core.Tests.NavigationTests.ViewModels;

namespace MvxXamarinFormsApp.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MvxCommand NavigateCommand => new MvxCommand(NavigateCommandHandler);

        private void NavigateCommandHandler()
        {
            ShowViewModel<NavigationTestFirstViewModel>();
        }
    }
}
