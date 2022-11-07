namespace bankapp{
    using Terminal.Gui;
    using Newtonsoft.Json;
    
    public partial class DepositView {
        
        public DepositView() {
            InitializeComponent();
            backButton.Clicked += () => backProcess();
            depositButton.Clicked += () => depositProcess();
        }

        private void backProcess(){
            Application.Top.Add(new MenuView());
            Application.Top.Remove(this);
        }

        private void depositProcess(){
            BankAccount.selected?.CreateTransaction(Double.Parse(Convert.ToString(depositField.Text) ?? "0"));
            backProcess();
        }

    }
}