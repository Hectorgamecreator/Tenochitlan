using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HectorRodriguez;
using Unity.VisualScripting;
using System;
using static UnityEngine.UI.Button;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;   
    public float wordSpeed;
   [HideInInspector] public bool playerIsClose;

    [SerializeField] CraftingRecipe NeededElixir;
    ButtonClickedEvent onCont;
    bool firstEncounter;
    [SerializeField] UnityEvent onQuestSucced;
    [SerializeField] TMP_Text CurrentQuestTMP;
    bool QuestDone;
    private void Start()
    {
        onCont = contButton.GetComponent<Button>().onClick;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!firstEncounter)
            {
                if (dialoguePanel.activeInHierarchy)
                {
                    zeroText();
                }
                else
                {
                    dialoguePanel.SetActive(true);
                    onCont.AddListener(NextLine);
                    StartCoroutine(Typing());

                }
            }
            else //player started the mission of this npc instance before
            {
                if (NeededElixir.isCrafted)//player succeded
                {
                    dialoguePanel.SetActive(true);
                    dialogueText.text = "YOU SAVED ME!";
                    CurrentQuestTMP.text = "";
                 
                    if (!QuestDone)
                    {
                        onQuestSucced.Invoke();
                        QuestDone = true;
                        //todo I would suggest destroying this NPC after the mission is done
                    }

                }
                else //player still looking for medicine
                {
                    dialoguePanel.SetActive(true);
                    dialogueText.text = "I STILL NEED YOUR HELP!";

                }
            }
        }

        //if(dialogueText.text == dialogue[index])
        //{
        //    contButton.SetActive(true); 
        //}
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        onCont.RemoveListener(NextLine);

    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        contButton.SetActive(true);
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if(index < dialogue.Length-1 )
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            firstEncounter = true;
            CurrentQuestTMP.text = NeededElixir.name;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false; 
            zeroText();
        }
    }
}
