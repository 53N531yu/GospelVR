using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLocation : MonoBehaviour
{
    public SaveManager save;
    public VerseManager verseManager;
    public InputActionProperty collectVerseButton;

    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
