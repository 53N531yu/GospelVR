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

    public void MoveMountain()
    {
        if (transform.position.y < 100 && transform.position.x < 100) transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        if (transform.position.y > 100 && transform.position.x < 100) transform.Translate(Vector3.right * Time.deltaTime, Space.World);
        if (transform.position.y > 0 && transform.position.x > 100) transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        // yield return null;
    }
}
