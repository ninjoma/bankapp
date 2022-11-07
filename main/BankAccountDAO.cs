using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class BankAccountDAO {
    public static bool DoesUsernameExist(string username) {
        return (FileDB.data?["users"][username] == null) ? false : true;
    }

    public static bool DoesPasswordMatch(string username, string password){
        return (FileDB.data?["users"][username].password == password) ? true : false;
    }

    public static Transaction[] LoadTransactions(string username){
        var currentUser = FileDB.data?["users"][username];
        if(currentUser?.transactions == null){
            throw new Exception();
        }
        JArray listOfTransactions = JArray.FromObject(currentUser?.transactions);
        int length = listOfTransactions.Count();
        Transaction[] loadedTransactions = new Transaction[length];
        int i = 0;
        foreach(JObject item in listOfTransactions){
            loadedTransactions[i] = new Transaction(
                item.GetValue("senderID")?.ToString() ?? "NOT FOUND",
                item.GetValue("receiverID")?.ToString() ?? "NOT FOUND",
                Double.Parse(item.GetValue("Amount")?.ToString() ?? "ERROR")
            );
            i++;    
        }
        return loadedTransactions;
    }


    public static void SaveAccount(string username, dynamic dataToSave){
        FileDB.data!["users"][username] =  JObject.FromObject(dataToSave);
    }
    
    
}