using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeperScript : MonoBehaviour
{
    // Start is called before the first frame update
    public  float startTime, endTime, finalTime, highScore;
    public GameObject everything;
    void Start()
    {
        TrackStartingTime();
        highScore = 9999;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrackStartingTime() 
    {
        startTime = Time.unscaledTime;
    }

    public void TrackEndTime()
    {
        endTime = Time.unscaledTime;

    }

    public void CalcTime()
    {
        finalTime = endTime - startTime;
    }

    public void CompareHighScore()
    {
        if (finalTime > highScore)
        {
            highScore = finalTime;
        }
    }

    public void WipeOut() 
    {
        Destroy(everything);
    }
}
