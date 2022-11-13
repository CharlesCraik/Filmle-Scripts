using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadExcel : MonoBehaviour
{
    public Item blankItem;
    public List<Item> itemDatabase = new List<Item>();

    public void loadItemData(){
        itemDatabase.Clear();

        List<Dictionary<string, object>> data = CSVReader.Read("MovieSheet");
        for(var i = 0; i < data.Count; i++){
            int id = int.Parse(data[i]["id"].ToString(), System.Globalization.NumberStyles.Integer);
            string quote = data[i]["quote"].ToString();
            string name = data[i]["name"].ToString();

            AddItem(id, quote, name);
        }
    }

    void AddItem(int id, string quote, string name){
        Item tempItem = new Item(blankItem);

        tempItem.id = id;
        tempItem.quote = quote;
        tempItem.name = name;

        itemDatabase.Add(tempItem);
    }
}
