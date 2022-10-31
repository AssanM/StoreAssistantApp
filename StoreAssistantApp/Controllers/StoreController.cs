using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using StoreAssistantApp.Models;
using StoreAssistantApp.Services.Interface;

namespace StoreAssistantApp.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _service;

        public StoreController(IStoreService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetMoves();

            return View(data);
        }

        public async Task<IActionResult> DeleteHistory(int HistoryId)
        {
            await _service.DeleteHistory(HistoryId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> AddHistory()
        {
            ViewBag.listOfWarehouses = await _service.GetWarehouses();
            var noms=await _service.GetNomenclatures();
            ViewBag.listOfNom = noms;
            ViewBag.NomMaxCount= noms.Count();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddHistory(MoveHistory history)
        {
            if (ModelState.IsValid)
            {
                var fromW = Request.Form["ddlFromWarhouses"].ToString();
                var toW = Request.Form["ddlToWarhouses"].ToString();
                if (fromW==toW)
                {
                    TempData["Message"] = "Cannot move item from same warehouse";
                    return RedirectToAction("AddHistory");
                }
                List<Tuple<string, string>> data = new List<Tuple<string, string>>();
                var count = await _service.GetNomenclatures();
                for (var i = 1; i <= count.Count(); i++)
                {
                    var nomName = Request.Form["ddlNum"+i].ToString();
                    var nomCount = Request.Form["Count"+i].ToString();
                    if (data.Any(x=>x.Item1==nomName))
                    {
                        TempData["Message"] = "Cannot move same Nomenclatures";
                        return RedirectToAction("AddHistory");
                    }
                    if (nomName!=null && nomCount!=null)
                    {
                        data.Add(new Tuple<string, string>(nomName, nomCount));
                    }    
                }
                history.FromWarehouse = int.Parse(fromW);
                history.ToWarehouse = int.Parse(toW);
                List<MoveHistory> histories = new List<MoveHistory>();
                foreach(var hData in data )
                {
                    var historyInfo = new MoveHistory();
                    historyInfo.FromWarehouse = int.Parse(fromW);
                    historyInfo.ToWarehouse = int.Parse(toW);
                    historyInfo.Nomenclature = int.Parse(hData.Item1);
                    historyInfo.Count = int.Parse(hData.Item2);
                    histories.Add(historyInfo);
                }
                await _service.AddMove(histories);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("AddHistory");

        }

        public async Task<IActionResult> Reports()
        {
            var data = await _service.GetStores();

            return View(data);
        }
    }
}
