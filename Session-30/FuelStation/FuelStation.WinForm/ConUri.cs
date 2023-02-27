namespace FuelStation.WinForm {
    public class ConUri {
        public string MyUri { get; set; } = "https://localhost:7157/";

        public ConUri() { }

        public void SetUri(string uri) {
            MyUri = uri;
        }
        public string GetUri() {
            return MyUri;
        }
    }
}
