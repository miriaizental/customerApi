namespace customersApi.Controllers;
using Newtonsoft.Json;
using Models;

public class JsonLoad{

    String filePath;

    public JsonLoad(string filePath){
        this.filePath = filePath;
    }
    
    public CustomersCollection readJson()
    {
        using (StreamReader r = new StreamReader(this.filePath))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<CustomersCollection>(json) ?? new CustomersCollection();
        }
    }

    public void writeJson(CustomersCollection customers)
    {
        using (StreamWriter file = File.CreateText(this.filePath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, customers);
        }   
    }


}