using SQLite;

namespace CrispySpoon.Models
{
    public class BaseEntity : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
