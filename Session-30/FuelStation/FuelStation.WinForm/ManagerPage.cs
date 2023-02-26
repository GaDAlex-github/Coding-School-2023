﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.WinForm {
    public partial class ManagerPage : Form {
        public ManagerPage() {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e) {
            this.Hide();
            CustomerPage customerPage = new();
            customerPage.ShowDialog();
            this.Show();
        }

        private void btnItems_Click(object sender, EventArgs e) {
            this.Hide();
            ItemPage itemPage = new();
            itemPage.ShowDialog();
            this.Show();
        }

        private void btnTransactions_Click(object sender, EventArgs e) {
            this.Hide();
            CardNumberPage cardNumberPage = new();
            cardNumberPage.ShowDialog();
            this.Show();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void btnSet_Click(object sender, EventArgs e) {

        }
    }
}
