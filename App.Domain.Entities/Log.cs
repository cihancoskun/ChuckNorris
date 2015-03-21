using System;

namespace App.Domain.Entities
{
    public class Log : BaseEntity
    {
        public DateTime time_stamp { get; set; }
        public string level { get; set; }
        public string logger { get; set; }           // This field will be used if necessary. For now, we will not do any assignment in this field.
        public string message { get; set; }
        public string exception { get; set; }
        public string inner_exception { get; set; }
    }
}
