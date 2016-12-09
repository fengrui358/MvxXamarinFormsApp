using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using FFImageLoading;
using FFImageLoading.Config;
using FFImageLoading.Helpers;
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

            InitDefaultImage();
            RegisterComponents();
            InitDataBase();
            RegisterAppStart<ViewModels.MainViewModel>();
        }

        private async void InitDefaultImage()
        {
            await Task.Run(() =>
            {
                var config = new Configuration
                {
                    VerboseLogging = false,
                    VerbosePerformanceLogging = false,
                    VerboseMemoryCacheLogging = false,
                    VerboseLoadingCancelledLogging = false,
                    Logger = new FFImageLogger()
                };
                ImageService.Instance.Initialize(config);

                ImageService.Instance.LoadCompiledResource("loading.png").Preload();
                ImageService.Instance.LoadCompiledResource("error.png").Preload();
                ImageService.Instance.LoadUrl("http://loremflickr.com/600/600/nature?filename=simple.jpg").DownloadOnly();
            });
        }

        private async void InitDataBase()
        {
            //初始化数据库相关内容
            await Task.Run(() =>
            {
                Mvx.RegisterSingleton(typeof(IRepository<SqliteTestModel>), () => new SqliteTestRepository());
            });
        }

        private void RegisterComponents()
        {
            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
        }

        public class FFImageLogger : IMiniLogger
        {
            public void Debug(string message)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }

            public void Error(string errorMessage)
            {
                System.Diagnostics.Debug.WriteLine(errorMessage);
            }

            public void Error(string errorMessage, Exception ex)
            {
                Error(errorMessage + Environment.NewLine + ex.ToString());
            }
        }
    }
}
