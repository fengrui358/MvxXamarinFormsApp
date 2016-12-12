using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvxXamarinFormsApp.Core.Tests.ListViewTests.Models;
using MvxXamarinFormsApp.Core.ViewModels;

namespace MvxXamarinFormsApp.Core.Tests.ListViewTests.ViewModels
{
    public class SimpleListViewModel : BaseViewModel
    {
        private MvxObservableCollection<MockModel> _listSource;

        private bool _isRefreshing;

        public MvxObservableCollection<MockModel> ListSource
        {
            get { return _listSource; }
            set { SetProperty(ref _listSource, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public MvxCommand RefreshCommand => new MvxCommand(RefreshCommandHandler);

        public override void Start()
        {
            ListSource = new MvxObservableCollection<MockModel>(GetDatas());

            base.Start();
        }

        private void RefreshCommandHandler()
        {
            try
            {
                ListSource = new MvxObservableCollection<MockModel>(GetDatas());
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private IEnumerable<MockModel> GetDatas()
        {
            var tempDatas = new List<MockModel>();
            for (int i = 0; i < 100; i++)
            {
                tempDatas.Add(new MockModel
                {
                    ImageUrl = "http://7xtg95.com1.z0.glb.clouddn.com/8.jpg",
                    Title = $"Title:{Guid.NewGuid().ToString().Substring(0, 5)}",
                    Description = $"Description:{Guid.NewGuid().ToString().Substring(0, 5)}"
                });
            }

            return tempDatas;
        }
    }
}
