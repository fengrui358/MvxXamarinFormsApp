using MvvmCross.Core.ViewModels;
using MvxXamarinFormsApp.Core.Tests.DevicesInfoTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.FFImageTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.ListViewTests.ViewModels;
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
        public MvxCommand FFImageTestCommand => new MvxCommand(FFImageTestCommandHandler);
        public MvxCommand ListViewTestCommand => new MvxCommand(ListViewTestCommandHandler);
        public MvxCommand DeviceInfoTestCommand => new MvxCommand(DeviceInfoTestCommandHandler);

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

        private void FFImageTestCommandHandler()
        {
            ShowViewModel<FFImageTestViewModel>();
        }

        private void ListViewTestCommandHandler()
        {
            ShowViewModel<SimpleListViewModel>();
        }

        private void DeviceInfoTestCommandHandler()
        {
            ShowViewModel<DevicesInfoTestViewModel>();
        }
    }
}
