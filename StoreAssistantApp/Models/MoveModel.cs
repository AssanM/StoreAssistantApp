using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StoreAssistantApp.Models
{
	public class MoveModel
	{
        [Key]
        public int HistoryId { get; set; }
        [Display(Name = "From")]
        public string FromWarehouse { get; set; }
        [Display(Name = "To")]
        public string ToWarehouse { get; set; }
        public string Nomenclature { get; set; }
        [Display(Name = "Count of Items")]
        public int Count { get; set; }
        [Display(Name = "Time of operation")]
        public DateTime Time { get; set; }
    }
}
