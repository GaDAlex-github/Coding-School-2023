namespace FuelStation.EF.Repositories {
    public interface ITransactionLineRepo<TEntity> {
        IList<TEntity> GetAll();
        TEntity? GetById(int id);
        IList<TEntity> GetAllWithTransactionID(int id);
        void Add(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
    }
}

