using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

static class FileDB {
    
    static private dynamic? data;

    static public void Init(){
        try {
            if(File.Exists("./data.json") == false){
                File.Create("./data.json");
            }
        } catch (Exception ex){
            Console.Write(ex.Message);
        }
        data = JsonConvert.DeserializeObject(File.ReadAllText("./data.json"))!;
    }

    static public void Save(){
        if(data != null){
            File.WriteAllText("data.json", JsonConvert.SerializeObject(data));
        }
    }

    static public dynamic GetUser(string username){
        var user = FileDB.data?["users"][username];
        if(user == null){
            return null;
        }
        return new {
            password = user.password,
            transactions = user.transactions
        };
    }

    static public void SetUser(string username, JObject value){
        FileDB.data!["users"][username] = value;
    }

}