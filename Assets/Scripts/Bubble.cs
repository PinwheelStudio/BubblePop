using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bubble : MonoBehaviour
{
    public int damage;
    public int hp;
    //public float minFraction, maxFraction;
    public float minVelY, maxVelY;
    public float velXAmplitude;
    public ParticleSystem par;
    public SphereCollider col;
    public SpriteRenderer sprite;
    public Sprite spriteBlue, spriteGreen, spriteRed;

    protected AnimationUi2D anim;
    protected Rigidbody r;
    protected int remainHp;
    protected int noiseIndexY;
    protected float velocityX, velocityY;
    protected float velXFrequency;



    public void Awake()
    {
        anim = GetComponent<AnimationUi2D>();
        r = GetComponent<Rigidbody>();

    }


    public void Update()
    {
        float noiseValueX = Mathf.PerlinNoise(Time.time * velXFrequency, noiseIndexY);
        velocityX = velXAmplitude * (noiseValueX - 0.47f) / 0.53f;
        r.velocity = new Vector3(velocityX, velocityY);
    }

    public void Tap()
    {
        remainHp -= 1;
        //anim.ZoomIn2d();
        SoundManager.instance.PlaySound(1);
        if (remainHp <= 0)
            Pop();
        else
        {
            anim.FadeIn();
        }
    }

    public void ResetAsNew()
    {
        int random = Random.Range(0, 20);
        hp = (random < 15) ? 1 : (random < 19) ? 2 : 3;
        sprite.sprite = hp == 1 ? spriteBlue : hp == 2 ? spriteGreen : spriteRed;
        remainHp = hp;
        damage = Random.Range(1, 11);
        r.velocity = Vector3.zero;
        r.useGravity = false;
        par.gameObject.SetActive(false);
        col.enabled = true;
        sprite.color = new Color(1, 1, 1, 0.8f);
        transform.localScale = Random.Range(0.3f, 1f) * Vector3.one;
        anim.initScale = transform.localScale;
        velocityY = Random.Range(minVelY, maxVelY);
        noiseIndexY = Random.Range(1, 1000);
        velXFrequency = Random.Range(0.3f, 2f);
    }

    public void Pop(bool addScore = true)
    {
        anim.ZoomOut2d();
        anim.FadeOut();
        SoundManager.instance.PlaySound(1);
        r.velocity = Vector3.zero;
        r.useGravity = false;
        par.gameObject.SetActive(true);
        col.enabled = false;
        if (addScore)
            ScoreManager.instance.Add((int)((transform.position.y + 4) * hp * 10));
        BubblePooling.instance.Collect(this.gameObject, 0.31f);

    }


}
