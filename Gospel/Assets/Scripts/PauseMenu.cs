using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Windows;
using JetBrains.Annotations;
using UnityEngine.Video;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public bool paused;
    public InputActionProperty collectVerseButton;
    

    [Header("Pause Menu Canvas")]
    public GameObject canvas;

    [Header("Attached UI Elements")]
    public GameObject pausemenu;

    [Header("Attached Systems")]
    public EventSystem eventSystem;
    public SaveManager save;

    [Header("Selected Buttons")]
    public GameObject resumebutton;

    void Start(){
        if(eventSystem == null){
            eventSystem = GameObject.Find("InputManager").GetComponent<EventSystem>();
            UnityEngine.Debug.Log("EventSystem not attached to Pause prefab");
        }

        if(save == null){
            save = GameObject.Find("SaveManager").GetComponent<SaveManager>();
            UnityEngine.Debug.Log("SaveManager not attached to Pause prefab");
        }
    }

    void Update()
    {
        if(collectVerseButton.action.WasPressedThisFrame())
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pausing();
            }
        }

    }

    public void Resume()
    {
        paused = false;
        canvas.SetActive(false);
        pausemenu.SetActive(true);

        Time.timeScale = 1f;
    }

    public void Pausing()
    {
        paused = true;
        canvas.SetActive(true);
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        eventSystem.SetSelectedGameObject(resumebutton);
    }

    public void Play()
    {
        SceneManager.LoadScene("BasicScene");
    }

    public void MainMenu()
    {
        // StartCoroutine(DelayMainMenu());
        save.Save();
        paused = false;
        canvas.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ActivatePauseMenu(){

        // Activate correct menu
        pausemenu.SetActive(true);

        // Deactivate other menus

        // Set selected button
        eventSystem.SetSelectedGameObject(resumebutton);
    }
}
