using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePooling : MonoBehaviour
{

    public GameObject prefab;
    public int initQuantity;
    public Transform spawnPos;
    public float minDelay, maxDelay;
    public static BubblePooling instance;

    public Queue<GameObject> pool;

    public void Awake()
    {
        instance = this;
        InitPool();
    }

    public void Start()
    {


    }


    public void InitPool()
    {
        pool = new Queue<GameObject>();
        GameObject g;
        for (int i = 0; i < initQuantity; ++i)
        {
            g = Instantiate(prefab) as GameObject;
            g.SetActive(false);
            pool.Enqueue(g);
        }
    }

    public void Spawn()
    {
        GameObject g;
        if (pool.Count > 0)
            g = pool.Dequeue();
        else
            g = Instantiate(prefab) as GameObject;
        g.SetActive(true);
        g.GetComponent<Bubble>().ResetAsNew();
        g.transform.position = spawnPos.position;
        SoundManager.instance.PlaySound(0);
    }

    public void SpawnAuto()
    {
        StartCoroutine(CoSpawnAuto());
    }

    public IEnumerator CoSpawnAuto()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            Spawn();
        }
    }

    public void Collect(GameObject g, float delay = 0)
    {
        StartCoroutine(CoCollect(g, delay));
    }

    public IEnumerator CoCollect(GameObject g, float delay)
    {
        yield return new WaitForSeconds(delay);
        g.SetActive(false);
        pool.Enqueue(g);
    }


}
