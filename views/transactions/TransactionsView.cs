namespace bankapp{
    using Terminal.Gui;
    using Newtonsoft.Json;
    
    public partial class TransactionsView {
        
        public TransactionsView() {
            InitializeComponent();
            backButton.Clicked += () => backProcess();
        }

        private void backProcess(){
            Application.Top.Add(new MenuView());
            Application.Top.Remove(this);
        }

    }
}