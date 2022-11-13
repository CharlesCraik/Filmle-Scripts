using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string quote;
    public string name;

    public Item(Item d){
        id = d.id;
        quote = d.quote;
        name = d.name;
    }
}
