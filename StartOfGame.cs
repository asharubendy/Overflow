using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfGame : MonoBehaviour
{
    public GameObject[] inventorySizeOverlay;
    public GameObject[] actionPointOverlay;
    public GameObject plot, plot2, plot3;
    public int ActionPoint_starting = 3;
    public int ActionPoint_Upgrades = 0;
    public int ActionPoint_Left; 
    
    public int ItemID; 
    public int Day = 0;
    
    public void NewDay() {
        ActionPoint_Left = ActionPoint_starting + ActionPoint_Upgrades;
        plot.GetComponent<Plot>().GrowthStage++ ;
    }


    void Awake()
    {
        inventorySizeOverlay[0].SetActive(true);
        inventorySizeOverlay[1].SetActive(false);
        inventorySizeOverlay[2].SetActive(false);
        inventorySizeOverlay[3].SetActive(false);

        actionPointOverlay[0].SetActive(true);
        actionPointOverlay[1].SetActive(false);
        actionPointOverlay[2].SetActive(false);
        actionPointOverlay[3].SetActive(false);
        
        NewDay();
    }
     void Start() {
        plot = GameObject.Find("plot");
        plot2 = GameObject.Find("plot2");
        plot3 = GameObject.Find("plot3");
    }
    void Update()
    {           
        //testing plot placement - should switch on ui switch
        ItemID = 0;
        //for testing purposes to show the change in UI
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (inventorySizeOverlay[0].activeSelf == true)
            {
                inventorySizeOverlay[0].SetActive(false);
                inventorySizeOverlay[1].SetActive(true);

                actionPointOverlay[0].SetActive(false);
                actionPointOverlay[1].SetActive(true);
            }
            else if (inventorySizeOverlay[1].activeSelf == true)
            {
                inventorySizeOverlay[1].SetActive(false);
                inventorySizeOverlay[2].SetActive(true);

                actionPointOverlay[1].SetActive(false);
                actionPointOverlay[2].SetActive(true);
            }
            else if (inventorySizeOverlay[2].activeSelf == true)
            {
                inventorySizeOverlay[2].SetActive(false);
                inventorySizeOverlay[3].SetActive(true);

                actionPointOverlay[2].SetActive(false);
                actionPointOverlay[3].SetActive(true);
            }
            else if (inventorySizeOverlay[3].activeSelf == true)
            {
                inventorySizeOverlay[3].SetActive(false);
                inventorySizeOverlay[0].SetActive(true);

                actionPointOverlay[3].SetActive(false);
                actionPointOverlay[0].SetActive(true);
            }
        }
    }
}

    

    

