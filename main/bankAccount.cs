

[Serializable]
public class BankAccount {
    private string Username;
    private string Password;

    public static BankAccount? selected;
    
    public BankAccount(string username, string password){
        this.Username = username;
        this.Password = password;
    }

    public static void LoginAccount(string username, string password){
        if(FileDB.data[username] == null){
            throw new UsernameNotFoundException("The username doesn't exist");
        }
        if(FileDB.data[username].password != password){
            throw new PasswordDoesntMatchException("Username and Password don't match");
        }
        selected = new BankAccount(username, password);
    }

    public static void CreateAccount(string username, string password){
        if(FileDB.data[username] != null){
            throw new AccountWithUsernameExistsException("Username with that username already exists");
        }
        selected = new BankAccount(username, password);
        UpdateData(selected);
    }
    
    private static void UpdateData(BankAccount bk){
        new JObject();
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