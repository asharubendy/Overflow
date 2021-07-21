using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterSystem : MonoBehaviour
{
    InventorySystem inventory;   
    [SerializeField] Ui uiInv;
    public GameObject[] disasterSprites;
    public GameObject[,] plotList; 
    public float karma = 5f;
    bool[] untriggered;
    public GameObject input; 
    public GameObject rainRef;
    bool runonce = false;

    // Start is called before the first frame update
     void Awake() {
    input = GameObject.Find("GameUI Canvas/PlayerInventory/Inventory3");
    inventory = new InventorySystem();
    uiInv.SetIventory(inventory);
    plotList = new GameObject[5,7];
    FindPlots();
    disasterSprites = new GameObject[4];
    
    untriggered = new bool[4];
    rainRef = GameObject.Find("Weather");
    }
    void Start() {
        
        
    }
    void findDisasters(){
    disasterSprites[0] = GameObject.Find("DisasterBL");
    disasterSprites[1] = GameObject.Find("DisasterTR");
    disasterSprites[2] = GameObject.Find("DisasterTL");
    disasterSprites[3] = GameObject.Find("DisasterBR"); 
    disasterSprites[0].SetActive(false); 
    disasterSprites[1].SetActive(false);
    disasterSprites[2].SetActive(false);
    disasterSprites[3].SetActive(false);
    untriggered[0] = true;
    untriggered[1] = true;
    untriggered[2] = true;
    untriggered[3] = true;
    }
    void FindPlots(){
    plotList[0,0] = GameObject.Find("BLDPlot");
    plotList[0,1] = GameObject.Find("BLPlot1");
    plotList[0,2] = GameObject.Find("BLPlot2");
    plotList[0,3] = GameObject.Find("BLPlot3");
    plotList[0,4] = GameObject.Find("BLPlot4");
    plotList[0,5] = GameObject.Find("BLPlot5");

    plotList[1,0] = GameObject.Find("TRPlot");
    plotList[1,1] = GameObject.Find("TRPlot1");
    plotList[1,2] = GameObject.Find("TRPlot2");
    plotList[1,3] = GameObject.Find("TRPlot3");
    plotList[1,4] = GameObject.Find("TRPlot4");
    plotList[1,5] = GameObject.Find("TRPlot5");

    plotList[2,0] = GameObject.Find("TLPlot");
    plotList[2,1] = GameObject.Find("TLPlot1");
    plotList[2,2] = GameObject.Find("TLPlot2");
    plotList[2,3] = GameObject.Find("TLPlot3");
    plotList[2,4] = GameObject.Find("TLPlot4");
    plotList[2,5] = GameObject.Find("TLPlot5");

    plotList[3,0] = GameObject.Find("BRPlot");
    plotList[3,1] = GameObject.Find("BRPlot1");
    plotList[3,2] = GameObject.Find("BRPlot2");
    plotList[3,3] = GameObject.Find("BRPlot3");
    plotList[3,4] = GameObject.Find("BRPlot4");
    plotList[3,5] = GameObject.Find("BRPlot5");
    }
    // Update is called once per frame
    void Update()
    { 
        if (runonce == false){
        findDisasters(); 
        runonce = true;
        } 
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (karma != 1)
            {
                karma--;
            }

            // print("Karma value: " + karma);
        }

        if (Input.GetKeyDown(KeyCode.D))     //Makeshift function to check actual system works
        {
            if (karma != 10)
            {
                karma++;
            }

            // print("Karma value: " + karma);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            DisasterCheck();
        }
    }

