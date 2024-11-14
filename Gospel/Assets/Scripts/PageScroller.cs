using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScroller : MonoBehaviour
{
    public GameObject[] miniPage;
    public GameObject scroller;
    public GameObject ForwardButton;
    public GameObject BackwardButton;
    private GameObject currentPage;
    private int i;

    void Start()
    {
        if (ForwardButton == null)
        {
            ForwardButton = GameObject.Find("Next part");
        }
        
        if (BackwardButton == null)
        {
            BackwardButton = GameObject.Find("Previous part");
        }

        scroller.SetActive(true);

        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scroll(bool forward)
    {
        if (forward && i < miniPage.Length - 1) StartCoroutine(ForwardScroll());
        if (!forward && i > 0) StartCoroutine(BackwardScroll());

        if (currentPage == miniPage[0]) BackwardButton.SetActive(false);
        else BackwardButton.SetActive(true);

        if (currentPage == miniPage[0]) ForwardButton.SetActive(false);
        else ForwardButton.SetActive(true);
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
