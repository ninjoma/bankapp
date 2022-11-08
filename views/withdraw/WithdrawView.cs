namespace bankapp{
    using Terminal.Gui;
    using Newtonsoft.Json;
    
    public partial class WithdrawView {
        
        public WithdrawView() {
            InitializeComponent();
            backButton.Clicked += () => backProcess();
            withdrawButton.Clicked += () => withdrawProcess();
        }

        private void backProcess(){
            Application.Top.Add(new MenuView());
            Application.Top.Remove(this);
        }

        private void withdrawProcess(){
            BankAccount.selected?.CreateTransaction(-Double.Parse(Convert.ToString(withdrawField.Text) ?? "0"));
            Application.Top.Add(new MenuView());
            Application.Top.Remove(this);
        }

    }
}