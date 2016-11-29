using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.OS;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Droid;
using MvvmCross.Core.ViewModels;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using MvxXamarinFormsApp.Droid.MvxBase;

namespace MvxXamarinFormsApp.Droid
{
    [Activity(Label = "MvxFormsApplicationActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MvxFormsApplicationActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironmentOnUnhandledExceptionRaiser;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            var mvxFormsApp = new MvxFormsApp();
            LoadApplication(mvxFormsApp);

            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsDroidPagePresenterEx;
            presenter.MvxFormsApp = mvxFormsApp;

            //³õÊ¼»¯UserDialogs
            UserDialogs.Init(() => (Activity) Forms.Context);

            Mvx.Resolve<IMvxAppStart>().Start();
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            System.Diagnostics.Debug.WriteLine("¡¾Fatal Error TaskScheduler:¡¿" + unobservedTaskExceptionEventArgs.Exception.Message);
        }

        private void AndroidEnvironmentOnUnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs raiseThrowableEventArgs)
        {
            System.Diagnostics.Debug.WriteLine("¡¾Fatal Error AndroidEnvironment:¡¿" + raiseThrowableEventArgs.Exception.Message);
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            System.Diagnostics.Debug.WriteLine("¡¾Fatal Error AppDomain:¡¿" + ((Exception)unhandledExceptionEventArgs.ExceptionObject).Message);
        }
    }
}