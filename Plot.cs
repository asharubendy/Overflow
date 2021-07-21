using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
   public SpriteRenderer spriteRenderer;
public int GrowthStage;
  public int GrowthTime;
   public int itemId;
    public int GetItemId;
   public bool isHarvestable = false; 
   public bool isPlanted = false;
   public Sprite[] Wheat;
   public Sprite[] carrot;
   public Sprite[] apple;

    public GameObject GameManager;
    void Awake() {
        GameManager = GameObject.Find("GameManager");
    }

    void spriteSwitcher(int itemId){
    switch(itemId){
        case 0:
        this.spriteRenderer.sprite = Wheat[0];
        this.isPlanted = true;
        this.GrowthTime = 3;
        this.GrowthStage = 0;
        break;
        
        case 1:
        this.spriteRenderer.sprite = carrot[0];
        this.isPlanted = true;
        this.GrowthTime = 2;
        this.GrowthStage = 0;
        break;

        case 2:
        this.spriteRenderer.sprite = apple[0];
        this.isPlanted = true;
        this.GrowthTime = 5;
        this.GrowthStage = 0;
        break;

        default:
        break;
    }

    }
    void OnMouseDown() {
        //replace itemId with a check for the id via the dictionary 
     if (this.isPlanted == false && itemId == 0){
         spriteSwitcher(itemId);

     };   
     if (this.isPlanted == true && this.isHarvestable == true){
         //harvesting code goes here
     }
    }
    // Update is called once per frame
    void Update()
    {
        GetItemId = GameManager.GetComponent<StartOfGame>().ItemID;
        if (this.GrowthStage == this.GrowthTime) {
            this.isHarvestable = true; 
            this.GrowthStage = 0;
        }
    }
   
}
