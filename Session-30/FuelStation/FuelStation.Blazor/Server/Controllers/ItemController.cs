using FuelStation.EF.Repositories;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FuelStation.Blazor.Shared.Item;
using System.Text.RegularExpressions;

namespace FuelStation.Blazor.Server.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase {

        private readonly IItemRepo<Item> _itemRepo;

        public ItemController(IItemRepo<Item> itemRepo) {
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemListDto>> Get() {
            var item = _itemRepo.GetAll();
            return item.Select(item => new ItemListDto {
                Id = item.Id,
                Code = item.Code,
                Description = item.Description,
                ItemType = item.ItemType,
                Price = item.Price,
                Cost = item.Cost
            });
        }

        [HttpGet("{id}")]
        public async Task<ItemEditDto> GetById(int id) {
            var item = _itemRepo.GetById(id);
            return new ItemEditDto {
                Id = item.Id,
                Code = item.Code,
                Description = item.Description,
                ItemType = item.ItemType,
                Price = item.Price,
                Cost = item.Cost
            };
        }
        [HttpPost]
        public async Task Post(ItemEditDto item) {
            var newItem = new Item(item.Description, item.ItemType, item.Price, item.Cost);
            newItem.Code = _itemRepo.CodeCreate();
            _itemRepo.Add(newItem);
        }

        [HttpPut]
        public async Task Put(ItemEditDto item) {
            var itemToUpdate = _itemRepo.GetById(item.Id);
            itemToUpdate.Id = item.Id;
            itemToUpdate.Code = item.Code;
            itemToUpdate.Description = item.Description;
            itemToUpdate.ItemType = item.ItemType;
            itemToUpdate.Price = item.Price;
            itemToUpdate.Cost = item.Cost;
            _itemRepo.Update(item.Id, itemToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            try {
                _itemRepo.Delete(id);
                return Ok();
            }
            catch (DbUpdateException ex) {
                return BadRequest("This item cannot be deleted!");
            }
            catch (KeyNotFoundException ex) {
                return BadRequest($"Item with id {id} not found!");
            }
        }       
    }
}

