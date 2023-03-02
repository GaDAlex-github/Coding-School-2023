namespace FuelStation.EF.Repositories {
    public interface ITransactionLineRepo<TEntity> : IEntityRepo<TEntity>{
            IList<TEntity> GetAllWithTransactionID(int id);
     
    }
}

