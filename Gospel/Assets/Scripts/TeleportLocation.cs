using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLocation : MonoBehaviour
{
    public VerseManager verseManager;

    // Start is called before the first frame update
    void Start()
    {
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
