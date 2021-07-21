using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageSystem {
//variable for the list    
private List<Item> itemList;

public StorageSystem() {
//creates the list the items are held in
itemList = new List<Item>();
}
//method for adding an item
public void AddItem(Item item){
//checks to see if the item is stackable
if (item.isStackable() == true ){
//local scope bool to confirm that the items found in the inventory
bool itemFound = false;
//for each item in the inventory
foreach (Item inventoryItems in itemList){
//check to see if the inventory has a matching itemtype to the incoming item
    if(inventoryItems.itemType == item.itemType){
//sets itemfound to true to cancel normal method of adding item        
        itemFound = true; 
       
//adds the incoming item amount to the amount in the inventory
        inventoryItems.amount += item.amount;
        }
//if a matching itemtype isnt found        
    } if (itemFound == false){
//add that item onto the itemList        
        itemList.Add(item);
        
     }
    } else {
        AddItem(item);
    }
}
public int AmountAtIndex(int index){
var itemAtIndex = itemList[index];
int Amount = itemAtIndex.amount;
return Amount;
}

public void RemoveItemByIndex(int index){
var itemAtIndex = itemList[index];
var type = itemAtIndex.itemType; 
int amountAtIndex = itemAtIndex.amount;
RemoveItem(new Item{itemType = type, amount = amountAtIndex}); 
}
public void TransferItemToInventory (int index, Ui TransferingTo){
var itemAtIndex = itemList[index];
var type = itemAtIndex.itemType; 
int amountAtIndex = itemAtIndex.amount;
TransferingTo.inventory.AddItem(new Item{itemType = type, amount = amountAtIndex});
RemoveItem(new Item{itemType = type,  amount = amountAtIndex}); 
}

//the same as above with minor variations to reverse it
public void RemoveItem(Item item){
 //checks to see if the item is stackable
if (item.isStackable() == true ){
//local scope null item to confirm that the items found in the inventory and to check that the item is in the inventory
    Item itemInInventory = null;

//for each item in the inventory
foreach (Item inventoryItems in itemList){
//check to see if the inventory has a matching itemtype to the incoming item
        if(inventoryItems.itemType == item.itemType){
    
//removes the incoming items amount from the amount in the inventory
            inventoryItems.amount -= item.amount;
//sets the itemininventory to the same as inventryitems, making it not null in order to confirm that there the item is in the inventory, also eliminates enumeration iteration issue by copying the 
            itemInInventory = inventoryItems; 
        }
//if the itemininventory variable is not null and the amount is less than or equal to 0 
        } if (itemInInventory != null && itemInInventory.amount <= 0){
//removes the item from the list
            itemList.Remove(itemInInventory);

  
            }   
} else {
    
        itemList.Remove(item);
        Debug.Log(itemList.Count); 
    } 
}
//method for calling the list from other scripts
public List<Item> GetItemList() {
    //returns the inventory
return itemList;
}
}

