using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public Camera cam;
    public RaycastHit[] hit;
    public Ray ray;
    public LayerMask mask;

    private Bubble bubble;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * int.MaxValue, Color.cyan);
            hit = Physics.SphereCastAll(ray, 0.25f, int.MaxValue);

            if (hit.Length > 0 && hit[0].collider.name != "RaycastBlocker")
            {

                for (int i = 0; i < hit.Length; ++i)
                {
                    if (i > 3) break;

                    bubble = hit[i].transform.GetComponent<Bubble>();
                    if (bubble != null)
                        bubble.Tap();
                    else
                    {
                        ScoreManager.instance.CancelInvoke();
                        ScoreManager.instance.ResetCombo();
                    }
                }
            }
            else
            {
                ScoreManager.instance.CancelInvoke();
                ScoreManager.instance.ResetCombo();
            }
        }
    }
}
