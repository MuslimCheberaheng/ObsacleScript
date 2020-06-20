using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float TBS; //time between spawn
    public float startTBS; //start time between spawn
    public float decreaseTime;
    public float minTime = 0.65f;    
    
    void Update()
    {
        if (TBS <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity); //random instantiate
            TBS = startTBS;
            if (startTBS > minTime)
            {
                startTBS -= decreaseTime;
            }
        }
        else
        {
            TBS -= Time.deltaTime;
        }
    }
}
