using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaylistShuffle : MonoBehaviour
{
    private static PlaylistShuffle _instance;
    public static PlaylistShuffle Instance
    {
        get
        {
            return _instance;
        }
    }
    private AudioSource _audiosource;
    public AudioClip[] pieces;
    private float _trackTimer;
    private float _piecesPlayed;
    private bool[] _beenPlayed;

    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        _beenPlayed = new bool[pieces.Length];

        if (!_audiosource.isPlaying)
            ChangePiece(Random.Range(0, pieces.Length));
    }

    void Update()
    {
        if (_audiosource.isPlaying)
            _trackTimer += 1 * Time.deltaTime;
        
        if (!_audiosource.isPlaying || _trackTimer >= _audiosource.clip.length + 10f)
            ChangePiece(Random.Range(0, pieces.Length));
        
        ResetShuffle();
    }

    public void ChangePiece(int piecePicked)
    {
        if (!_beenPlayed[piecePicked])
        {
            _trackTimer = 0;
            _piecesPlayed++;
            _beenPlayed[piecePicked] = true;
            _audiosource.clip = pieces[piecePicked];
            _audiosource.Play();
        }
        else _audiosource.Stop();
    }

    private void ResetShuffle()
    {
        if (_piecesPlayed == pieces.Length)
        {
            _piecesPlayed = 0;
            for (int i = 0; i < pieces.Length; i++)
            {
                if (i == pieces.Length) break;
                else _beenPlayed[i] = false;
            }
        }
    }
}
