using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace MvxXamarinFormsApp.Core.Tests.ListViewTests.Models
{
    public class MockModel : MvxNotifyPropertyChanged
    {
        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
