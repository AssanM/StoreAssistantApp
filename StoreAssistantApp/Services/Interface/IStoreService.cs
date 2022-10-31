using Microsoft.Build.Framework;
using StoreAssistantApp.Models;

namespace StoreAssistantApp.Services.Interface
{
    public interface IStoreService
    {
        Task<IEnumerable<MoveModel>> GetMoves();
        Task<MoveHistory?> GetMoveHistory(int id);
        Task<bool> DeleteHistory(int id);
        Task<bool> AddMove(List<MoveHistory> histories);
        Task<IEnumerable<StoreModel>> GetStores();
        Task<Nomenclatures> PostNomenclatures(Nomenclatures nomenclatures);
        Task<Nomenclatures?> GetNomenclatures(int id);
        
        Task<Warehouses> PostWarehouses(Warehouses warehouses);
        Task<Warehouses?> GetWarehouses(int id);
        Task<StoreHouse> PostStoreHouse(StoreHouse storeHouse);
        Task<IEnumerable<Warehouses>> GetWarehouses();
        Task<IEnumerable<Nomenclatures>> GetNomenclatures();
    }
}
