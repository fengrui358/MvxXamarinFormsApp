using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using MvxXamarinFormsApp.Core.MvxBase.MvxPresentationHint;
using Xamarin.Forms;

namespace MvxXamarinFormsApp.Core.MvxBase
{
    public class MvxFormsPagePresenterEx : MvxFormsPagePresenter
    {
        public MvxFormsPagePresenterEx()
        {
        }

        public MvxFormsPagePresenterEx(Application mvxFormsApp) : base(mvxFormsApp)
        {
        }

        public override void ChangePresentation(MvvmCross.Core.ViewModels.MvxPresentationHint hint)
        {
            if (HandlePresentationChange(hint)) return;

            if (hint is MvxCloseToViewModelPresentationHint)
            {
                var viewModelTypeWantToGoBack = ((MvxCloseToViewModelPresentationHint) hint).ViewModelTypeWantToGoBack;

                var mainPage = MvxFormsApp.MainPage as NavigationPage;

                if (mainPage == null)
                {
                    Mvx.TaggedTrace("MvxFormsPresenter:ChangePresentation()", "Oops! Don't know what to do");
                }
                else
                {
                    if (viewModelTypeWantToGoBack == null)
                    {
                        //想回到根页面
                        mainPage.PopToRootAsync();
                    }
                    else
                    {
                        var navigationStackList = mainPage.Navigation.NavigationStack.ToList();
                        
                        var isFind = false;
                        var toBeRemoveViews = new List<Page>();

                        //翻转列表
                        navigationStackList.Reverse();

                        //第一个页面也是当前页面，不在移除之列
                        if (navigationStackList.Any())
                        {
                            navigationStackList.RemoveAt(0);
                        }

                        foreach (var page in navigationStackList)
                        {
                            if(IsMatchWithViewModelType(page, viewModelTypeWantToGoBack))
                            {
                                isFind = true;
                                break;
                            }
                            else
                            {
                                toBeRemoveViews.Add(page);
                            }
                        }

                        if (isFind)
                        {
                            foreach (var beRemoveView in toBeRemoveViews)
                            {
                                mainPage.Navigation.RemovePage(beRemoveView);
                            }

                            mainPage.PopAsync();
                        }
                    }
                }
            }

            base.ChangePresentation(hint);
        }

        /// <summary>
        /// 传入的Page绑定的ViewModel是否与指定的ViewModel匹配
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModelType"></param>
        /// <returns></returns>
        private bool IsMatchWithViewModelType(Page page, Type viewModelType)
        {
            if (page?.BindingContext != null && viewModelType != null)
            {
                return page.BindingContext.GetType() == viewModelType;
            }

            return false;
        }
    }
}
