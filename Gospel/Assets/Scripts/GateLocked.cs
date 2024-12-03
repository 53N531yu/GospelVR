using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLocked : MonoBehaviour
{
    public int majorVersesNeeded;
    public bool isMountain = false;
    public VerseManager verseManager;
    public GameObject move;
    public GameObject teleport;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if (verseManager.MajorVersesCollected == majorVersesNeeded && !isMountain) 
        {
            Destroy(gameObject);
        }
    }
}
