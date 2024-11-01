using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Windows;
using System;

public class CollectVerse : MonoBehaviour
{
    public SaveManager save;
    public VerseManager verseManager;
    public GameObject move;
    public GameObject verseViewer;
    public string verse;
    public int verseIndex;
    public bool canView;
    public bool hasCollected;
    public bool isViewing = false;
    
    void Start()
    {
        if (save == null)
        {
            save = GameObject.Find("Save Manager").GetComponent<SaveManager>();
        }

        if (verseManager == null)
        {
            verseManager = GameObject.Find("Verse Manager").GetComponent<VerseManager>();
        }

        if (move == null)
        {
            move = GameObject.Find("Move");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isViewing) OpenVerseViewer();
        else if (!isViewing) ExitVerseViewer();
    }

    public void OpenVerseViewer()
    {
        if (!hasCollected) AddToCollection();
        verseViewer.SetActive(true);
        move.SetActive(false);
        Console.WriteLine("Hello???");
    }

    public void ExitVerseViewer()
    {
        
    }

    public void AddToCollection()
    {
        // verseManager.verses[verseIndex] = verse;
        save.Save();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
            isViewing = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
            isViewing = false;
    }
}
