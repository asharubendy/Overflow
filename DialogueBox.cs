using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    private bool finished = false;
    public TextMeshProUGUI dialogueTxt;
    public static int textOption;

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("DialogeBoxScript");
        switch(textOption)
        {
            case 1:
                Debug.Log("Plot too far away");
                dialogueTxt.text = "Too far away from plot.      " + "Please get closer";
                StartCoroutine(Wait());
                break;
            case 2:
                dialogueTxt.text = "Nothing in inventory!";
                StartCoroutine(Wait());
                break;
            case 3:
                dialogueTxt.text = "No space to add items!";
                StartCoroutine(Wait());
                break;
            case 4: 
                dialogueTxt.text = "No Action points left!";
                StartCoroutine(Wait());
                break;
            case 5:
                dialogueTxt.text = "Press 'E' to sleep!";
                break;
            default:
                break;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
        finished = true;
    }

    void Update()
    {
        if (Charcontroller.canSleep == true && textOption == 5)
        {
            finished = false;
        }
        else if(Charcontroller.canSleep == false && textOption == 5)
        {
            finished = true;
        }

        if (finished == true)
        {
            finished = false;
            textOption = 0;
            this.gameObject.SetActive(false);
            this.GetComponent<DialogueBox>().enabled = false;
        }
    }
}
