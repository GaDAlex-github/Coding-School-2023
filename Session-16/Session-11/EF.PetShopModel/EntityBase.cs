using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopModel {
    public abstract class EntityBase : IEntityBase {
        public int Id { get; set; }
        public EntityBase() { 
            
        }

    }
}
