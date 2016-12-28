using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubble;
    public float minDelay;
    public float maxDelay;

    public void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            GameObject g = Instantiate(bubble.gameObject, transform.position, Quaternion.identity) as GameObject;
            g.transform.localScale = Vector3.one * Random.Range(0.5f, 1f);
        }

    }

}
