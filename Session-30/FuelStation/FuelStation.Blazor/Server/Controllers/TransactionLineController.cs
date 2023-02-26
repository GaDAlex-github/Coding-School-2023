using FuelStation.Blazor.Client.Pages.UIs;
using FuelStation.Blazor.Shared.Customer;
using FuelStation.Blazor.Shared.Employee;
using FuelStation.Blazor.Shared.Item;
using FuelStation.Blazor.Shared.Transaction;
using FuelStation.Blazor.Shared.TransactionLine;
using FuelStation.EF.Repositories;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class TransactionLineController : ControllerBase {

        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly ITransactionLineRepo<TransactionLine> _transactionLineRepo;
        private readonly IEntityRepo<Item> _itemRepo;

        public TransactionLineController(ITransactionLineRepo<TransactionLine> transactionLineRepo, IEntityRepo<Transaction> transactionRepo, IEntityRepo<Item> itemRepo) {
            _transactionRepo = transactionRepo;
            _transactionLineRepo = transactionLineRepo;
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionLineListDto>> Get() {
            var transLine = _transactionLineRepo.GetAll();
            var TransactionLineList = transLine.Select(transactionLine => new TransactionLineListDto {
                Id = transactionLine.Id,
                TransactionId = transactionLine.TransactionId,
                ItemId = transactionLine.ItemId,
                Quantity = transactionLine.Quantity,
                ItemPrice = transactionLine.ItemPrice,
                NetValue = transactionLine.NetValue,
                DiscountPercent = transactionLine.DiscountPercent,
                DiscountValue = transactionLine.DiscountValue,
                TotalValue = transactionLine.TotalValue,
                Item = new ItemListDto() {
                    Id = transactionLine.Item.Id,
                    Code = transactionLine.Item.Code,
                    Description = transactionLine.Item.Description,
                    ItemType = transactionLine.Item.ItemType,
                    Price = transactionLine.Item.Price,
                    Cost = transactionLine.Item.Cost,
                }
            });

            return TransactionLineList;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            var transactionLine = _transactionLineRepo.GetById(id).TransactionId;
            _transactionLineRepo.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<TransactionLineListDto>> GetAllWithTransactionID(int id) {
            var transactionLines = _transactionLineRepo.GetAllWithTransactionID(id);
            var items = _itemRepo.GetAll();
            var TransactionLineList = transactionLines.Select(transactionLine => new TransactionLineListDto {
                Id = transactionLine.Id,
                ItemId = transactionLine.ItemId,
                Quantity = transactionLine.Quantity,
                ItemPrice = transactionLine.ItemPrice,
                NetValue = transactionLine.NetValue,
                DiscountPercent = transactionLine.DiscountPercent,
                DiscountValue = transactionLine.DiscountValue,
                TotalValue = transactionLine.TotalValue,
                Item = new ItemListDto {
                    Id = transactionLine.Item.Id,
                    Description = transactionLine.Item.Description,
                    ItemType = transactionLine.Item.ItemType,
                    Price = transactionLine.Item.Price,
                    Cost = transactionLine.Item.Cost
                },
            });
            return TransactionLineList;
        }

        [HttpPost]
        public async Task Post(TransactionLineEditDto transLine) {
            var newTransactionLine = new TransactionLine(transLine.Quantity, transLine.ItemPrice, transLine.DiscountPercent);
            newTransactionLine.TransactionId = transLine.TransactionId;
            newTransactionLine.ItemId = transLine.ItemId;
            newTransactionLine.NetValue = transLine.NetValue;
            newTransactionLine.DiscountValue = transLine.DiscountValue;
            newTransactionLine.TotalValue = transLine.TotalValue;
            _transactionLineRepo.Add(newTransactionLine);
            //var transaction = _transactionRepo.GetById(newTransactionLine.TransactionId);
            //transaction.TotalValue = newTransactionLine.TotalValue;
            //_transactionRepo.Update(transLine.TransactionId, transaction);
        }

        public async Task Put(TransactionLineEditDto transLine) {
            var trans = _transactionRepo.GetById(transLine.TransactionId);
            var itemToUpdate = _transactionLineRepo.GetById(transLine.Id);
            itemToUpdate.Id = transLine.Id;
            itemToUpdate.TransactionId = transLine.TransactionId;
            itemToUpdate.ItemId = transLine.ItemId;
            itemToUpdate.Quantity = transLine.Quantity;
            itemToUpdate.ItemPrice = transLine.ItemPrice;
            itemToUpdate.NetValue = transLine.NetValue;
            itemToUpdate.DiscountPercent = transLine.DiscountPercent;
            itemToUpdate.DiscountValue = transLine.DiscountValue;
            itemToUpdate.TotalValue = transLine.TotalValue;
            //var transaction = _transactionRepo.GetById(itemToUpdate.TransactionId);
            //transaction.TotalValue = itemToUpdate.TotalValue;
            _transactionRepo.Update(itemToUpdate.TransactionId, trans);

        }
    }
}
