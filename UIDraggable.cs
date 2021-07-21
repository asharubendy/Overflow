using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class UIDraggable : MonoBehaviour, IDragHandler, IPointerClickHandler, IPointerUpHandler {

 [SerializeField] TextMeshProUGUI Cost1;
 [SerializeField] TextMeshProUGUI Cost2;   
 [SerializeField] TextMeshProUGUI Cost3;
private InventorySystem inventory;
[SerializeField] Ui uiInv;
private StorageSystem StorageInventory;
[SerializeField] StorageUi uiStorage; 
private ShopSystem shopInventory;
[SerializeField] ShopUi uiShop;
public Vector3 originalPosition;
public bool colliding = false; 
public bool reset = true;
public bool beingDragged;
public int ID;
public int amount;
public int FireFlies;
public int price;
public GameObject characterReference;
public GameObject[] TextReference;
[SerializeField] TextMeshProUGUI TMP;

public int slotID;
public GameObject amountref;
void Awake(){
    inventory = new InventorySystem(); 
    uiInv.SetIventory(inventory);
    StorageInventory = new StorageSystem(); 
    uiStorage.SetStorage(StorageInventory);
    // uiShop.SetShop(shopInventory);
    characterReference = GameObject.Find("CharController/Player");
    FireFlies = characterReference.GetComponent<Charcontroller>().FireFlies;
    
    switch(gameObject.name){
        default: break;
        case "Icon": slotID = 0; 
        amountref = GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3/InventorySlot/Icon/Amount");
        break;
        case "IconP2": slotID = 1; 
        amountref = GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3/InventorySlot/IconP2/Amount");
        break;
        case "IconP3": slotID = 2; 
        amountref = GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3/InventorySlot/IconP2/Amount");
        break;
        case "StorageIcon": slotID = 0; break;
        case "StorageIconP2": slotID = 1; break;
        case "StorageIconP3": slotID = 2; break;
        case "ShopInventory": slotID = 0; break;
        case "ShopInventoryP2": slotID = 1; break;
        case "ShopInventoryP3": slotID = 2; break;
    }
      
       
       
}

void OnTriggerEnter2D(Collider2D other) 
{

    if(other.gameObject.CompareTag("Storage") && this.gameObject.CompareTag("Inventory") && reset == true && beingDragged == true){ 
        uiInv.inventory.TransferItemToStorage(slotID,uiStorage);
        reset = false; 
      
      
       
    }
    if(other.gameObject.CompareTag("Inventory") && this.gameObject.CompareTag("Storage") && reset == true && beingDragged == true){ 
        uiStorage.storage.TransferItemToInventory(slotID,uiInv);
        reset = false; 
        
       
    }

    if(other.gameObject.CompareTag("ShopSelling") && this.gameObject.CompareTag("Inventory") && reset == true && beingDragged == true){
        characterReference.GetComponent<Charcontroller>().FireFlies += uiInv.inventory.sellingItem(slotID);
        Debug.Log(FireFlies); 
        uiInv.SyncInventory();
        uiShop.SyncShop();
        
        //add switch in inventory to adjust and return price depending on item
    }
    if(other.gameObject.CompareTag("Inventory") && FireFlies < uiShop.Shop.getPrice(slotID) ){
        uiShop.Shop.TransferItemToInventory(slotID, uiInv);
        uiInv.SyncInventory();
        uiShop.SyncShop();
    }

}
public void OnPointerClick(PointerEventData pointerEventData)
    {
         uiInv.Selector = this.slotID;
    }
public void OnPointerUp(PointerEventData pointerEventData){

}
void OnMouseUp() {
    reset = true;
}


void OnCollisionEnter2D(Collision2D other) {
    colliding = true;
}
void OnCollisionExit2D(Collision2D other) {
    colliding = false;
}

void Update(){
    if(gameObject.name == "ShopInventory" || gameObject.name == "ShopInventoryP2" || gameObject.name == "ShopInventoryP3" ){
    costToUi();}

    if(gameObject.name == "Icon" || gameObject.name == "IconP2" || gameObject.name == "IconP3" ){
    AmountToUi();}

    if (Input.GetMouseButtonDown (0)|| Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2)){
   
        originalPosition = this.transform.position;}        

       if (Input.GetMouseButtonUp (0) || Input.GetMouseButtonUp (1) || Input.GetMouseButtonUp (2)){
           uiInv.SyncInventory();
           uiStorage.SyncStorage();
          
           reset = true;
           beingDragged = false;
        if (colliding == false) {
        this.transform.position = originalPosition;
        }}
        
}
public void OnDrag (PointerEventData eventData)
{   
    
    this.beingDragged = true;
        uiInv.Selector = this.slotID;
    this.transform.position += (Vector3)eventData.delta;
}


void AmountToUi(){
    TMP.text = amount.ToString();
}
void costToUi(){
    Cost1.text = uiShop.Shop.getPrice(0).ToString();
    Cost2.text = uiShop.Shop.getPrice(1).ToString();
    Cost3.text = uiShop.Shop.getPrice(2).ToString();
}

}

