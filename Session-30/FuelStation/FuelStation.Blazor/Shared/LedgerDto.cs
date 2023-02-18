﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Blazor.Shared {
    public class LedgerDto {

        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }

        public List<FuelStation.Model.Employee> Employees { get; set; } = new List<FuelStation.Model.Employee>();
        // public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

