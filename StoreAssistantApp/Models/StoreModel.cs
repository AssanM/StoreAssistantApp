using System.ComponentModel.DataAnnotations;

namespace StoreAssistantApp.Models
{
	public class StoreModel
    {
        [Key]
        public int Id { get; set; }
        public string Warehouse { get; set; }

        public string Nomenclature { get; set; }
        [Display(Name = "Stock balance")]
        public int Count { get; set; }
        [Display(Name ="Updated DateTime")]
        public DateTime Time { get; set; }
    }
}
