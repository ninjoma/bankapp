namespace bankapp{
    using Terminal.Gui;
    using Newtonsoft.Json;
    
    public partial class MenuView {
        
        public MenuView() {
            InitializeComponent();
            transButton.Clicked += () => TransProcess();
            depositButton.Clicked += () => DepositProcess();
            withdrawButton.Clicked += () => WithdrawProcess();
        }

        private void TransProcess(){
            Application.Top.Add(new TransactionsView());
            Application.Top.Remove(this);
        }

        private void DepositProcess(){
            Application.Top.Add(new DepositView());
            Application.Top.Remove(this);
        }

        private void WithdrawProcess(){
            Application.Top.Add(new WithdrawView());
            Application.Top.Remove(this);
        }
    }
}