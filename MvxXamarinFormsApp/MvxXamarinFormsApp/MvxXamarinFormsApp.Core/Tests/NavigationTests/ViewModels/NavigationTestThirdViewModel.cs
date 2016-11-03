using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvxXamarinFormsApp.Core.ViewModels;

namespace MvxXamarinFormsApp.Core.Tests.NavigationTests.ViewModels
{
    public class NavigationTestThirdViewModel : BaseViewModel
    {
        public MvxCommand NavigateGoBackCommand => new MvxCommand(NavigateGoBackCommandHandler);

        public MvxCommand NavigateGoBackToRootCommand => new MvxCommand(NavigateGoBackToRootCommandHandler);

        private void NavigateGoBackCommandHandler()
        {
            CloseToViewModel<NavigationTestFirstViewModel>();
        }

        private void NavigateGoBackToRootCommandHandler()
        {
            CloseToRoot();
        }
    }
}
