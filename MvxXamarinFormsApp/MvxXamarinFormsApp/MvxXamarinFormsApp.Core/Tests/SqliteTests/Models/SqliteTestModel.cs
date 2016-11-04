using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvxXamarinFormsApp.Core.Model;
using SQLite.Net.Attributes;

namespace MvxXamarinFormsApp.Core.Tests.SqliteTests.Models
{
    public class SqliteTestModel : BaseModel
    {
        public virtual string Name { get; set; }
    }
}
