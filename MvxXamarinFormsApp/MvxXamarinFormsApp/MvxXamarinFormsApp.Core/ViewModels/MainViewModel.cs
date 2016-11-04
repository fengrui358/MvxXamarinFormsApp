using MvvmCross.Core.ViewModels;
using MvxXamarinFormsApp.Core.Tests.NavigationTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.SqliteTests.ViewModels;

namespace MvxXamarinFormsApp.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MvxCommand NavigateCommand => new MvxCommand(NavigateCommandHandler);
        public MvxCommand SqliteTestCommand => new MvxCommand(SqliteTestCommandHandler);

        private void NavigateCommandHandler()
        {
            ShowViewModel<NavigationTestFirstViewModel>();
        }

        private void SqliteTestCommandHandler()
        {
            ShowViewModel<SqliteTestViewModel>();
        }
    }
}
