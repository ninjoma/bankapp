using Newtonsoft.Json;

static class FileDB {
    
    static public dynamic data;

    static public void Init(){
        try {
            if(File.Exists("data.json") == false){
                File.Create("data.json");
            }
        } catch (Exception ex){
            
        }
        data = JsonConvert.DeserializeObject(File.ReadAllText("data.json"));
    }

    static public void Update(string key, Object value){
        data[key] = JsonConvert.SerializeObject(value);
        Console.Write(data[key]);
    }

    static public void Save(){
        if(data != null){
            File.WriteAllText("data.json", JsonConvert.SerializeObject(data));
        }
    }

}