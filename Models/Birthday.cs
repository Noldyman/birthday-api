using System;
namespace Birthday_Api.Models
{
    public class Birthday
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}