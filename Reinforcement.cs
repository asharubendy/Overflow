using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforcement : MonoBehaviour
{
    InventorySystem inventory;   
    [SerializeField] Ui uiInv;
    public Sprite[] spriteArray;
    public int buildStage = 0;
    public GameObject DisasterRef;
    GameObject input; 
    public Material[] materials;
    Renderer rend;
    GameObject[] disasterSprites; 
    GameObject player;
    void Awake() {
        
        GameObject.Find("GameManager");
     disasterSprites = new GameObject[4]; 
    input = GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3");
    inventory = new InventorySystem();
    uiInv.SetIventory(inventory);
        DisasterRef = GameObject.Find("DisasterSystem");
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = materials[1];
    
    disasterSprites[0] = GameObject.Find("DisasterBL");
    disasterSprites[1] = GameObject.Find("DisasterTR");
    disasterSprites[2] = GameObject.Find("DisasterTL");
    disasterSprites[3] = GameObject.Find("DisasterBR"); 
    }
    void OnMouseEnter() {
    rend.sharedMaterial = materials[1];
    }
    void OnMouseExit() {
    rend.sharedMaterial = materials[0];    
    }
    void OnMouseDown() {
    if(player.GetComponent<Charcontroller>().gameManager.GetComponent<DayNightCycle>().currentAP >= 0){
    if (buildStage < 4){
    BuildingMatPassIn();
    ActionPointSystem.actionMade = true;
    }
    }}
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update() {
        switch(buildStage){
            case 0:
            GetComponent<SpriteRenderer>().sprite = spriteArray[0];
            break;

            case 1:
            GetComponent<SpriteRenderer>().sprite = spriteArray[1];
            break;

            case 2:
            GetComponent<SpriteRenderer>().sprite = spriteArray[2];
            break;

            case 3:
            GetComponent<SpriteRenderer>().sprite = spriteArray[3];
            break;

            case 4:
            GetComponent<SpriteRenderer>().sprite = spriteArray[4];
            break;

            default:
            break;
        }
        if (buildStage >= 4){
            switch (gameObject.name){
                case "ReinforcementBR":
                
                 if(disasterSprites[3].activeInHierarchy == true){
                    disasterSprites[3].SetActive(false);
                    buildStage = 0;
                }
                break;
                case "ReinforcementBL":
                
                 if(disasterSprites[0].activeInHierarchy == true){
                    disasterSprites[0].SetActive(false);
                    buildStage = 0;
                }
                break;
                case "ReinforcementTR":
                
                 if(disasterSprites[1].activeInHierarchy == true){
                    disasterSprites[1].SetActive(false);
                    buildStage = 0;
                }
                break;
                case "ReinforcementTL": 
                
                if(disasterSprites[2].activeInHierarchy == true){
                    disasterSprites[2].SetActive(false);
                    buildStage = 0;
                }
                break;
            }
        }
        
    }

        public void BuildingMatPassIn(){
           if (uiInv.inventory.checkListIsPopulated() == true){
        int selector = input.GetComponent<Ui>().Selector;
        Item test = uiInv.inventory.ReturnItemByIndex(selector);
        if(test.isBuildingMaterial() == true){
            uiInv.inventory.RemoveItemByIndexAmount(selector, 1);
            uiInv.SyncInventory();
            buildStage++;
        }
    }
    }
    
}
