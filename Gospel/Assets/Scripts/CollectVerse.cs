using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Windows;
using UnityEngine.InputSystem;
using System;

public class CollectVerse : MonoBehaviour
{
    public SaveManager save;
    public VerseManager verseManager;
    public GameObject move;
    public GameObject teleport;
    public GameObject verseViewer;
    public GameObject pressToInteract;
    public InputActionProperty collectVerseButton;
    public GameObject mountain;
    public GameObject player;
    public Transform teleportLocation;
    public int verseIndex;
    public bool isMajorVerse;
    public bool isTeleportCross;
    public bool isMountainMover;
    public bool canView;
    public bool isViewing;
    public bool hasCollected;
    private bool moveMountain = false;
    
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
        
        if (teleport == null)
        {
            teleport = GameObject.Find("Teleportation");
        }

        if (pressToInteract == null)
        {
            pressToInteract = GameObject.Find("Press To Interact");
        }

        if (mountain == null)
        {
            mountain = GameObject.Find("The Mountain");
        }

        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canView && collectVerseButton.action.WasPressedThisFrame()) 
        {
            if (!isTeleportCross) OpenVerseViewer();
            else if (isTeleportCross) Teleport();
        }

        if (canView && !isViewing) pressToInteract.SetActive(true);
        else if (!canView || isViewing) pressToInteract.SetActive(false);

        if (moveMountain) MoveMountain();
    }

    public void OpenVerseViewer()
    {
        if (!hasCollected) AddToCollection();
        hasCollected = true;
        isViewing = true;
        verseViewer.SetActive(true);
        move.SetActive(false);
        teleport.SetActive(false);
    }

    public void ExitVerseViewer()
    {
        isViewing = false;
        verseViewer.SetActive(false);
        move.SetActive(true);
        teleport.SetActive(true);
        pressToInteract.SetActive(false);
        moveMountain = true;
    }

    public void AddToCollection()
    {
        verseManager.verses[verseIndex] = true;
        if (isMajorVerse) verseManager.MajorVersesCollected ++;
        save.Save();
    }

    public void Teleport()
    {
        if (teleportLocation != null) player.transform.position = teleportLocation.position;
    }

    public void MoveMountain()
    {
        if (mountain.transform.position.y < 25 && mountain.transform.position.x < 250) mountain.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        if (mountain.transform.position.y >= 25 && mountain.transform.position.x < 250) mountain.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
        if (mountain.transform.position.y > -100 && mountain.transform.position.x >= 250) mountain.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
            canView = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
            canView = false;
    }
}
