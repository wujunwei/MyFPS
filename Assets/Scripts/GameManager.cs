using UnityEngine;
using System.Collections;
using System;

[AddComponentMenu("Game/GameManager")]
public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;
    public GUISkin myskin;
    // 游戏得分
    public int m_score = 0;
    // 游戏最高得分
    public static int m_hiscore = 0;
    // 弹药数量
    public int m_ammo = 100;

	HttpTool ht = new HttpTool();
    // 游戏主角
    Player m_player;
    bool windowShow = false;
    bool ready_get = false;
    // UI文字
    GUIText txt_ammo;
    GUIText txt_hiscore;
    GUIText txt_life;
    GUIText txt_score;
    GUIText txt_killnum;
    GUIText show_message;
	// Use this for initialization
	void Start () {

        Instance = this;

        // 获得主角
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // 获得设置的UI文字
        txt_ammo = this.transform.FindChild("txt_ammo").GetComponent<GUIText>();
        txt_hiscore = this.transform.FindChild("txt_hiscore").GetComponent<GUIText>();
        txt_life = this.transform.FindChild("txt_life").GetComponent<GUIText>();
        txt_score = this.transform.FindChild("txt_score").GetComponent<GUIText>();
        txt_killnum = this.transform.FindChild("txt_killnum").GetComponent<GUIText>();
        show_message = this.transform.FindChild("show_message").GetComponent<GUIText>();
        if (Application.internetReachability != NetworkReachability.NotReachable) 
        {
            Time.timeScale = 0;
            ready_get = true;
            StartCoroutine(ht.IGetData());
        }
        else
        {
            ht.SetInfo("0");
        }
	}

    void Update()
    {
        if (Time.timeScale != 0 && ready_get)
        {
            txt_hiscore.text = "High Score " + ht.GetInfo();
            m_hiscore = Convert.ToInt32(ht.GetInfo());
            ready_get = false;
        }
		
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    void OnGUI()
    {
        if (m_player.m_life <= 0)
        {
            // 居中显示文字
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;

            // 改变文字大小
            GUI.skin.label.fontSize = 40;

            // 显示Game Over
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Game Over");
            if (windowShow == true)
            {
                GUI.skin = myskin;
                GUI.Window(0, new Rect(200, 80, 500, 500), sublimtScore, "Select one");
            }
            // 显示重新游戏按钮
			GUI.skin.label.fontSize = 30;
            if (windowShow == false)
            {
                if (GUI.Button(new Rect(Screen.width * 0.5f - 150, Screen.height * 0.45f, 300, 40), "Back to title"))
                {
                    Application.LoadLevel("startTitle");

                }
			    if ( GUI.Button( new Rect( Screen.width*0.5f-150,Screen.height*0.6f,300,40),"Submit score!"))
			    {
                    windowShow = true;
			    }
                if ( GUI.Button( new Rect( Screen.width*0.5f-150,Screen.height*0.75f,300,40),"Try again"))
                {
                    Application.LoadLevel(Application.loadedLevelName);

                }
            }
          
        }
    }

    // 更新分数
    public void SetScore(int score)
    {
        m_score+= score;

        if (m_score > m_hiscore)
            m_hiscore = m_score;
        txt_score.text = "Score "+m_score;
        txt_hiscore.text = "High Score "+ m_hiscore;
    }
    public void sublimtScore(int Windowid)
    {
        if (GUI.Button(new Rect(130,100, 300, 40), "close the windows"))
        {
            show_message.text = "";
            windowShow = false;
        }
        if (GUI.Button(new Rect(130, 200, 300, 40), "submit your score"))
        {
            HttpTool ht = new HttpTool();
            StartCoroutine(ht.ISetData(m_score, m_player.kills));
            show_message.color = Color.red;
            show_message.text = "submit successfully !";
        }
        if (GUI.Button(new Rect(130, 300, 300, 40), "share your score"))
        {
         
            //在按钮按下时调用：
            show_message.color = Color.red;
            show_message.text = "share successfully !";
        }
        
    }

    public void Setkills(int kills)
    {
        txt_killnum.text = "kills " + kills.ToString();
    }
    // 更新弹药
    public void SetAmmo(int ammo)
    {
        m_ammo -= ammo;
        // 如果弹药为负数，重新填弹
        if (m_ammo <= 0)
            m_ammo = 100 - m_ammo;

        txt_ammo.text = m_ammo.ToString()+"/100";
    }

    // 更新生命
    public void SetLife(int life)
    {
        txt_life.text = life.ToString();
    }

}