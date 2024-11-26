using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalText : MonoBehaviour
{
    public VerseManager verse;
    public Bench bench;
    public int index;
    public bool isShort = false;
    public GameObject verseText;
    public GameObject notFoundText;
    public GameObject[] miniPage;
    public GameObject scroller;
    public GameObject nextButton;
    public GameObject backButton;
    private GameObject currentPage;
    public int i;

    void Start()
    {
        if (verse == null)
        {
            verse = GameObject.Find("Verse Manager").GetComponent<VerseManager>();
        }

        currentPage = miniPage[i];

        scroller.SetActive(true);
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

        if (bench.pressed) 
        {
            scroller.SetActive(false);
        }

        if (isShort)
        {
            backButton.SetActive(false);
            nextButton.SetActive(false);
        }
        else 
        {
            backButton.SetActive(true);
            nextButton.SetActive(true);
        }
    }

    public void Scroll(bool forward)
    {
        if (forward && i < miniPage.Length - 1) StartCoroutine(ForwardScroll());
        if (!forward && i > 0) StartCoroutine(BackwardScroll());

        if (i == 0) nextButton.SetActive(false);
        else if (i > 0) nextButton.SetActive(true);

        if (i == miniPage.Length - 1) backButton.SetActive(false);
        else if (i < miniPage.Length - 1) backButton.SetActive(true);
    }

    public IEnumerator ForwardScroll()
    {
        currentPage.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        i++;
        currentPage = miniPage[i];
        currentPage.SetActive(true);
    }

    public IEnumerator BackwardScroll()
    {
        currentPage.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        i--;
        currentPage = miniPage[i];
        currentPage.SetActive(true);
    }
}
