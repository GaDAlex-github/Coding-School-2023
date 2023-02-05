using Session_11.EF.PetShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.PetShop.Model {
    public abstract class EntityBase : IEntityBase {
        public int ID { get; set; }
    }
}
