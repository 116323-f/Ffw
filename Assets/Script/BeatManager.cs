using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{

    [SerializeField] private float bpm;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Intervals[] intervals;

    private void Update()
    {
        foreach (Intervals interval in intervals)
        {
            //time currently elapsed/number of intervals = time elapsed in intervals which is then sent back to check for new intervals
            float sampledTime = (audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLength(bpm)));
            interval.CheckForNewInterval(sampledTime);
        }
    }

}

//to set variables in inspector 
[System.Serializable]
public class Intervals 
{
    [SerializeField] private float steps;
    [SerializeField] private UnityEvent trigger;
    //keep track of last interval
    private int lastInterval;

    public float GetIntervalLength(float bpm)
    {
        //how many beats per min (60 sec)
        //modifying with steps allows for more modification (e.g. half or quarter beats)
        return 60f / (bpm * steps);
    }

    //everytime interval has passed a whole number, new beat has been passed
    //new beat = last interval
    public void CheckForNewInterval(float interval)
    {
        //FloorToInt to check every whole number
        if (Mathf.FloorToInt(interval) != lastInterval)
        {
            lastInterval = Mathf.FloorToInt(interval);
            //to easily drag others to the inspector that can be triggered by this beat
            trigger.Invoke();
        }
    }

}