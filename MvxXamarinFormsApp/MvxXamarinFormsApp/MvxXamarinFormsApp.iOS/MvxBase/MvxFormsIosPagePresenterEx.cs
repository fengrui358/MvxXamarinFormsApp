using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MvvmCross.Core.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.iOS.Views;
using MvxXamarinFormsApp.Core.MvxBase;
using UIKit;
using Xamarin.Forms;

namespace MvxXamarinFormsApp.iOS.MvxBase
{
    public class MvxFormsIosPagePresenterEx : MvxFormsPagePresenterEx, IMvxIosViewPresenter, IMvxViewPresenter,
        IMvxCanCreateIosView, IMvxIosModalHost
    {
        private readonly UIWindow _window;

        public MvxFormsIosPagePresenterEx(UIWindow window, Xamarin.Forms.Application mvxFormsApp)
            : base(mvxFormsApp)
        {
            this._window = window;
        }

        public virtual bool PresentModalViewController(UIViewController controller, bool animated)
        {
            return false;
        }

        public virtual void NativeModalViewControllerDisappearedOnItsOwn()
        {
        }

        protected override void CustomPlatformInitialization(NavigationPage mainPage)
        {
            this._window.RootViewController = mainPage.CreateViewController();
        }
    }
}