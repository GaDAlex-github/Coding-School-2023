using FuelStation.Blazor.Shared.Customer;
using FuelStation.Blazor.Shared.Item;
using FuelStation.Model;
using FuelStation.Model.Enums;
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
        private async void ItemPage_Load(object sender, EventArgs e) {
            await LoadItemsFromServer();
            SetControllers();
        }
        public void SetControllers() {
            grvItems.AutoGenerateColumns = false;
            grvItems.DataSource = bsItems;

            
            DataGridViewComboBoxColumn itemType = new DataGridViewComboBoxColumn();
            itemType.DataSource = Enum.GetValues(typeof(ItemType));

            //itemType.ValueType = typeof(int);
            grvItems.Columns.Add(itemType);

        }

        private void btnCreate_Click(object sender, EventArgs e) {
            ItemListDto newItem = new ItemListDto();
            bsItems.Add(newItem);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            bsItems.RemoveCurrent();
        }

        private void btnSave_Click(object sender, EventArgs e) {

        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
        private async Task LoadItemsFromServer() {
            using (HttpClient client = new HttpClient()) {
                var response = await client.GetAsync("https://localhost:7157/item");
                var data = await response.Content.ReadAsAsync<IEnumerable<ItemListDto>>();
                grvItems.DataSource = data;
                bsItems.DataSource = data;
            }
        }       

        private void grvItems_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            e.Cancel = true;
        }
    }
}
