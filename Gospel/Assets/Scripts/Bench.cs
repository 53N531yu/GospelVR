using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Bench : MonoBehaviour
{
    public GameObject journal;
    public SaveManager save;
    public VerseManager verse;
    public bool canSit;
    public bool isSitting;
    public bool isViewing = false;
    
    void Start()
    {
        if (journal == null)
        {
            journal = GameObject.Find("Journal");
        }
        if (save == null)
        {
            save = GameObject.Find("Save Manager").GetComponent<SaveManager>();
        }

        if (verse == null)
        {
            verse = GameObject.Find("Verse Manager").GetComponent<VerseManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSit) BenchSit();

        if (isSitting) 
        {
            DisplayBenchUI();
        }

        else if (!isSitting)
        {
            HideBenchUI();
        }
    }

    public void DisplayBenchUI()
    {

    }

    public void HideBenchUI()
    {

    }

    public void OpenJournal()
    {
        
    }

    public void CloseJournal()
    {
        
    }

    public void BenchSit()
    {
        isSitting = true;
        save.Save();
    }

    public void ExitBench()
    {
        isSitting = false;
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
