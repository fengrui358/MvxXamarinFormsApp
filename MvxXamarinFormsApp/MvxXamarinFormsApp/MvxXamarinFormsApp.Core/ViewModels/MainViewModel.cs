using MvvmCross.Core.ViewModels;
using MvxXamarinFormsApp.Core.Tests.DevicesInfoTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.FFImageTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.HybridWebTest.ViewModels;
using MvxXamarinFormsApp.Core.Tests.ListViewTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.NavigationTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.SqliteTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.UserDialogsTests.ViewModels;

namespace MvxXamarinFormsApp.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MvxCommand NavigateCommand => new MvxCommand(() => ShowViewModel<NavigationTestFirstViewModel>());
        public MvxCommand SqliteTestCommand => new MvxCommand(() => ShowViewModel<SqliteTestViewModel>());
        public MvxCommand UserDialogsTestCommand => new MvxCommand(() => ShowViewModel<UserDialogsMainViewModel>());
        public MvxCommand FFImageTestCommand => new MvxCommand(() => ShowViewModel<FFImageTestViewModel>());
        public MvxCommand ListViewTestCommand => new MvxCommand(() => ShowViewModel<SimpleListViewModel>());
        public MvxCommand DeviceInfoTestCommand => new MvxCommand(() => ShowViewModel<DevicesInfoTestViewModel>());
        public MvxCommand HybridWebTestCommand => new MvxCommand(() => ShowViewModel<HybridWebTestViewModel>());
    }
}
