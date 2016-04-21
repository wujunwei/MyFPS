using System.IO;
using UnityEngine;
using System.Text;
using System.Collections.Generic;
public class FileTool : MonoBehaviour {
    public static FileTool Instance = null;
    private Dictionary<int, Dictionary<int, int>> map = null;
    void Start()
    {
        Instance = this;
    }
    public void GetMapTool()
    {
        map = new Dictionary<int,Dictionary<int,int>>();
        StreamReader sr = new StreamReader("./Assets/StreamingAssets/map.txt", Encoding.Default);
        for(int j=-42; j<42;j++)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] sArray = line.Split(' ');
                Debug.Log(sArray.Length);
                for(int i=-48; i<48;i++)
                {
                    
                }

            }
            
            map.Add(j, temp);
        }
        sr.Close();
        
    }
    public Dictionary<int, Dictionary<int, int>> GetMap()
    {
        if(this.map != null)
        {
            return this.map;
        }
        else
        {
            this.GetMapTool();
            return this.map;
        }
    }
}
