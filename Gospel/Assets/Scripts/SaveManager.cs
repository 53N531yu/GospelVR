using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class SaveManager : MonoBehaviour
{
    public VerseManager verse;
    private bool hasAutoSaved = false;
    public float autoSaveTime = 10f;

    void Start()
    {
        if (verse == null)
        {
            verse = GameObject.Find("Verse Manager").GetComponent<VerseManager>();
        }
    }

    void Update()
    {
        if (!hasAutoSaved)
            StartCoroutine(AutoSave());
    }

    public void Save()
    {
    }

    public IEnumerator AutoSave()
    {
        hasAutoSaved = true;
        Save();

        yield return new WaitForSeconds(autoSaveTime);
        hasAutoSaved = false;
    }
}
