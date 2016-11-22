using MvvmCross.Core.ViewModels;
using MvxXamarinFormsApp.Core.Tests.NavigationTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.SqliteTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.UserDialogsTests.ViewModels;

namespace MvxXamarinFormsApp.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MvxCommand NavigateCommand => new MvxCommand(NavigateCommandHandler);
        public MvxCommand SqliteTestCommand => new MvxCommand(SqliteTestCommandHandler);
        public MvxCommand UserDialogsTestCommand => new MvxCommand(UserDialogsTestCommandHandler);

        private void NavigateCommandHandler()
        {
            ShowViewModel<NavigationTestFirstViewModel>();
        }

        private void SqliteTestCommandHandler()
        {
            ShowViewModel<SqliteTestViewModel>();
        }

        private void UserDialogsTestCommandHandler()
        {
            ShowViewModel<UserDialogsMainViewModel>();
        }
    }
}
