using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleOscillator : MonoBehaviour
{
    [Range(1, 20000)]  //Creates a slider in the inspector
    public float frequency1;

    [Range(1, 20000)]  //Creates a slider in the inspector
    public float frequency2;

    [Range(1, 20000)]  //Creates a slider in the inspector
    public float frequency3;

    public float sampleRate = 44100;
    public float waveLengthInSeconds = 2.0f;

    AudioSource audioSource;
    int timeIndex = 0;

    void Start()
    {
    
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; //force 2D sound
        audioSource.Stop(); //avoids audiosource from starting to play automatically
    }

    

    public IEnumerator PLAYSOUND(int color, float duration)
    {
        switch(color)
        {
            case 0:  //RED
                frequency1 = 200;
                frequency2 = 450;
                frequency3 = 1000;
                break;
            case 1:  //YELLOW
                frequency1 = 350;
                frequency2 = 800;
                frequency3 = 1300;
                break;
            case 2: //GREEN
                frequency1 = 500;
                frequency2 = 1000;
                frequency3 = 1600;
                break;
            case 3: //BLUE
                frequency1 = 180;
                frequency2 = 360;
                frequency3 = 600;
                break;
            case 4: //PURPLE
                frequency1 = 120;
                frequency2 = 360;
                frequency3 = 980;
                break;
        }
        timeIndex = 0;
        audioSource.Play();
        yield return new WaitForSeconds(0.2f);
        audioSource.Stop();
            
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            data[i] = CreateSine(timeIndex, frequency1, sampleRate);

            if (channels == 2)
                data[i + 1] = CreateSine(timeIndex, (frequency1* frequency2)/frequency3, sampleRate);

            timeIndex++;

            //if timeIndex gets too big, reset it to 0
            if (timeIndex >= (sampleRate * waveLengthInSeconds))
            {
                timeIndex = 0;
            }
        }
    }

    //Creates a sinewave
    public float CreateSine(int timeIndex, float frequency, float sampleRate)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate);
    }
}