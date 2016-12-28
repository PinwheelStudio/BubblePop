using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float angle;

    public void Update()
    {
        transform.Rotate(Vector3.forward, angle);
    }
}
