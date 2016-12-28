using UnityEngine;
using System.Collections;

[System.Serializable]
public class FadeParam
{
    public FadeType type;
    public float duration;
    public bool deactivateUI;
    public bool fadeChildren;
    public AnimationCurve curve;

}

public enum FadeType
{
    Sprite, UI
}