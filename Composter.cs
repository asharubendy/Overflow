using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composter : MonoBehaviour
{
  InventorySystem inventory;   
    [SerializeField] Ui uiInv;
    GameObject input; 
    public Material[] materials;
    Renderer rend;
    GameObject player;
    void Awake() {
    input = GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3");
    inventory = new InventorySystem();
    uiInv.SetIventory(inventory);
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = materials[1];
    }
      void OnMouseOver() {
        rend.sharedMaterial = materials[0];
    }
    void OnMouseExit() {
        rend.sharedMaterial = materials[1];
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void OnMouseDown() {
   CompostingItemPassIn();
    }

     public void CompostingItemPassIn(){
           if (uiInv.inventory.checkListIsPopulated() == true){
        int selector = input.GetComponent<Ui>().Selector;
        Item test = uiInv.inventory.ReturnItemByIndex(selector);
        if(test.isCompostable() == true){
            uiInv.inventory.RemoveItemByIndexAmount(selector, 1);
            uiInv.inventory.AddItem(new Item{itemType = Item.ItemType.Compost, amount = 1});
            uiInv.SyncInventory();
            }
        }
    }
}
