namespace bankapp{
    using Terminal.Gui;
    using Newtonsoft.Json;
    
    public partial class MenuView {
        
        public MenuView() {
            InitializeComponent();
            Console.Write(JsonConvert.SerializeObject(BankAccount.selected));
        }

    }
}