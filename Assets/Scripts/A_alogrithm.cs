using UnityEngine;
using System.IO;
using System.Text;
using System.Collections.Generic;
public class A_alogrithm : MonoBehaviour {
    public Transform enemy;
    private bool is_wolking;
    Vector3 destination;
    public const int OBLIQUE = 14;
    public const int STEP = 10;
	private Dictionary<int,Dictionary<int,int>> map = new Dictionary<int,Dictionary<int,int>>();
    List<Point> CloseList;
    List<Point> OpenList;
	// Use this for initialization
	void Start () {
        is_wolking = true;
        enemy = this.transform.parent;
        InitMap();
        OpenList = new List<Point>(96 * 84);//长*宽
        CloseList = new List<Point>(96 * 84);//长*宽
    }

	void InitMap() {
        //读取地图文件
       // if (FileTool.Instance != null)
        {
            map = FileTool.Instance.GetMap();
        }
        
    }

    public void Move(float speed) {
        if (enemy != null && is_wolking)
        {

        }
    }
   public void SetDestination(Vector3 play_position) {
        this.destination = play_position;
    }
    public void ResetPath() {
        is_wolking = false;
    }

	// Update is called once per frame
    void Update() {
        
    }
}
