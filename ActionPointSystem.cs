using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPointSystem : MonoBehaviour
{
    int apSize;
    public static int apLeft;

    public GameObject[] actionPointOverlay;

    public static bool actionMade = false;

    private void Awake()
    {
        apSize = 4;
        apLeft = apSize;
    }
    void Start()
    {
        
    }

    void Update()
    {
        //if action happens reduce AP
        if(actionMade == true)
        {
            apLeft--;
            actionMade = false;
        }
    }
}
