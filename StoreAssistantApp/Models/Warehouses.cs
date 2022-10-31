using System.ComponentModel.DataAnnotations;

namespace StoreAssistantApp.Models
{
    public class Warehouses
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }    
    }
}
