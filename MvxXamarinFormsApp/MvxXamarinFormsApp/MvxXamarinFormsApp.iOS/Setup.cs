﻿using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using UIKit;
using Xamarin.Forms;
using MvvmCross.Forms.Presenter.iOS;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using MvxXamarinFormsApp.iOS.MvxBase;

namespace MvxXamarinFormsApp.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.RegisterSingleton<Core.Services.ILocalizeService>(new Services.LocalizeService());
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            Forms.Init();

            var xamarinFormsApp = new MvxFormsApp();

            return new MvxFormsIosPagePresenterEx(Window, xamarinFormsApp);
        }
    }
}
