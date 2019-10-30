using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public float songBPM;

    public float secPerBeat;

    public float songPosition;

    public float dspSongTime;

    public float songPositionInBeats;

    public float beatsShownInAdvance = 3;

    public AudioSource musicSource;

    public GameObject foodObject;

    public GameObject spawnPoint;

    float[] notes = {0.6f, 1.25f, 2.5f, 3.0f, 3.8f, 4.4f, 5.0f, 5.7f, 6.3f,
                     7.0f, 7.6f, 8.2f, 8.9f, 9.5f, 10.0f, 10.7f, 11.3f, 12.0f,
                     12.6f, 13.3f, 13.9f, 14.5f, 15.1f, 15.5f, 15.8f, 16.4f,
                     17.7f, 18.3f, 19.0f, 19.6f, 20.8f, 21.5f, 22.0f, 22.9f,
                     23.1f, 23.4f, 24.0f, 24.6f, 25.4f, 25.5f, 25.8f, 26.5f,
                     26.6f, 27.1f, 27.7f, 28.4f, 29.0f, 29.3f, 29.5f, 29.8f,
                     30.3f, 30.6f, 30.9f, 31.5f, 31.7f, 31.8f, 32.0f, 32.2f,
                     32.8f, 32.9f, 33.4f, 34.0f, 34.2f, 34.4f, 34.5f, 34.7f,
                     35.3f, 35.9f, 36.0f, 36.6f, 37.2f, 37.8f, 38.5f, 38.6f,
                     39.1f, 39.7f, 40.4f, 40.7f, 41.0f, 41.6f, 41.8f, 42.0f,
                     42.2f, 42.9f, 43.2f, 43.6f, 44.1f, 44.3f, 44.5f, 44.8f,
                     45.1f, 45.4f, 45.6f, 45.7f, 46.0f, 46.7f, 46.8f, 47.1f,
                     47.3f, 47.6f, 48.0f, 48.3f, 48.4f, 48.6f, 49.2f, 49.4f,
                     49.7f, 49.8f, 50.5f, 50.8f, 51.1f, 51.7f, 51.9f, 52.0f,
                     52.2f, 52.4f, 52.5f, 53.0f, 53.1f, 53.6f, 54.3f, 54.6f,
                     54.9f, 55.5f, 56.1f, 56.6f, 56.8f, 57.4f, 58.0f, 58.7f,
                     59.3f, 59.6f, 59.8f, 59.9f, 60.4f, 61.2f, 61.5f, 61.8f,
                     62.4f, 63.1f, 63.7f, 64.0f, 64.3f, 65.0f, 65.6f, 65.8f,
                     65.9f, 66.2f, 66.9f, 67.2f, 67.5f, 68.1f, 68.3f, 68.6f,
                     68.8f, 69.4f, 69.7f, 69.9f, 70.0f, 70.7f, 71.0f, 71.3f,
                     71.9f, 72.4f, 72.6f, 73.2f, 73.5f, 73.8f, 74.5f, 74.8f,
                     75.1f, 75.7f, 76.0f, 76.3f, 76.8f, 77.1f, 77.4f, 77.6f,
                     77.9f, 78.2f, 78.6f, 78.9f, 80.0f, 80.6f};

    int nextIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        secPerBeat = 60 / songBPM;

        dspSongTime = (float)AudioSettings.dspTime;

        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        songPositionInBeats = songPosition / secPerBeat;

        if (nextIndex < notes.Length && notes[nextIndex] < songPositionInBeats + beatsShownInAdvance)
        {
            Instantiate(foodObject, spawnPoint.transform);

            //initialize the fields of the music note

            nextIndex++;
        }
    }
}
