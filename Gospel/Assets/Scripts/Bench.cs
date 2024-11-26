using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Windows;
using UnityEngine.InputSystem;
using System;

public class Bench : MonoBehaviour
{
    public GameObject[] pages = new GameObject[20];
    private GameObject currentPage;
    public int i = 0;
    public GameObject journal;
    public GameObject journalNavigator;
    public GameObject journalButton;
    public GameObject pressToSit;
    public GameObject ForwardButton;
    public GameObject BackwardButton;
    public SaveManager save;
    public VerseManager verse;
    public InputActionProperty collectVerseButton;
    public GameObject move;
    public GameObject teleport;
    public bool canSit;
    public bool isSitting;
    public bool isReading = false;
    public bool pressed;
    
    void Start()
    {
        currentPage = pages[i];

        if (journal == null)
        {
            journal = GameObject.Find("Journal");
        }

        if (journalButton == null)
        {
            journalButton = GameObject.Find("Open Journal");
        }

        if (save == null)
        {
            save = GameObject.Find("Save Manager").GetComponent<SaveManager>();
        }

        if (verse == null)
        {
            verse = GameObject.Find("Verse Manager").GetComponent<VerseManager>();
        }

        if (pressToSit == null)
        {
            pressToSit = GameObject.Find("Press To Sit");
        }

        if (move == null)
        {
            move = GameObject.Find("Move");
        }
        
        if (teleport == null)
        {
            teleport = GameObject.Find("Teleportation");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSit && collectVerseButton.action.WasPressedThisFrame() && !isSitting) BenchSit();

        if (canSit && !isSitting) pressToSit.SetActive(true);
        else if (!canSit || isSitting || isReading) pressToSit.SetActive(false);

        if (currentPage == pages[0]) BackwardButton.SetActive(false);
        else BackwardButton.SetActive(true);

        if (currentPage == pages[20]) ForwardButton.SetActive(false);
        else ForwardButton.SetActive(true);
    }

    public void DisplayBenchUI()
    {

    }

    public void HideBenchUI()
    {

    }

    public void OpenJournal()
    {
        isReading = true;
        pressToSit.SetActive(false);
        journal.SetActive(true);
        journalNavigator.SetActive(true);
        pages[i].SetActive(true);
        journalButton.SetActive(false);
    }

    public void CloseJournal()
    {
        isReading = false;
        journal.SetActive(false);
        journalNavigator.SetActive(false);
        BenchSit();
    }

    public void BenchSit()
    {
        isSitting = true;
        journalButton.SetActive(true);
        move.SetActive(false);
        teleport.SetActive(false);
        save.Save();
    }

    public void ExitBench()
    {
        isSitting = false;
        isReading = false;
        journal.SetActive(false);
        journalNavigator.SetActive(false);
        journalButton.SetActive(false);
        move.SetActive(true);
        teleport.SetActive(true);
    }

    public void TurnPage(bool forward)
    {
        if (forward && i < pages.Length) StartCoroutine(NextVerse());
        if (!forward && i > 0) StartCoroutine(PreviousVerse());
        pressed = true;
    }

    public IEnumerator NextVerse()
    {
        currentPage.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        i++;
        currentPage = pages[i];
        currentPage.SetActive(true);
        pressed = false;
    }

    public IEnumerator PreviousVerse()
    {
        currentPage.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        i--;
        currentPage = pages[i];
        currentPage.SetActive(true);
        pressed = false;
    }
    
    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
            canSit = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
            canSit = false;
    }

}
