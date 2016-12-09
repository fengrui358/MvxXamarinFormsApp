using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace MvxXamarinFormsApp.Core.UI.Controllers
{
    public class DefaultCachedImage : CachedImage
    {
        public DefaultCachedImage()
        {
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            CacheDuration = TimeSpan.FromDays(30);
            DownsampleToViewSize = true;
            RetryCount = 0;
            RetryDelay = 250;
            BitmapOptimizations = true;
            LoadingPlaceholder = "loading.png";
            ErrorPlaceholder = "error.png";
        }
    }
}
