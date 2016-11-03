using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace MvxXamarinFormsApp.Core.MvxBase.MvxPresentationHint
{
    public class MvxCloseToViewModelPresentationHint : MvvmCross.Core.ViewModels.MvxPresentationHint
    {
        public IMvxViewModel ViewModelToClose { get; private set; }

        /// <summary>
        /// 想返回到的ViewModel的Type，如果为null，则表示想返回到根页面
        /// </summary>
        public Type ViewModelTypeWantToGoBack { get; private set; }

        /// <summary>
        /// 返回到指定的ViewModel页面
        /// </summary>
        /// <param name="viewModelToClose"></param>
        /// <param name="viewModelTypeWantToGoBack"></param>
        public MvxCloseToViewModelPresentationHint(IMvxViewModel viewModelToClose, Type viewModelTypeWantToGoBack = null)
        {
            ViewModelToClose = viewModelToClose;
            ViewModelTypeWantToGoBack = viewModelTypeWantToGoBack;
        }
    }
}
