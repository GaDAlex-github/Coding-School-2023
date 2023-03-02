﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories {
    public interface IItemRepo<TEntity> : IEntityRepo<TEntity> {
        public string CodeCreate();
    }
}
