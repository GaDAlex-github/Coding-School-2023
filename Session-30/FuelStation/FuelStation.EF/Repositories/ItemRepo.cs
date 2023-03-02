using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FuelStation.EF.Repositories {

    public class ItemRepo : IItemRepo<Item> {
        public void Add(Item entity) {
            using var context = new FuelStationDbContext();
            context.Add(entity);
            context.SaveChanges();
        }
        public void Delete(int id) {
            using var context = new FuelStationDbContext();
            var ItemDb = context.Items
                .Where(item => item.Id == id)
                .SingleOrDefault();
            if (ItemDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            context.Remove(ItemDb);
            context.SaveChanges();
        }
        public IList<Item> GetAll() {
            using var context = new FuelStationDbContext();
            return context.Items
                .Include(item => item.TransactionLines)
                .ToList();
        }
        public Item? GetById(int id) {
            using var context = new FuelStationDbContext();
            return context.Items
                .Where(item => item.Id == id)
                .Include(item => item.TransactionLines)
                .SingleOrDefault();
        }
        public void Update(int id, Item entity) {
            using var context = new FuelStationDbContext();
            var ItemDb = context.Items
                .Where(item => item.Id == id)
                .SingleOrDefault();
            if (ItemDb is null) throw new KeyNotFoundException($"Given id '{id}' was not found");
            ItemDb.Code = entity.Code;
            ItemDb.Description = entity.Description;
            ItemDb.ItemType = entity.ItemType;
            ItemDb.Price = entity.Price;
            ItemDb.Cost = entity.Cost;
            context.SaveChanges();
        }
        public string CodeCreate() {
            using var context = new FuelStationDbContext();
            var max = context.Items.Max(item => item.Code);
            if (max == null)
                max = "10000";
            max = Regex.Replace(max, "\\d+",
            m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
            return max;
        }
    }
}


