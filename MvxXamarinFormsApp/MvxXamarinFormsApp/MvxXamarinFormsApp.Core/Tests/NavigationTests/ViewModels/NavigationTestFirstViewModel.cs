using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using MvxXamarinFormsApp.Core.ViewModels;

namespace MvxXamarinFormsApp.Core.Tests.NavigationTests.ViewModels
{
    public class NavigationTestFirstViewModel : BaseViewModel
    {
        public MvxCommand NavigateToSecondCommand => new MvxCommand(NavigateToSecondCommandHandler);
        public MvxCommand NavigateGoBackCommand => new MvxCommand(NavigateGoBackCommandHandler);
        public MvxCommand NavigateGoBackToRootCommand => new MvxCommand(NavigateGoBackToRootCommandHandler);

        private void NavigateToSecondCommandHandler()
        {
            ShowViewModel<NavigationTestSecondViewModel>();
        }

        private void NavigateGoBackCommandHandler()
        {
            Close();
        }

        private void NavigateGoBackToRootCommandHandler()
        {
            CloseToRoot();
        }
    }
}
