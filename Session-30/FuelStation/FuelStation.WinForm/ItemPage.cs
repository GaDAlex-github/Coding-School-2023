using FuelStation.Blazor.Shared.Item;
using FuelStation.Model.Enums;
using Newtonsoft.Json;

namespace FuelStation.WinForm {
    public partial class ItemPage : Form {

        private readonly HttpClient httpClient;

        public ItemPage() {
            InitializeComponent();
            httpClient = new HttpClient();
            ConUri uri = new();
            httpClient.BaseAddress = new Uri(uri.GetUri());
        }
        private void ItemPage_Load(object sender, EventArgs e) {
            SetControllers();
        }

        public async void SetControllers() {
            var items = await GetItems();
            if (items != null) {
                bsItems.DataSource = items;
                grvItems.AutoGenerateColumns = false;
                grvItems.DataSource = bsItems;

                clmItemType.DataPropertyName = "ItemType";
                clmItemType.DataSource = Enum.GetValues(typeof(ItemType));
            }
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            ItemListDto newItem = new ItemListDto();
            bsItems.Add(newItem);
        }
        private void btnDelete_Click(object sender, EventArgs e) {
            if (ConfirmDelete()) {
                ItemListDto item = (ItemListDto)grvItems.CurrentRow.DataBoundItem;
                DeleteItem(item.Id);
            }
        }
        private void btnSave_Click(object sender, EventArgs e) {

            ItemListDto item = (ItemListDto)grvItems.CurrentRow.DataBoundItem;
            if (item.Id == 0) {
                _ = NewItem(item);
            }
            else {
                _ = EditItem(item);
            }
        }
        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
        private async Task<List<ItemListDto?>> GetItems() {
            var response = await httpClient.GetAsync("item");
            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ItemListDto?>>(data);
            }
            else {
                return null;
            }
        }
        private async Task NewItem(ItemListDto? item) {
            var response = await httpClient.PostAsJsonAsync("item", item);
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Item Created!", "Success Message");
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
            }
            SetControllers();
        }
        private async Task EditItem(ItemListDto? item) {
            var response = await httpClient.PutAsJsonAsync("item", item);
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Item Edited!", "Success Message");
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
            }
            SetControllers();
        }
        private bool ConfirmDelete() {
            var result = MessageBox.Show(this, "Procceed Deleting Selected Item?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }
        private async Task DeleteItem(int id) {
            var response = await httpClient.DeleteAsync($"item/{id}");
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Item Deleted!", "Success Message");
            }
            else {
                MessageBox.Show("Cant Delete an Item Involved on a Transaction!", "Alert Message");
            }
            SetControllers();
        }
    }
}
