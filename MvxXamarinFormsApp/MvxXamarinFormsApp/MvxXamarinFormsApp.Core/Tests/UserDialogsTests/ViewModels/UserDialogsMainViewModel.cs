using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvxXamarinFormsApp.Core.ViewModels;

namespace MvxXamarinFormsApp.Core.Tests.UserDialogsTests.ViewModels
{
    public class UserDialogsMainViewModel : BaseViewModel
    {
        public MvxCommand ShowLoadingCommand => new MvxCommand(ShowLoadingCommandHandler);

        private async void ShowLoadingCommandHandler()
        {
            await Task.Run(() =>
            {
                Mvx.Resolve<IUserDialogs>().ShowLoading("加载中……");

                for (int i = 5; i > 0; i--)
                {
                    Task.Delay(1000).Wait();
                }

                Mvx.Resolve<IUserDialogs>().HideLoading();
            });
        }
    }
}
