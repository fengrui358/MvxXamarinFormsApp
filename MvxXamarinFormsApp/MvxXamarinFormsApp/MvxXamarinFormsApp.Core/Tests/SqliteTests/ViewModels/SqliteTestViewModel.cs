using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Sqlite;
using MvxXamarinFormsApp.Core.Repository;
using MvxXamarinFormsApp.Core.Tests.NavigationTests.ViewModels;
using MvxXamarinFormsApp.Core.Tests.SqliteTests.Models;
using MvxXamarinFormsApp.Core.ViewModels;

namespace MvxXamarinFormsApp.Core.Tests.SqliteTests.ViewModels
{
    public class SqliteTestViewModel : BaseViewModel
    {
        private MvxObservableCollection<SqliteTestModel> _sqliteTestModels = new MvxObservableCollection<SqliteTestModel>();

        public MvxCommand SearchDataCommand => new MvxCommand(SearchDataCommandHandler);
        public MvxCommand InsertDataCommand => new MvxCommand(InsertDataCommandHandler);

        public MvxObservableCollection<SqliteTestModel> SqliteTestModels
        {
            get { return _sqliteTestModels; }
            set { SetProperty(ref _sqliteTestModels, value); }
        }

        private async void SearchDataCommandHandler()
        {
            //todo:加入分页查询功能
            await Task.Run(() =>
            {
                SqliteTestModels =
                    new MvxObservableCollection<SqliteTestModel>(Mvx.Resolve<IRepository<SqliteTestModel>>().GetAll());
            });
        }

        private async void InsertDataCommandHandler()
        {
            await Task.Run(() =>
            {
                var model = NewRandomTestModel();
                var result = Mvx.Resolve<IRepository<SqliteTestModel>>().Insert(model);

                if (result > 0)
                {
                    //提示成功


                    //插入数据
                    SqliteTestModels.Add(model);
                }
                else
                {
                    //todo:提示失败
                }
            });
        }

        private SqliteTestModel NewRandomTestModel()
        {
            return new SqliteTestModel {Name = Guid.NewGuid().ToString()};
        }
    }
}
