#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Collections.Generic;

public class TerminalEditor : EditorWindow
{

    static TerminalEditor window;
    static int margin = 2;
    static int txtBoxHeight = 20;
    static int buttonWidth = 70;
    static string log = "";
    static string cmd;

    static List<string> history = new List<string>();
    static int historyIndex;

    static Rect borderRect;
    Rect fillRect;
    static Vector2 scrollPosition;
    static Rect scrollView;
    [MenuItem("Window/Terminal")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        window = (TerminalEditor)EditorWindow.GetWindow(typeof(TerminalEditor));
        window.minSize = new Vector2(100, 100);
        window.title = "Terminal";
        window.Show();
    }

    void OnGUI()
    {
        try
        {
            DrawReadOnlyText();
            DrawCommandBox();
            DrawExecButton();

            if (mouseOverWindow)
            {
                EditorGUI.FocusTextInControl("cmdBox");
            }
            else
            {
                GUI.UnfocusWindow();
            }

        }
        catch (Exception e)
        {
            Init();
        }

    }

    public void DrawReadOnlyText()
    {
        //gui.beginscrollview

        Color32 borderColor = Color.gray;
        Color32 fillColor = new Color32(211, 211, 211, 255);

        borderRect = new Rect(margin, margin, window.position.width - 2 * margin, window.position.height - 3 * margin - txtBoxHeight);
        fillRect = new Rect(margin + 1, margin + 1, window.position.width - 2 * margin - 2, window.position.height - 3 * margin - txtBoxHeight - 2);
        EditorGUI.DrawRect(borderRect, borderColor);
        EditorGUI.DrawRect(fillRect, fillColor);

        GUIStyle style = new GUIStyle();
        style.padding = new RectOffset(4, 4, 4, 4);
        scrollView = new Rect(margin + 1, margin + 1, window.position.width - 2 * margin - 2 - 15, /*window.position.height - 3 * margin - txtBoxHeight - 2*/ +13 * log.Split('\n').Length);
        scrollPosition = GUI.BeginScrollView(fillRect, scrollPosition, scrollView, false, true);

        EditorGUI.SelectableLabel(borderRect, log, style);
        GUI.EndScrollView();
    }

    public void DrawCommandBox()
    {
        Vector2 txtBoxPos = new Vector2(margin, window.position.height - margin - txtBoxHeight);
        Vector2 txtSize = new Vector2(window.position.width - 4 * margin - buttonWidth, txtBoxHeight);
        GUI.SetNextControlName("cmdBox");

        Event e = Event.current;

        if (cmd != "" && e.type == EventType.keyDown && e.keyCode == KeyCode.Return)
        {

            log += "> " + cmd + "\n";
            string[] s = log.Split('\n');
            if (s.Length > 10)
            {

                log = "";
                for (int i = s.Length - 10; i < s.Length - 2; ++i)
                {
                    log += "> " + s[i].Remove(0, 2) + "\n";
                    Debug.Log(log);
                }
                log += "> " + cmd + "\n";
            }
            if (cmd == "clear")
                log = "";
            else
                log += ExecCmd(cmd);
            cmd = "";
        }
        cmd = EditorGUI.TextField(new Rect(txtBoxPos.x, txtBoxPos.y, txtSize.x, txtSize.y), cmd);
    }

    public void DrawExecButton()
    {
        Vector2 pos = new Vector2(window.position.width - margin - buttonWidth, window.position.height - margin - txtBoxHeight);
        Vector2 size = new Vector2(buttonWidth, txtBoxHeight);
        GUI.Button(new Rect(pos.x, pos.y, size.x, size.y), "Execute");
    }

    public string ExecCmd(string cmd)
    {
        history.Add(cmd);
        historyIndex = history.Count - 1;

        string[] s = cmd.Split(' ');
        if (s[0] == "rx")
        {
            return "> " + Terminal.rx(cmd) + "\n";
        }
        else if (s[0] == "ry")
        {
            return "> " + Terminal.ry(cmd) + "\n";
        }
        else if (s[0] == "rz")
        {
            return "> " + Terminal.rz(cmd) + "\n";
        }
        else if (s[0] == "beep")
        {
            return Terminal.beep();
        }
        else if (s[0] == "cap")
        {
            return Terminal.captureScreenshot();
        }
        else if (s[0] == "call")
        {
            return "> " + Terminal.call(cmd) + "\n";
        }
        else
        {
            return "> " + "Bad command!" + "\n";
        }
    }
}
#endif