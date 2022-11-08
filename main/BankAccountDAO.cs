using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class BankAccountDAO {
    public static bool DoesUsernameExist(string username) {
        return (FileDB.GetUser(username) == null) ? false : true;
    }

    public static bool DoesPasswordMatch(string username, string password){
        return (FileDB.GetUser(username).password == password) ? true : false;
    }

    public static List<Transaction> LoadTransactions(string username){
        var currentUser = FileDB.GetUser(username);
        if(currentUser?.transactions == null){
            throw new Exception();
        }
        JArray listOfTransactions = JArray.FromObject(currentUser?.transactions);
        int length = listOfTransactions.Count();
        List<Transaction> loadedTransactions = new List<Transaction>();
        foreach(JObject item in listOfTransactions){
            loadedTransactions.Add(new Transaction(
                item.GetValue("senderID")?.ToString() ?? "NOT FOUND",
                item.GetValue("receiverID")?.ToString() ?? "NOT FOUND",
                Double.Parse(item.GetValue("Amount")?.ToString() ?? "ERROR")
            ));    
        }
        return loadedTransactions;
    }


    public static void SaveAccount(string username, dynamic dataToSave){
        FileDB.SetUser(username, JObject.FromObject(dataToSave));
    }
    
    
}
