using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public GameObject ap;

    public UnityEngine.Experimental.Rendering.Universal.Light2D globalLight;
    public UnityEngine.Experimental.Rendering.Universal.Light2D playerPointLight;

    public int currentAP;

    public static int day;
    public static int plotReplys;
    public GameObject DisasterReference;
    public GameObject characterReference;
    // Start is called before the first frame update
    public GameObject[] APIcons; 
    public GameObject rainRef;
    public GameObject appleRef;
    public GameObject Shop;
    public GameObject Gate;
    void Awake(){
        APIcons = new GameObject[5];
        APIcons[0] = GameObject.Find("GameUI Canvas/Action Points/ActionPoint3/ActionPointSlots/Icon");
        APIcons[1] = GameObject.Find("GameUI Canvas/Action Points/ActionPoint3/ActionPointSlots/Icon2"); 
        APIcons[2] = GameObject.Find("GameUI Canvas/Action Points/ActionPoint3/ActionPointSlots/Icon3"); 
        APIcons[3] = GameObject.Find("GameUI Canvas/Action Points/ActionPoint3/ActionPointSlots/Icon4"); 
        APIcons[4] = GameObject.Find("GameUI Canvas/Action Points/ActionPoint3/ActionPointSlots/Icon5"); 
        Shop = GameObject.Find("Grid/ParadiseIsland");
        rainRef = GameObject.Find("Weather");
        appleRef = GameObject.Find("GreenApple");
        DisasterReference = GameObject.Find("DisasterSystem");
        characterReference = GameObject.Find("CharController/Player");
        Gate = GameObject.Find("Grid/Gate");
     
    }
    void Start()
    {
        day = 1;
        Shop.SetActive(false);
        Gate.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        currentAP = ActionPointSystem.apLeft;
        if(currentAP < 5){
            APIcons[4].SetActive(false);
        }
        //Make an action
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActionPointSystem.actionMade = true;
        }

        switch (currentAP)
        {
            case -1:
                globalLight.intensity = 0.2f;
                playerPointLight.intensity = 0.8f;
                appleRef.SetActive(false);
                break;
            case 0:
                globalLight.intensity = 0.4f;
                playerPointLight.intensity = 0.3f;
                APIcons[0].SetActive(false);
                break;
            case 1:
                globalLight.intensity = 0.8f;
                playerPointLight.intensity = 0.1f;
                APIcons[1].SetActive(false);
                break;
            case 2:
                globalLight.intensity = 1f;
                playerPointLight.intensity = 0;
                APIcons[2].SetActive(false);
                break;
            case 3:
                globalLight.intensity = 1.2f;
                playerPointLight.intensity = 0;
                APIcons[3].SetActive(false);
                break;
            case 4:
                globalLight.intensity = 1.2f;
                playerPointLight.intensity = 0;
                APIcons[4].SetActive(false);
                break;
            case 5:
                globalLight.intensity = 1.2f;
                playerPointLight.intensity = 0;
                 APIcons[4].SetActive(true);
            break;
           default:
                globalLight.intensity = 0.8f;
                playerPointLight.intensity = 0;
                
                break;
        }

        //New Day
       
    }
    public void Newday(){
         

  
        switch(currentAP)
        {
            case -1:
                ActionPointSystem.apLeft = 3;
                break;
            case 0:
            case 1:
            case 2:
            case 3:
                ActionPointSystem.apLeft = 4;
                break;
            default:
                break;
        }
            
        rainRef.SetActive(false); 
        DisasterReference.GetComponent<DisasterSystem>().DisasterCheck();
        day++;
        if (day % 7 == 0)
{
        Gate.SetActive(false);
        characterReference.GetComponent<Charcontroller>().ShopItemGeneration();
        Shop.SetActive(true);
}   else {
        Shop.SetActive(false);
        Gate.SetActive(true);
}
        Debug.Log("Day: " + day);
        characterReference.GetComponent<Charcontroller>().alreadyEaten = false;

        for (int i = 0; i < 5; i++)
        {
            APIcons[i].SetActive(true);
            appleRef.SetActive(true);

        }
        if (currentAP == 3)
        {
            APIcons[4].SetActive(false);
            APIcons[5].SetActive(false);       
        }
    }
}
