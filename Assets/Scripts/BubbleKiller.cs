using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleKiller : MonoBehaviour
{

    public Transform p1, p2;
    public int distanceFromBottom = 100;

    RaycastHit[] hitInfo;
    bool hit;

    public void Start()
    {
        InitPosition();
    }

    public void Update()
    {
        Debug.DrawLine(p1.position, p2.position, Color.red);
        hitInfo = Physics.RaycastAll(p1.position, Vector3.right, Vector3.Distance(p1.position, p2.position), LayerMask.GetMask("Bubble"));
        if (hitInfo.Length > 0)
        {
            foreach (RaycastHit h in hitInfo)
            {
                Bubble b = h.transform.GetComponent<Bubble>();
                b.Pop();
                h.transform.GetComponent<SphereCollider>().enabled = false;
                //HealthManager.instance.Subtract(b.damage);

            }
        }
    }

    public void InitPosition()
    {
        int screenWidth = Screen.width;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth / 2, distanceFromBottom));
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        p1.position = Camera.main.ScreenToWorldPoint(new Vector3(0, distanceFromBottom));
        p1.transform.position = new Vector3(p1.transform.position.x, p1.transform.position.y, 0);
        p2.position = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, distanceFromBottom));
        p2.transform.position = new Vector3(p2.transform.position.x, p2.transform.position.y, 0);
    }
}
