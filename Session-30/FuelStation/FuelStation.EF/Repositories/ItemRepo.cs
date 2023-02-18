using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories {

    public class ItemRepo : IEntityRepo<Item> {
        public void Add(Item entity) {
            using var context = new FuelStationDbContext();
            context.Add(entity);
            context.SaveChanges();
        }
        public void Delete(int id) {
            using var context = new FuelStationDbContext();
            var ItemDb = context.Items
                .Where(item => item.Id == id)
                .Include(item => item.TransactionLines)
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
                .Include(item => item.TransactionLines)
                .SingleOrDefault();
            if (ItemDb is null) throw new KeyNotFoundException($"Given id '{id}' was not found");
            ItemDb.Code = entity.Code;
            ItemDb.Description = entity.Description;
            ItemDb.ItemType = entity.ItemType;
            ItemDb.Price = entity.Price;
            ItemDb.Cost = entity.Cost;
            context.SaveChanges();
        }
    }
}


