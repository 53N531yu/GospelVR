using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class CollectVerse : MonoBehaviour
{
    public SaveManager save;
    public VerseManager verseManager;
    public GameObject move;
    public string verse;
    public int verseIndex;
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
    }

    public void ExitVerseViewer()
    {
        
    }

    public void AddToCollection()
    {
        verseManager.verses[verseIndex] = verse;
        save.Save();
    }
}
