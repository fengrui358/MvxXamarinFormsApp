using System.Globalization;

namespace MvxXamarinFormsApp.Core.Services
{
    public interface ILocalizeService
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
