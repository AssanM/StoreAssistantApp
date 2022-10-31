using System.ComponentModel.DataAnnotations;

namespace StoreAssistantApp.Models
{
    public class StoreHouse
    {
        [Key]
        public int Id { get; set; }
        public int Warehouse { get; set; }

        public int Nomenclature { get; set; }
        public int Count { get; set; }
        public DateTime Time { get; set; }

    }
}
