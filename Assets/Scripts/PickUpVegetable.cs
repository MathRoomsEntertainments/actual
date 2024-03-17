using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpVegetable : MonoBehaviour
{

    public bool playerIsClose;
    private int amount;
   

    public GameObject interactionButton;

    // Update is called once per frame
    void Update()
    {
        if (playerIsClose)
        {
           
            interactionButton.SetActive(true);
        }
        else
        {
            interactionButton.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            interactionButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D  other)
    {
        
        if (other.CompareTag("Player"))
        {
            interactionButton.SetActive(false);
            playerIsClose = false;
        
        }
    }
}
