using UnityEngine;
using System.Collections;

[AddComponentMenu("Game/GameManager")]
public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    // ��Ϸ�÷�
    public int m_score = 0;

    // ��Ϸ��ߵ÷�
    public static int m_hiscore = 0;

    // ��ҩ����
    public int m_ammo = 100;

    // ��Ϸ����
    Player m_player;

    // UI����
    GUIText txt_ammo;
    GUIText txt_hiscore;
    GUIText txt_life;
    GUIText txt_score;

	// Use this for initialization
	void Start () {

        Instance = this;

        // �������
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // ������õ�UI����
        txt_ammo = this.transform.FindChild("txt_ammo").GetComponent<GUIText>();
        txt_hiscore = this.transform.FindChild("txt_hiscore").GetComponent<GUIText>();
        txt_life = this.transform.FindChild("txt_life").GetComponent<GUIText>();
        txt_score = this.transform.FindChild("txt_score").GetComponent<GUIText>();

        txt_hiscore.text = "High Score " + m_hiscore;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void OnGUI()
    {
        if (m_player.m_life <= 0)
        {
            // ������ʾ����
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;

            // �ı����ִ�С
            GUI.skin.label.fontSize = 40;

            // ��ʾGame Over
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Game Over");

            // ��ʾ������Ϸ��ť
             GUI.skin.label.fontSize = 30;
            if ( GUI.Button( new Rect( Screen.width*0.5f-150,Screen.height*0.75f,300,40),"Try again"))
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }
    }

    // ���·���
    public void SetScore(int score)
    {
        m_score+= score;

        if (m_score > m_hiscore)
            m_hiscore = m_score;

        txt_score.text = "Score "+m_score;
        txt_hiscore.text = "High Score "+ m_hiscore;
    }

    // ���µ�ҩ
    public void SetAmmo(int ammo)
    {
        m_ammo -= ammo;

        // �����ҩΪ�����������
        if (m_ammo <= 0)
            m_ammo = 100 - m_ammo;

        txt_ammo.text = m_ammo.ToString()+"/100";
    }

    // ��������
    public void SetLife(int life)
    {
        txt_life.text = life.ToString();
    }



}