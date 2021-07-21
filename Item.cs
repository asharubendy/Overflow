using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType {
        Apple,
        Wheat,
        Carrot,
        AppleSeed,

        WheatSeed,
        CarrotSeed,
        Wood,
        Compost,
    }
    public ItemType itemType;
    public int amount;
    public int ID;
    public bool isStackable() {
        switch (itemType) {
            default:
            case ItemType.Wheat:
            return true; 
            case ItemType.Apple:
            return true; 
            case ItemType.Carrot:
            return true; 
            case ItemType.Wood:
            return true; 
            case ItemType.Compost:
            return true;
        }
    }
    public bool isPlantable() {
        switch(itemType){
            default:
             case ItemType.Wheat:
            return false; 
            case ItemType.Apple:
            return false; 
            case ItemType.Carrot:
            return false; 
            case ItemType.Wood:
            return false; 
            case ItemType.AppleSeed:
            return true;
            case ItemType.WheatSeed:
            return true;
            case ItemType.CarrotSeed:
            return true;
            case ItemType.Compost:
            return false;
        }
    }
    public bool isEdible(){
        switch(itemType){
            default:
             case ItemType.Wheat:
            return true; 
            case ItemType.Apple:
            return true; 
            case ItemType.Carrot:
            return true; 
            case ItemType.Wood:
            return true; 
            case ItemType.AppleSeed:
            return false;
            case ItemType.WheatSeed:
            return false;
            case ItemType.CarrotSeed:
            return false;
            case ItemType.Compost:
            return false;
        }

    }

    public int SellPrice(){
        switch(itemType) {
            default:
            case ItemType.Wheat:
            return 5; 
            case ItemType.Apple:
            return 6; 
            case ItemType.Carrot:
            return 4; 
            case ItemType.Wood:
            return 10; 
            case ItemType.Compost:
            return 15;
        }
    }
     public int BuyPrice(){
        switch(itemType) {
            default:
            case ItemType.Wheat:
            return 7; 
            case ItemType.Apple:
            return 8; 
            case ItemType.Carrot:
            return 6; 
            case ItemType.Wood:
            return 12; 
            case ItemType.Compost:
            return 20;
        }
    }


    public int ItemTypeToID() {
        switch (itemType) {
            default:
            case ItemType.Apple:
            return 0;
            case ItemType.Wheat:
            return 1;
            case ItemType.Wood:
            return 2; 
            case ItemType.Carrot:
            return 3; 
            case ItemType.WheatSeed:
            return 4; 
            case ItemType.AppleSeed:
            return 5; 
            case ItemType.CarrotSeed:
            return 6;
            case ItemType.Compost:
            return 7; 
            
        }
    }

    public ItemType SeedToItem(){
        switch(itemType){
            default:
            case ItemType.AppleSeed:
            return ItemType.Apple;
            case ItemType.WheatSeed:
            return ItemType.Wheat;
            case ItemType.CarrotSeed:
            return ItemType.Carrot;
        }
    }
    
    public ItemType ItemToSeed(){
        switch(itemType){
            default:
            case ItemType.Apple:
            return ItemType.AppleSeed;
            case ItemType.Wheat:
            return ItemType.WheatSeed;
            case ItemType.Carrot:
            return ItemType.CarrotSeed;
        }
    }
    public int harvestingAmount(){
        switch(itemType){
            default:
            case ItemType.Apple:
            return 5;
            case ItemType.WheatSeed:
            return 6;
            case ItemType.CarrotSeed:
            return 7;
        }
    }
    public bool isBuildingMaterial(){
        switch(itemType){
            default:
            case ItemType.Apple:
            return false;
            case ItemType.Wheat:
            return false;
            case ItemType.Wood:
            return true; 
            case ItemType.Carrot:
            return false; 
            case ItemType.WheatSeed:
            return false; 
            case ItemType.AppleSeed:
            return false; 
            case ItemType.CarrotSeed:
            return false;
        }
    }
     public bool isCompost(){
        switch(itemType){
            default:
            case ItemType.Apple:
            return false;
            case ItemType.Wheat:
            return false;
            case ItemType.Wood:
            return false; 
            case ItemType.Carrot:
            return false; 
            case ItemType.WheatSeed:
            return false; 
            case ItemType.AppleSeed:
            return false; 
            case ItemType.CarrotSeed:
            return false;
            case ItemType.Compost:
            return true; 
        }
    }
    public bool isCompostable(){
        switch(itemType){
            default:
            case ItemType.Apple:
            return true;
            case ItemType.Wheat:
            return true;
            case ItemType.Wood:
            return true; 
            case ItemType.Carrot:
            return true; 
            case ItemType.WheatSeed:
            return false; 
            case ItemType.AppleSeed:
            return false; 
            case ItemType.CarrotSeed:
            return false;
            case ItemType.Compost:
            return false; 
        }
    }
    public ItemType IdToItemType() {
        switch(ID) {
        default:
        case 0:
        return ItemType.Apple;
        case 1:
        return ItemType.Wheat;
        case 2:
        return ItemType.Wood;
        case 3:
        return ItemType.Carrot;
        }
    } 
    public int APeffect; 
}
