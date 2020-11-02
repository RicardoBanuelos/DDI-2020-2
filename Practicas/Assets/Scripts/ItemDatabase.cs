using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    
    public Item(int id, string title, string description){
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/" + title);
    }

    public Item(Item item){
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("Sprites/" + item.title);
    }
}

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void Awake(){
        BuildDatabase();
    }

    public Item getItem(int id){
        return items.Find(item => item.id == id);
    }

    public Item getItem(string itemName){
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase(){
        items = new List<Item>{
            new Item(0, "Hamburger", "A delicous patty between buns."),
            new Item(1, "HotDog", "A delicous sausage in some bread."),
            new Item(2, "Watermelon", "Fresh fruit for energy."),
            new Item(3, "Coin", "This is how much you're worth.")
        };
    }
}
