using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;

    public void Start()
    {
        inventoryUI.gameObject.SetActive(false);
    }

    public void Update(){
        if(CrossPlatformInputManager.GetButtonDown("Inventory")){
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }

    public void GiveItem(int id){
        Item itemToAdd = itemDatabase.getItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: "+itemToAdd.title);
    }

    public Item CheckForItem(int id){
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id){
        Item item = CheckForItem(id);
        if(item != null){
            characterItems.Remove(item);
            inventoryUI.RemoveItem(item);
            Debug.Log("Item removed: " + item.title);
        }
    }
}
