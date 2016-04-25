using System.IO;
using UnityEngine;
using System.Text;
using System.Collections.Generic;
using System;

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
        StreamReader sr = new StreamReader(Application.streamingAssetsPath+"/map.txt", Encoding.Default);
        string line;
        int j = -42;
        while ((line = sr.ReadLine()) != null)
        {
            string[] sArray = line.Split(' ');
            Dictionary<int, int> temp = new Dictionary<int, int>();
            for(int i=-48; i<sArray.Length-48;i++)
            {
                temp.Add(i, System.Int32.Parse(sArray[i + 48]));
                
                //Debug.Log(temp[i]);
            }
            
            map.Add(j, temp);
            j++;
        }
        //string log = "";
        //foreach (var pair in map)
        //{
        //    foreach (var p in pair.Value)
        //    {
        //        log = log + "" + pair.Key + " " + p.Key + " " + p.Value + "\n";
        //    }

        //}
        //this.WriteDebugFile(log,"map.log");
        sr.Close();
        
    }

    public void WriteDebugFile(string text,string filename="log.txt")
    {
        filename = "./log/"+filename;
        FileStream fs = null;
        //将待写的入数据从字符串转换为字节数组  
        Encoding encoder = Encoding.UTF8;
        try
        {
            fs = File.OpenWrite(filename);
            //设定书写的开始位置为文件的末尾  
            fs.Position = fs.Length;
            //将待写入内容追加到文件末尾  
            byte[] temp = Encoding.UTF8.GetBytes(text);
            fs.Write(temp, 0, temp.Length);
            fs.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("文件打开失败{0}", ex.ToString());
        }
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
