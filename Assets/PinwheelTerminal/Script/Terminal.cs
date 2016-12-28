#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class Terminal : MonoBehaviour
{

    public static Terminal instance;

    public void Awake()
    {
        instance = this;
    }

    #region local rotating
    public static string rx(string cmd)
    {
        string[] s = cmd.Split(' ');
        if (s.Length == 1)
            return "No rotation angle provided.";
        else if (s.Length > 2)
            return "Too much argument.";
        float angle;
        bool parseSuccessful = float.TryParse(cmd.Split(' ')[1], out angle);
        if (!parseSuccessful)
        {
            return "Invalid argument.";
        }
        else
        {
            Transform[] t = Selection.transforms;
            foreach (Transform ti in t)
            {
                //ti.Rotate(new Vector3(angle, 0, 0), Space.Self);
                ti.Rotate(angle, 0, 0, Space.Self);
            }
            return "Successful.";
        }
    }

    public static string ry(string cmd)
    {
        string[] s = cmd.Split(' ');
        if (s.Length == 1)
            return "No rotation angle provided.";
        else if (s.Length > 2)
            return "Too much argument.";
        float angle;
        bool parseSuccessful = float.TryParse(cmd.Split(' ')[1], out angle);
        if (!parseSuccessful)
        {
            return "Invalid argument.";
        }
        else
        {
            Transform[] t = Selection.transforms;
            foreach (Transform ti in t)
            {
                //ti.Rotate(new Vector3(0, angle, 0), Space.Self);
                ti.Rotate(0, angle, 0, Space.Self);
            }
            return "Successful.";
        }
    }

    public static string rz(string cmd)
    {
        string[] s = cmd.Split(' ');
        if (s.Length == 1)
            return "No rotation angle provided.";
        else if (s.Length > 2)
            return "Too much argument.";
        float angle;
        bool parseSuccessful = float.TryParse(cmd.Split(' ')[1], out angle);
        if (!parseSuccessful)
        {
            return "Invalid argument.";
        }
        else
        {
            Transform[] t = Selection.transforms;
            foreach (Transform ti in t)
            {
                //ti.Rotate(new Vector3(0, 0, angle), Space.Self);
                ti.Rotate(0, 0, angle, Space.Self);
            }
            return "Successful.";
        }
    }
    #endregion

    #region global rotating

    #endregion

    #region viewport rotating

    #endregion

    public static string beep()
    {
        EditorApplication.Beep();
        return "";
    }

    public static string captureScreenshot()
    {
        //if (!Directory.Exists(Application.persistentDataPath + "/Screenshot"))
        //{
        //    Directory.CreateDirectory(Application.persistentDataPath + "/Screenshot");
        //}
        ////Application.CaptureScreenshot(Application.persistentDataPath + "/Screenshot/" + System.DateTime.Now + ".png");
        ////Debug.Log(Application.persistentDataPath + "/Screenshot/");
        ////Application.CaptureScreenshot("test.png");
        //string path = Application.persistentDataPath + "/Screenshot/" + System.DateTime.Now + ".png";
        //instance.StartCoroutine(_captureScreenshot(path));

        return "Not available.";
    }

    //private static IEnumerator _captureScreenshot(string path)
    //{
    //    //yield return new WaitForEndOfFrame();
    //    //Application.CaptureScreenshot(path);
    //    ////AssetDatabase.Refresh();
    //}

    public static string call(string cmd)
    {
        string[] s = cmd.Split(' ');
        if (s.Length == 1)
            return "Method's name expected.";
        else if (s.Length > 2)
            return "Too much method's name.";
        string methodName = s[1];

        Transform[] t = Selection.transforms;
        foreach (Transform ti in t)
        {
            ti.BroadcastMessage(methodName);
        }
        return "Successful.";
    }
}
#endif