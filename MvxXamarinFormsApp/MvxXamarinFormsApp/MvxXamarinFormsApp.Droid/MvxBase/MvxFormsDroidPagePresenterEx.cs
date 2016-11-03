using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Forms.Presenter.Droid;
using MvxXamarinFormsApp.Core.MvxBase;

namespace MvxXamarinFormsApp.Droid.MvxBase
{
    public class MvxFormsDroidPagePresenterEx : MvxFormsPagePresenterEx, IMvxAndroidViewPresenter, IMvxViewPresenter
    {
        public MvxFormsDroidPagePresenterEx()
        {
        }

        public MvxFormsDroidPagePresenterEx(MvxFormsApp mvxFormsApp) : base(mvxFormsApp)
        {
        }
    }
}