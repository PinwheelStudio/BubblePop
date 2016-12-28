using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
[System.Serializable]
public class BalloonObject : MonoBehaviour
{
    public ImagePosition BalloonPosition { get; set; }
    public int HP { get; set; }
    public int DMG { get; set; }
    public Sprite BalloonImage { get; set; }
    public string BalloonType { get; set; }
}

