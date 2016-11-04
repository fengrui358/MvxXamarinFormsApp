using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using Xamarin.Forms;
using MvvmCross.Platform;
using MvvmCross.Plugins.Sqlite;
using MvxXamarinFormsApp.Core.Repository;
using MvxXamarinFormsApp.Core.Tests.SqliteTests.DataRepositories;
using MvxXamarinFormsApp.Core.Tests.SqliteTests.Models;

namespace MvxXamarinFormsApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes().
                EndingWith("Repository")
                .AsTypes()
                .RegisterAsLazySingleton();

            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
            {
                Resources.AppResources.Culture = Mvx.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();
            }

            InitDataBase();
            RegisterAppStart<ViewModels.MainViewModel>();
        }

        private async void InitDataBase()
        {
            //初始化数据库相关内容
            await Task.Run(() =>
            {
                Mvx.RegisterSingleton(typeof(IRepository<SqliteTestModel>), () => new SqliteTestRepository());
            });
        }
    }
}
