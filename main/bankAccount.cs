public class BankAccount {
    public string Username { get; }
    public double Balance { get; } = 0.0;

    private string Password;
    private int minimumThreshold = -1000;

    public static BankAccount? selected;
    private List<Transaction> transactions = new List<Transaction>();

    public BankAccount(string username, string password, List<Transaction> transactions = null){
        this.Username = username;
        this.Password = password;
        this.transactions = transactions ?? new List<Transaction>();
    }

    // Transactions Based Methods
    public double CalculateBalance() {
        double total = 0;
        transactions.ForEach(item => {
            total = total + item.GetAmount();
        });
        return total;
    }

    public int GetTransactionCount(){
        return transactions.Count();
    }

    public void CreateTransaction(double amount){
        if(selected != null && amount != null && selected?.CalculateBalance() + amount > minimumThreshold){
            Transaction tr;
            if(amount > 0){
                tr = new Transaction("DEPOSIT", selected!.Username, amount);
            } else {
                tr = new Transaction(selected!.Username, "WITHDRAW", amount);
            }
            selected.transactions.Add(tr);
            UpdateData();
        }
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
            password = selected?.Password,
            transactions = selected?.transactions.ToArray().Select(item => item.Save()),
        };

        // Update Json DB
        BankAccountDAO.SaveAccount(selected?.Username, dataToSave);
    }

    public List<Transaction> GetTransactions() {
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