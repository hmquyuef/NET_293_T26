using System.ComponentModel.DataAnnotations;

namespace NET_293_T26.Models.Entities
{
    public class Demo1
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
