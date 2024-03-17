using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class checkCollide : MonoBehaviour
{
    public bool Debug;


    public bool playerIsClose;

 
    public bool toFood;
    public bool toDiag;
    public bool toPaper;
    public bool toLocker1;

    public bool foodAcquired;
    public bool onPaper;
    public bool isLocker2Unlocked;




    public Text dialogueText;
    public GameObject dialoguePanel;
    public string[] dialogue;
    public string[] dialogueforFood;


    public Text dialogueTextForFood;
    public GameObject dialoguePanelFood;
    public string[] dialogueforFoodPlayer;


    public Text dialogueTextForPaper;
    public GameObject dialoguePanelPaper;
    public string[] dialogueforPaper;


    public Text dialogueTextForLocker1;
    public GameObject dialoguePanelLocker1;
    public string[] dialogueforLocker1;



    public GameObject contButtonFood;
    public GameObject contButton;
    public GameObject contButtonPaper;



    public float wordSpeed;
    public GameObject interactionButton;

    







    private int amount;
    private int index;
    
    
    

    
    void Update()
    {

        if (toFood && playerIsClose && !foodAcquired)
        {
                
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {
                foodAcquired = true;

                zeroText();
                StopAllCoroutines();
                dialoguePanelFood.SetActive(true);

                StartCoroutine(Typing());

            }
            if (!interactionButton.activeInHierarchy)
            {
                interactionButton.SetActive(true);

            }


        }




        else if (toDiag && playerIsClose)
        {
            if (playerIsClose && !dialoguePanel.activeInHierarchy && toDiag)
            {
                interactionButton.SetActive(true);
            }
            else
            {
                interactionButton.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {

                if (dialoguePanel.activeInHierarchy)
                {

                    StopAllCoroutines();
                    zeroText();
                    interactionButton.SetActive(true);
                }
                else
                {
                    zeroText();
                    StopAllCoroutines();
                    dialoguePanel.SetActive(true);

                    StartCoroutine(Typing());
                }
            }

        }




        else if (toPaper && playerIsClose && !onPaper)
        {
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {
                onPaper = true;

                zeroText();
                StopAllCoroutines();
                dialoguePanelPaper.SetActive(true);

                StartCoroutine(Typing());

            }

            if (!interactionButton.activeInHierarchy)
            {
                interactionButton.SetActive(true);

            }
            else if(interactionButton.activeInHierarchy && onPaper)
            {
                interactionButton.SetActive(false);
            }


            



        }
        else if (toPaper && playerIsClose && onPaper && !Debug)
        {
            onPaper = false;
            zeroText();
        }
        else
        {
            
            interactionButton.SetActive(false);
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        playerIsClose = true;
        if (other.CompareTag("food"))
        {
           toFood = true;
        }

        if (other.CompareTag("dialogue1"))
        {
            toDiag = true;
        }

        if (other.CompareTag("paper"))
        {
            toPaper = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        playerIsClose = false;
        toFood=false;
        toDiag=false;
        toPaper=false; 
        interactionButton.SetActive(false);
        StopAllCoroutines();
        zeroText();
    }



    public void zeroText()
    {
        dialogueText.text = "";
        dialogueTextForFood.text = "";
        dialogueTextForPaper.text = "";
        
        index = 0;
        dialoguePanel.SetActive(false);
        dialoguePanelFood.SetActive(false);
        dialoguePanelPaper.SetActive(false);
    }

    public void NextLine()
    {
        Debug = false;
       
    
        if(foodAcquired && toFood)
        {
            contButtonFood.SetActive(true);
        }
        if(foodAcquired && toDiag)
        {
            contButton.SetActive(true);
        }
        if(onPaper && toPaper)
        {
            contButtonPaper.SetActive(true);
        }
        


        if (index < dialogue.Length - 1 && toDiag && !foodAcquired)
        {
            StopAllCoroutines();
            index++;
            dialogueText.text = "";
            dialogueTextForFood.text = "";
            dialogueTextForPaper.text = "";

            StartCoroutine(Typing());

        }
        else if(index < dialogueforFood.Length - 1 && foodAcquired && toDiag)
        {
            StopAllCoroutines();
            index++;
            dialogueText.text = "";
            dialogueTextForFood.text = "";
            dialogueTextForPaper.text = "";

            StartCoroutine(Typing());
        }
        else if(index < dialogueforFoodPlayer.Length - 1 && toFood)
        {
            StopAllCoroutines();
            index++;
            dialogueText.text = "";
            dialogueTextForFood.text = "";
            dialogueTextForPaper.text = "";


            StartCoroutine(Typing());
        }
        else if(index < dialogueforPaper.Length - 1 && toPaper)
        {
            StopAllCoroutines();
            index++;
            dialogueText.text = "";
            dialogueTextForFood.text = "";
            dialogueTextForPaper.text = "";

            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            interactionButton.SetActive(true);
        }

    }
    IEnumerator Typing()
    {
        if (!foodAcquired && toDiag)
        {
            foreach (char letter in dialogue[index].ToCharArray())
            {
                Debug = true;
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
                
            }
        }
        else if(foodAcquired && toDiag)
        {
            foreach (char letter in dialogueforFood[index].ToCharArray())
            {
                Debug = true;
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
                
            }
        }
        else if(foodAcquired && toFood){
            foreach (char letter in dialogueforFoodPlayer[index].ToCharArray())
            {
                Debug = true;
                dialogueTextForFood.text += letter;
                yield return new WaitForSeconds(wordSpeed);
                
            }
        }
        else if (toPaper)
        {
            foreach (char letter in dialogueforPaper[index].ToCharArray())
            {
                Debug = true;
                dialogueTextForPaper.text += letter;
                yield return new WaitForSeconds(wordSpeed);
                
            }
        }
    }

    


}
