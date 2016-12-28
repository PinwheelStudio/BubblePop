using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{

    public BubblePooling pool;
    int currentLevel = 0;


    public void Start()
    {

    }

    public void Run()
    {
        InvokeRepeating("IncreaseDifficulty", 20, 20);
    }

    public void IncreaseDifficulty()
    {
        print("Increase difficulty");

        foreach (GameObject b in BubblePooling.instance.pool)
        {
            b.GetComponent<Bubble>().minVelY -= 0.1f;
            b.GetComponent<Bubble>().maxVelY -= 0.1f;
        }

        ++currentLevel;
        if (currentLevel < 10)
        {
            pool.minDelay -= 0.1f;
            pool.maxDelay -= 0.1f;
        }
    }
}
