using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories {
    public  interface IEmployeeRepo<TEntity> : IEntityRepo<TEntity>{
        int ManagerCount();
        int StaffCount();
        int CashierCount();
    }
}
