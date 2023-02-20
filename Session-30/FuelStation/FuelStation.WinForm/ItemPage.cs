using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.WinForm {
    public partial class ItemPage : Form {
        public ItemPage() {
            InitializeComponent();
        }
        private void ItemPage_Load(object sender, EventArgs e) {
            
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            Item newItem = new Item();
            bsItem.Add(newItem);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            bsItem.RemoveCurrent();
        }

        private void btnSave_Click(object sender, EventArgs e) {

        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        
    }
}
