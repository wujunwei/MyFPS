using UnityEngine;
using System.IO;
using System.Text;
using System.Collections.Generic;
public class A_alogrithm : MonoBehaviour {
    public Transform enemy;
    private bool is_wolking;
    Vector3 destination;
	private Dictionary<int,Dictionary<int,int>> map = new Dictionary<int,Dictionary<int,int>>();
	// Use this for initialization
	void Start () {
        is_wolking = true;
        enemy = this.transform.parent;
        InitMap();
    }

	void InitMap() {
        //读取地图文件
        StreamReader sr = new StreamReader("./Assets/StreamingAssets/map.txt", Encoding.Default);
        for(int j=-42; j<42;j++)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                //Debug.Log(line.ToString());

            }
            for(int i=-48; i<48;i++)
            {
                
                
            }
            map.Add(j, temp);
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
