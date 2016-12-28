using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public int combo = 0;
    public Text scoreText;
    public AnimationUi2D scoreTextAnim;

    public Text comboText;
    public AnimationUi2D comboTextAnim;

    public GameObject superComboEffect;

    public static ScoreManager instance;
    protected int scoreToDisplay = 0;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        scoreText.text = "0";
        comboText.text = "";
    }

    public void Update()
    {
        scoreToDisplay = (int)Mathf.Lerp(scoreToDisplay, score, 0.1f);
        scoreText.text = scoreToDisplay.ToString();
    }

    public void Add(int amount, bool addCombo = true)
    {
        if (addCombo)
        {
            ++combo;
            DisplayCombo();
        }

        score += amount * combo;


        if (combo > 9)
        {
            GameObject g = Instantiate(comboText.gameObject) as GameObject;
            g.transform.SetParent(FindObjectOfType<Canvas>().transform, false);
            g.GetComponent<Shadow>().enabled = false;
            g.GetComponent<Outline>().enabled = false;
            g.GetComponent<Text>().color = Color.white;
            g.GetComponent<AnimationUi2D>().StopAllCoroutines();
            g.GetComponent<AnimationUi2D>().ZoomIn2d().FadeIn();
            Destroy(g, 1);
        }

        SoundManager.instance.PlaySound(2);
        CancelInvoke();
        Invoke("ResetCombo", 3);
    }

    public void DisplayCombo()
    {
        //scoreText.text = score.ToString();
        //scoreTextAnim.StopAllCoroutines();
        //scoreTextAnim.Scale(scoreTextAnim.additionalCurves[0], 2.4f);

        if (combo > 2)
        {
            comboText.text = string.Format("x{0}", combo);
            comboTextAnim.StopAllCoroutines();
            comboTextAnim.Scale(comboTextAnim.additionalCurves[0], 2.4f);
            SoundManager.instance.PlaySound(3, 1.15f + combo * 0.05f, 2);
            if (combo % 5 == 0)
            {
                SoundManager.instance.PlaySound(5, 1 + 0.02f * combo);
                GameObject g = Instantiate(superComboEffect) as GameObject;
                g.transform.position = new Vector3(-1.75f, -0.25f, 0);
                Destroy(g, 3);
            }
        }
        else
        {
            comboText.text = "";
        }
    }

    public void ResetCombo()
    {
        if (combo == 0)
            return;
        Add(combo * 60, false);

        if (combo > 2)
        {
            SoundManager.instance.PlaySound(4);
            GameObject g = Instantiate(comboText.gameObject) as GameObject;
            g.transform.SetParent(GameObject.Find("Canvas_Screen").transform, false);
            g.GetComponent<Shadow>().enabled = false;
            g.GetComponent<Outline>().enabled = false;
            g.GetComponent<Text>().color = Color.red;
            g.GetComponent<AnimationUi2D>().StopAllCoroutines();
            g.GetComponent<AnimationUi2D>().ZoomOut2d().FadeOut();
            Destroy(g, 1);
        }

        combo = 0;
        comboText.text = "";


    }
}
