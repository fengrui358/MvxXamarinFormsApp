using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using SQLite.Net.Attributes;

namespace MvxXamarinFormsApp.Core.Tests.SqliteTests.Models
{
    public class SqliteTestModel : MvxNotifyPropertyChanged
    {
        [PrimaryKey]
        [AutoIncrement]
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}
