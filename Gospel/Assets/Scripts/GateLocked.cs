using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLocked : MonoBehaviour
{
    public int majorVersesNeeded;
    public bool isMountain = false;
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
        if (verseManager.MajorVersesCollected == majorVersesNeeded) 
        {
            if (!isMountain) Destroy(gameObject);
            else if (isMountain) StartCoroutine(MoveMountain());
        }
    }

    public IEnumerator MoveMountain()
    {
        yield return null;
    }
}
