using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalText : MonoBehaviour
{
    public VerseManager verse;
    public int index;
    public GameObject verseText;
    public GameObject notFoundText;


    void Start()
    {
        if (verse == null)
        {
            verse = GameObject.Find("Verse Manager").GetComponent<VerseManager>();
        }
    }

    void Update()
    {
        if (verse.verses[index])
        {
            verseText.SetActive(true);
            notFoundText.SetActive(false);
        }
        else if (!verse.verses[index])
        {
            verseText.SetActive(false);
            notFoundText.SetActive(true);
        }
    }
}
