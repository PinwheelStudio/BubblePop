using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [Range(0f, 1f)]
    public float f;

    public void Update()
    {
        Debug.DrawRay(Vector3.zero, Vector3.left * 3, Color.magenta);
        Debug.DrawRay(Vector3.zero, Vector3.right * 3, Color.magenta);
        Vector3 tmp = Vector3.Lerp(Vector3.left * 3, Vector3.right * 3, f);
        Debug.DrawRay(Vector3.zero, tmp, Color.yellow);
    }
}
