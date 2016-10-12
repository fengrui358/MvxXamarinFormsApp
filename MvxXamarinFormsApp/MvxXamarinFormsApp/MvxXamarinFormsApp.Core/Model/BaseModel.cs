using SQLite.Net.Attributes;

namespace MvxXamarinFormsApp.Core.Model
{
    public class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