public void BuildingMatPassIn(){
        int selector = input.GetComponent<Ui>().Selector;
        Item test = uiInv.inventory.ReturnItemByIndex(selector);
        if(test.isBuildingMaterial() == true){
            uiInv.inventory.RemoveItemByIndexAmount(selector, 1);
            uiInv.SyncInventory();
        }
    }

    public void DisasterCheck()
    {
        float rollNumber = Random.Range(0.1f, 0.9f);        //Rolls random number between bounds
        float bound = karma / 10;

        print(rollNumber);
        print(bound);

        if (rollNumber > bound)
        {
            TriggerDisaster();

            print("triggered disaster");
        }
        else
        {
            print("Disaster failed");
        }
    }

    void TriggerDisaster()
    {   
        rainRef.SetActive(true); 
        GameObject temp;
        int tempBuildStage;
        //  disasterSprites[0] = GameObject.Find("DisasterBL");
        print("triggered disaster");
        rainRef.SetActive(true); 
        int DisasterPicker = Random.Range(1, 5);
        
        if (DisasterPicker == 1 && untriggered[0] == true){
        disasterSprites[0].SetActive(true);
        temp = GameObject.Find("ReinforcementBL");
        tempBuildStage = temp.gameObject.GetComponent<Reinforcement>().buildStage;
        rainRef.SetActive(true); 
        switch(tempBuildStage){
            case 1:
            
            for (int i = 0; i < 6; i++){
                Debug.Log(i);
            if(plotList[0,i].GetComponent<Plot>().isPlanted == true){
               plotList[0,i].GetComponent<Plot>().harvestingAmount -=4;
                } 
            }
            break;
            case 2:
            for (int i = 0; i < 6; i++){
                Debug.Log(i);
                if(plotList[0,i].GetComponent<Plot>().isPlanted == true){
               plotList[0,i].GetComponent<Plot>().harvestingAmount -=3;
                } 
            }
            break;
            case 3: 
            for (int i = 0; i < 6; i++){
                Debug.Log(i);
            if(plotList[0,i].GetComponent<Plot>().isPlanted == true){
               plotList[0,i].GetComponent<Plot>().harvestingAmount -=2;
                } 
            }
            break;
            case 4:
            for (int i = 0; i < 6; i++){
                Debug.Log(i);
            if(plotList[0,i].GetComponent<Plot>().isPlanted == true){
               plotList[0,i].GetComponent<Plot>().harvestingAmount -=1;
                } 
            }
            break;
            case 5:
            disasterSprites[0].SetActive(false);
            break;
            default:
            break;

        }      
    }
        //  disasterSprites[0] = GameObject.Find("DisasterTR");
        if (DisasterPicker == 2 && untriggered[1] == true){
           disasterSprites[1].SetActive(true);
         temp = GameObject.Find("ReinforcementTR");
        tempBuildStage = temp.gameObject.GetComponent<Reinforcement>().buildStage;
        rainRef.SetActive(true); 
        switch(tempBuildStage){
            case 0:
            for (int i = 0; i < 6; i++){
            if(plotList[1,i].GetComponent<Plot>().isPlanted == true){
               plotList[1,i].GetComponent<Plot>().harvestingAmount -=4;
                } 
            }
            break;
            case 1:
            for (int i = 0; i < 6; i++){
            if(plotList[1,i].GetComponent<Plot>().isPlanted == true){
               plotList[1,i].GetComponent<Plot>().harvestingAmount -=3; } 
            }
            break;
            case 2: 
            for (int i = 0; i < 6; i++){
            if(plotList[1,i].GetComponent<Plot>().isPlanted == true){
               plotList[1,i].GetComponent<Plot>().harvestingAmount -=2;
                } 
            }
            break;
            case 3:
            for (int i = 0; i < 6; i++){
            if(plotList[1,i].GetComponent<Plot>().isPlanted == true){
               plotList[1,i].GetComponent<Plot>().harvestingAmount -=1;
                } 
            }
            break;
            case 4:
            disasterSprites[1].SetActive(false);
            break;
            default:
            break;

        }      
    }
        // disasterSprites[2] = GameObject.Find("DisasterTL");
        if (DisasterPicker == 3 && untriggered[2] == true){
           disasterSprites[2].SetActive(true);
         temp = GameObject.Find("ReinforcementTL");
        tempBuildStage = temp.gameObject.GetComponent<Reinforcement>().buildStage;
        rainRef.SetActive(true); 
    
        switch(tempBuildStage){
            case 1:
            for (int i = 0; i < 6; i++){
            if(plotList[2,i].GetComponent<Plot>().isPlanted == true){
               plotList[2,i].GetComponent<Plot>().harvestingAmount -=4;
                } 
            }
            break;
            case 2:
            for (int i = 0; i < 6; i++){
            if(plotList[2,i].GetComponent<Plot>().isPlanted == true){
               plotList[2,i].GetComponent<Plot>().harvestingAmount -=3;
                } 
            }
            break;
            case 3: 
            for (int i = 0; i < 6; i++){
            if(plotList[2,i].GetComponent<Plot>().isPlanted == true){
               plotList[2,i].GetComponent<Plot>().harvestingAmount -=2;
                } 
            }
            break;
            case 4:
            for (int i = 0; i < 6; i++){
            if(plotList[2,i].GetComponent<Plot>().isPlanted == true){
               plotList[2,i].GetComponent<Plot>().harvestingAmount -=1;
                } 
            }
            break;
            case 5:
            disasterSprites[3].SetActive(false);
            break;
            default:
            break;

        }      
    }
         // disasterSprites[3] = GameObject.Find("DisasterBR"); 
        if (DisasterPicker == 4 && untriggered[3] == true){
          disasterSprites[3].SetActive(true);
         temp = GameObject.Find("ReinforcementBR");
        tempBuildStage = temp.gameObject.GetComponent<Reinforcement>().buildStage;
        rainRef.SetActive(true); 
        switch(tempBuildStage){
            case 1:
            for (int i = 0; i < 6; i++){
            if(plotList[3,i].GetComponent<Plot>().isPlanted == true){
               plotList[3,i].GetComponent<Plot>().harvestingAmount -=4;
                } 
            }
            break;
            case 2:
            for (int i = 0; i < 6; i++){
            if(plotList[3,i].GetComponent<Plot>().isPlanted == true){
               plotList[3,i].GetComponent<Plot>().harvestingAmount -=3;
                } 
            }
            break;
            case 3: 
            for (int i = 0; i < 6; i++){
            if(plotList[3,i].GetComponent<Plot>().isPlanted == true){
               plotList[3,i].GetComponent<Plot>().harvestingAmount -=2;
                } 
            }
            break;
            case 4:
            for (int i = 0; i < 6; i++){
            if(plotList[3,i].GetComponent<Plot>().isPlanted == true){
               plotList[3,i].GetComponent<Plot>().harvestingAmount -=1;
                } 
            }
            break;
            case 5:
            disasterSprites[3].SetActive(false);
            break;
            default:
            break;
            

        }      
     }
    }   
}

