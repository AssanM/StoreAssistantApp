using Microsoft.EntityFrameworkCore;
using StoreAssistantApp.Models;
using StoreAssistantApp.Services.Interface;

namespace StoreAssistantApp.Services.Implementation
{
    public class StoreService : IStoreService
    {
        private readonly StoreDbContext _context;

        public StoreService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<MoveHistory?> GetMoveHistory(int id)=>await _context.MoveHistories.FindAsync(id);

        public async Task<IEnumerable<MoveModel>> GetMoves()
        {
            var data=await _context.MoveHistories.ToListAsync();
            List<MoveModel> models = new List<MoveModel>();
            foreach (var item in data)
            {
                var model = new MoveModel();
                model.FromWarehouse = _context.Warehouses.FirstOrDefault(x=>x.Id==item.FromWarehouse).Name;
                model.ToWarehouse = _context.Warehouses.FirstOrDefault(x => x.Id == item.ToWarehouse).Name;
                model.Nomenclature = _context.Nomenclatures.FirstOrDefault(x => x.Id == item.Nomenclature).Name;
                model.HistoryId = item.HistoryId;
                model.Time=item.Time;
                model.Count = item.Count;
                models.Add(model);
            }    
            return models.ToList();
        }
        public async Task<bool> AddMove(List<MoveHistory> histories)
        {
            foreach (var history in histories)
            {
                var moveFrom = _context.StoreHouses.FirstOrDefault(x => x.Warehouse == history.FromWarehouse && x.Nomenclature == history.Nomenclature);
                var moveTo = _context.StoreHouses.FirstOrDefault(x => x.Warehouse == history.ToWarehouse && x.Nomenclature == history.Nomenclature);
                if (moveFrom == null)
                {
                    StoreHouse from = new StoreHouse();
                    from.Warehouse = history.FromWarehouse;
                    from.Nomenclature = history.Nomenclature;
                    from.Count -= history.Count;
                    from.Time = DateTime.Now;
                    _context.StoreHouses.Add(from);

                }
                else
                {
                    moveFrom.Count -= history.Count;
                    moveFrom.Time = DateTime.Now;
                    _context.Entry(moveFrom).State = EntityState.Modified;
                }

                if (moveTo == null)
                {
                    StoreHouse to = new StoreHouse();
                    to.Warehouse = history.ToWarehouse;
                    to.Nomenclature = history.Nomenclature;
                    to.Count += history.Count;
                    to.Time = DateTime.Now;
                    _context.StoreHouses.Add(to);
                }
                else
                {
                    moveTo.Count += history.Count;
                    moveTo.Time = DateTime.Now;

                    _context.Entry(moveTo).State = EntityState.Modified;
                }

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

                history.Time = DateTime.Now;
                _context.MoveHistories.Add(history);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IEnumerable<StoreModel>> GetStores()
        {
            var data = await _context.StoreHouses.ToListAsync();
            List<StoreModel> models = new List<StoreModel>();
            foreach (var item in data)
            {
                var model = new StoreModel();
                model.Warehouse = _context.Warehouses.FirstOrDefault(x => x.Id == item.Warehouse).Name;
                model.Nomenclature = _context.Nomenclatures.FirstOrDefault(x => x.Id == item.Nomenclature).Name;
                model.Id = item.Id;
                model.Time = item.Time;
                model.Count = item.Count;
                models.Add(model);
            }
            return models.ToList();
        }

        public async Task<Nomenclatures> PostNomenclatures(Nomenclatures nomenclatures)
        {
            _context.Nomenclatures.Add(nomenclatures);
            await _context.SaveChangesAsync();
            return nomenclatures;
        }

        public async Task<Warehouses> PostWarehouses(Warehouses warehouses)
        {
            _context.Warehouses.Add(warehouses);
            await _context.SaveChangesAsync();
            return warehouses;
        }

        public async Task<StoreHouse> PostStoreHouse(StoreHouse storeHouse)
        {
            _context.StoreHouses.Add(storeHouse);
            await _context.SaveChangesAsync();
            return storeHouse;
        }
        public async Task<bool> DeleteHistory(int id)
        {
            var history = await _context.MoveHistories.FindAsync(id);
            if (history == null)
                return false;
            _context.MoveHistories.Remove(history);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Warehouses>> GetWarehouses()=>await _context.Warehouses.ToListAsync();
        
        public async Task<IEnumerable<Nomenclatures>> GetNomenclatures()=>await _context.Nomenclatures.ToListAsync();

        public async Task<Nomenclatures?> GetNomenclatures(int id) => await _context.Nomenclatures.FindAsync(id);
        public async Task<Warehouses?> GetWarehouses(int id) => await _context.Warehouses.FindAsync(id);

    }
}
