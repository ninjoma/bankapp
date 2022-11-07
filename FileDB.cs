using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

static class FileDB {
    
    static public dynamic? data;

    static public void Init(){
        try {
            if(File.Exists("data.json") == false){
                File.Create("data.json");
            }
        } catch (Exception ex){
            Console.Write(ex.Message);
        }
        data = JsonConvert.DeserializeObject(File.ReadAllText("data.json"))!;
    }

    static public void Save(){
        if(data != null){
            File.WriteAllText("data.json", JsonConvert.SerializeObject(data));
        }
    }

}