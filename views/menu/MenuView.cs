namespace bankapp{
    using Terminal.Gui;
    using Newtonsoft.Json;
    
    public partial class MenuView {
        
        public MenuView() {
            InitializeComponent();
            transButton.Clicked += () => transProcess();
        }

        private void transProcess(){
            Application.Top.Add(new TransactionsView());
        }
    }
}