using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public GameObject interactionButton;
    public bool playerIsClose;
    // ------------------------------ \\
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;



    public GameObject contButton;
    public float wordSpeed;
    
    
    

    // Update is called once per frame
    void Update()
    {
        if (playerIsClose && !dialoguePanel.activeInHierarchy)
        {
            interactionButton.SetActive(true);
        }
        else
        {
            interactionButton.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {

            if(dialoguePanel.activeInHierarchy) 
            {

                StopAllCoroutines();
                zeroText();
                interactionButton.SetActive(true);
            }
            else
            {
                StopAllCoroutines();
                dialoguePanel.SetActive(true);
                
                StartCoroutine(Typing());
                interactionButton.SetActive(false);
            }
        }
        
        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
 
        

        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        interactionButton.SetActive(false);
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            playerIsClose = false;
            zeroText();
        }
    }
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    public void NextLine()
    {
        contButton.SetActive(false);


        if (index < dialogue.Length - 1)
        {
            StopAllCoroutines();    
            index++;
            dialogueText.text = "";
            
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
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
}
