using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public Slider slider;
    public int hp;

    public AnimationUi2D anim;

    public void Awake()
    {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bubble")
        {
            Bubble b = col.GetComponent<Bubble>();
            b.Pop(false);
            int damage = b.damage;
            hp -= damage;
            slider.value = hp;
            if (hp <= 0)
                Die();

        }
    }

    public void Die()
    {
        GameManager.instance.SubtractLife(1);
        anim.FadeOut();
        GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject, 3);
        Destroy(slider.gameObject);
    }
}
