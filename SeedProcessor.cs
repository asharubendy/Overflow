using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedProcessor : MonoBehaviour
{
  
  InventorySystem inventory;   
    [SerializeField] Ui uiInv;
    GameObject input; 
    public Material[] materials;
    Renderer rend;
    public Item.ItemType seedmanager;
    GameObject player;
    void Awake() {
    input = GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3");
    inventory = new InventorySystem();
    uiInv.SetIventory(inventory);
    rend = GetComponent<Renderer>();
    rend.sharedMaterial = materials[1];
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnMouseDown() {
  if(player.GetComponent<Charcontroller>().gameManager.GetComponent<DayNightCycle>().currentAP >= 0){
   CompostingItemPassIn();
   ActionPointSystem.actionMade = true;
    }
  }

      void OnMouseOver() {
        rend.sharedMaterial = materials[0];
    }
    void OnMouseExit() {
        rend.sharedMaterial = materials[1];
    }


     public void CompostingItemPassIn(){
           if (uiInv.inventory.InventorySpaceCheckIndex(input.GetComponent<Ui>().Selector) == true){
        int selector = input.GetComponent<Ui>().Selector;
        Item test = uiInv.inventory.ReturnItemByIndex(selector);
        seedmanager = test.ItemToSeed(); 
            uiInv.inventory.RemoveItemByIndexAmount(selector, 1);
            uiInv.inventory.AddItem(new Item{itemType = seedmanager, amount = 1});
            uiInv.SyncInventory();
        }
    }
 }

