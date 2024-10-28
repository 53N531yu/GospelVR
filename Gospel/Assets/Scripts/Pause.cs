using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Pause : MonoBehaviour
{
    public bool paused;
    public GameObject pausemenu;
    public SaveManager save;

    void Start()
    {
        if(save == null){
            save = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        }
    }

    void Update()
    {
        
    }

    public void Resume()
    {

    }

    public void Pausing()
    {

    }

    public void Menu()
    {
        
    }
}
