using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Audio_Selector : MonoBehaviour
{
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;

    public int trackSelector;
    public int trackHistory;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trackSelector = Random.Range(0, 3);

        if (trackSelector == 0)
        {
            track1.Play();
            trackHistory = 1;
        }
        else if (trackSelector == 1)
        {
            track2.Play();
            trackHistory = 2;
        }
        else if (trackSelector == 2)
        {
            track3.Play();
            trackHistory = 3;
        }

    }

    void Update()
    {
        if (track1.isPlaying == false && track2.isPlaying == false && track3.isPlaying == false)
        {
            trackSelector = Random.Range(0, 3);

            if (trackSelector == 0 && trackHistory != 1)
            {
                track1.Play();
                trackHistory = 1;
            }
            else if (trackSelector == 1  && trackHistory != 2)
            {
                track2.Play();
                trackHistory = 2;
            }
            else if (trackSelector == 2   && trackHistory != 3)
            {
                track3.Play();
                trackHistory = 3;
            }
        }
    }
    
}
