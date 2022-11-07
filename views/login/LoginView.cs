namespace bankapp{
    using Terminal.Gui;
    
    public partial class LoginView {
        
        public LoginView() {
            InitializeComponent();
            loginButton.Clicked += () => loginProcess();
            createAccountButton.Clicked += () => createAccountProcess();
        }

        private void loginProcess(){
            try {
                BankAccount.LoginAccount(Convert.ToString(usernameField.Text) ?? "", Convert.ToString(passwordField.Text) ?? "");
                Application.Top.Add(new MenuView());
                Application.Top.Remove(this);
            } catch(Exception e) {
                this.errorMessageLabel.Visible = true;
                this.errorMessageLabel.Text = e.Message;
            }
        }

        private void createAccountProcess(){
            try {
                BankAccount.CreateAccount(Convert.ToString(usernameField.Text) ?? "", Convert.ToString(passwordField.Text) ?? "");
                Application.Top.Add(new MenuView());
                Application.Top.Remove(this);
            } catch(Exception e){
                this.errorMessageLabel.Visible = true;
                this.errorMessageLabel.Text = e.Message;
            }
        }
    }
}
