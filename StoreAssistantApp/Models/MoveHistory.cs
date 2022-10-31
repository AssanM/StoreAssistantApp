using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace StoreAssistantApp.Models
{
    public class MoveHistory
    {
        [Key]
        public int HistoryId { get; set; }
        [Display(Name ="From")]
        public int FromWarehouse { get; set; }
        [Display(Name ="To")]
        public int ToWarehouse { get; set; }
        public int Nomenclature { get; set; }
        [Display(Name ="Count of Items")]
        public int Count { get; set; }
        [Display(Name ="Time of operation")]
        public DateTime Time { get; set; }
    }
}
