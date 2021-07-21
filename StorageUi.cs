using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StorageUi : MonoBehaviour
{
public StorageSystem storage;
  
public GameObject[] SlotArray;

public GameObject inv;
public bool invFull = false;
public GameObject ItemSpritesContainer;
public bool[] SlotOccupied;
public int[] ItemIDSlot;
int mouseWheelPos;
int i = 0;
 public void Awake() {
   //setting where to get the sprites from
    ItemSpritesContainer = GameObject.Find("CharController/ItemAssetsContainer");
    ItemIDSlot = new int[4];
   //setting boolean array size 
    SlotOccupied = new bool[3];
    //setting gameobject array size
    SlotArray = new GameObject[3];
    //finding the game objecs and inserting them into the array on awake
    SlotArray[0]= GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3/InventorySlot/StorageIcon");
    SlotArray[1]= GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3/InventorySlot/StorageIconP2");
    SlotArray[2]= GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3/InventorySlot/StorageIconP3");

  }
//sets the instance of the inventory
  public void SetStorage(StorageSystem storage) {
    this.storage = storage; 
  }
  //syncs the inventory into the slots
  public void SyncStorage(){
    // reseting the item slots before syncing list to UI
     for (int x = 0; x <= 2; x++){
      SlotArray[x].GetComponent<Image>().color = new Color (255,255,255,0);
    }
    // foreach loops that runs for each item inside of the inventory 
  foreach (Item item in storage.GetItemList()){
    
  //resolves the id of each item
    int ID = item.ItemTypeToID();
    int amount = item.amount;
  //runs the itemType through a switch
    switch(item.itemType) {
      default:
      case Item.ItemType.AppleSeed:
      //sets the current iteration of the slot to the items sprite
       SlotArray[i].GetComponent<Image>().sprite = ItemSpritesContainer.GetComponent<ItemAssetsContainer>().AppleSeedSprite;
       //sets the slot occupied so other iterations cant place stuff in it
       SlotOccupied[i] = true; 
       //sets the item id for the draggable component
       SlotArray[i].GetComponent<UIDraggable>().ID = ID;
       //sets the item amount
       SlotArray[i].GetComponent<UIDraggable>().amount = amount;
       SlotArray[i].GetComponent<Image>().color = new Color (255,255,255,255);
       //adds one to i for the next cycle
       i++;
       //breaks out of the switch
      break;
      case Item.ItemType.WheatSeed:
      //sets the current iteration of the slot to the items sprite
       SlotArray[i].GetComponent<Image>().sprite = ItemSpritesContainer.GetComponent<ItemAssetsContainer>().WheatSeedSprite;
       //sets the slot occupied so other iterations cant place stuff in it
       SlotOccupied[i] = true; 
       //sets the item id for the draggable component
       SlotArray[i].GetComponent<UIDraggable>().ID = ID;
       //sets the item amount
       SlotArray[i].GetComponent<UIDraggable>().amount = amount;
       SlotArray[i].GetComponent<Image>().color = new Color (255,255,255,255);
       //adds one to i for the next cycle
       i++;
       //breaks out of the switch
      break;
      case Item.ItemType.CarrotSeed:
      //sets the current iteration of the slot to the items sprite
       SlotArray[i].GetComponent<Image>().sprite = ItemSpritesContainer.GetComponent<ItemAssetsContainer>().CarrotSeedSprite;
       //sets the slot occupied so other iterations cant place stuff in it
       SlotOccupied[i] = true; 
       //sets the item id for the draggable component
       SlotArray[i].GetComponent<UIDraggable>().ID = ID;
       //sets the item amount
       SlotArray[i].GetComponent<UIDraggable>().amount = amount;
       SlotArray[i].GetComponent<Image>().color = new Color (255,255,255,255);
       //adds one to i for the next cycle
       i++;
       //breaks out of the switch
      break;
      case Item.ItemType.Apple:
      //sets the current iteration of the slot to the items sprite
       SlotArray[i].GetComponent<Image>().sprite = ItemSpritesContainer.GetComponent<ItemAssetsContainer>().AppleSprite;
       //sets the slot occupied so other iterations cant place stuff in it
       SlotOccupied[i] = true; 
       //sets the item id for the draggable component
       SlotArray[i].GetComponent<UIDraggable>().ID = ID;
       //sets the item amount
       SlotArray[i].GetComponent<UIDraggable>().amount = amount;
       //adds one to i for the next cycle
       SlotArray[i].GetComponent<Image>().color = new Color (255,255,255,255);
       i++;
       //breaks out of the switch
      break;

      case Item.ItemType.Wheat: 
      SlotArray[i].GetComponent<Image>().sprite = ItemSpritesContainer.GetComponent<ItemAssetsContainer>().WheatSprite;
      SlotOccupied[i] = true;
      SlotArray[i].GetComponent<UIDraggable>().ID = ID;
      SlotArray[i].GetComponent<UIDraggable>().amount = amount;
      SlotArray[i].GetComponent<Image>().color = new Color (255,255,255,255);
      i++;
      break;

      case Item.ItemType.Carrot: 
      SlotArray[i].GetComponent<Image>().sprite = ItemSpritesContainer.GetComponent<ItemAssetsContainer>().CarrotSprite;
      SlotOccupied[i] = true;
      SlotArray[i].GetComponent<UIDraggable>().ID = ID;
      SlotArray[i].GetComponent<UIDraggable>().amount = amount;
      SlotArray[i].GetComponent<Image>().color = new Color (255,255,255,255);
      i++;
      break;

      case Item.ItemType.Wood: 
      SlotArray[i].GetComponent<Image>().sprite = ItemSpritesContainer.GetComponent<ItemAssetsContainer>().WoodSprite;
      SlotOccupied[i] = true;
      SlotArray[i].GetComponent<UIDraggable>().ID = ID;
      SlotArray[i].GetComponent<UIDraggable>().amount = amount;
      SlotArray[i].GetComponent<Image>().color = new Color (255,255,255,255);
      i++;
      break;
      case Item.ItemType.Compost:
                    SlotArray[i].GetComponent<Image>().sprite = ItemSpritesContainer.GetComponent<ItemAssetsContainer>().CompostSprite;
                    SlotOccupied[i] = true;
                    SlotArray[i].GetComponent<UIDraggable>().ID = ID;
                    SlotArray[i].GetComponent<UIDraggable>().amount = amount;
                    SlotArray[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    i++;
                    break;
    }  
    ///
    if (i >= 3){
      break;
    }
  } 
    SlotOccupied[0] = false;
    SlotOccupied[1] = false;
    SlotOccupied[2] = false;
    i=0;
  }
}


  

  