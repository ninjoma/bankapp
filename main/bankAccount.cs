public class BankAccount {
    public string Username { get; }
    public double Balance { get; } = 0.0;

    private string Password;

    public static BankAccount? selected;
    private Transaction[] transactions;

    public BankAccount(string username, string password, Transaction[] transactions = null!){
        this.Username = username;
        this.Password = password;
        this.transactions = transactions ?? new Transaction[50];
    }

    // Transactions Based Methods
    private double CalculateBalance() {
        return 0.0; // TO DO.
    }


    // UI Login Methods
    public static void LoginAccount(string username, string password){

        if(BankAccountDAO.DoesUsernameExist(username) == false){
            throw new UsernameNotFoundException("The username doesn't exist");
        }
        if(BankAccountDAO.DoesPasswordMatch(username, password) == false){
            throw new PasswordDoesntMatchException("Username and Password don't match");
        }
        selected = new BankAccount(username, password, BankAccountDAO.LoadTransactions(username));
    }

    public static void CreateAccount(string username, string password){

        if(BankAccountDAO.DoesUsernameExist(username) == true){
            throw new AccountWithUsernameExistsException("Username with that username already exists");
        }

        selected = new BankAccount(username, password);
        UpdateData();
    }
    
    private static void UpdateData(){

        // Data to Save
        dynamic dataToSave = new {
            password = selected!.Password,
            transactions = selected.transactions,
        };

        // Update Json DB
        BankAccountDAO.SaveAccount(selected.Username, dataToSave);
    }

    public Transaction[] GetTransactions() {
        return transactions;
    }
}

public class UsernameNotFoundException : Exception {
    public UsernameNotFoundException(string message): base(message){}
}
public class PasswordDoesntMatchException : Exception {
    public PasswordDoesntMatchException(string message): base(message) {}
}

public class AccountWithUsernameExistsException: Exception {
    public AccountWithUsernameExistsException(string message): base(message) {}
}