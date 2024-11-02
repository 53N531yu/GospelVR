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

public class Bench : MonoBehaviour
{
    public GameObject journal;
    public GameObject journalNavigator;
    public GameObject journalButton;
    public GameObject pressToSit;
    public SaveManager save;
    public VerseManager verse;
    public InputActionProperty collectVerseButton;
    public GameObject move;
    public bool canSit;
    public bool isSitting;
    public bool isReading = false;
    
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if (canSit && collectVerseButton.action.WasPressedThisFrame()) BenchSit();

        if (canSit && !isSitting) pressToSit.SetActive(true);
        else if (!canSit || isSitting || isReading) pressToSit.SetActive(false);
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
