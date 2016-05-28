using UnityEngine;
using System.Collections;

public class TitleScene : MonoBehaviour
{

    void OnGUI()
    {
        GUI.skin.label.fontSize = 48;
        GUI.skin.label.alignment = TextAnchor.LowerCenter;
        GUI.Label(new Rect(0, 30, Screen.width, 100), "FPS游戏");
        if (GUI.Button(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.7f, 200, 30), "结束游戏"))
        {
            Application.Quit();
        }
        if (GUI.Button(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.5f, 200, 30), "开始游戏"))
        {
            Application.LoadLevel("demo");
        }
    }
}
