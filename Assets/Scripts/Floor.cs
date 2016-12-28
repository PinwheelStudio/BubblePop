using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bubble")
        {
            col.GetComponent<Bubble>().Pop(false);
        }
    }
}
