using UnityEngine;
using System.Collections;
using System.Text;
public class HttpTool
{

    private string m_info = "0";

    public IEnumerator ISetData(string info,string kills)
    {
        WWW www = new WWW("http://121.42.170.120/game_fps.php?opreation=set&score=" + info+"&kills="+kills+ "&key=" + this.MD5Encrypt("set"));

        yield return www;

        if (www.error != null)
        {
            m_info = www.error;
            yield return null;
        }
        m_info = www.text;
    }
    public IEnumerator ISetData(int info,int kills)
    {
        WWW www = new WWW("http://121.42.170.120/game_fps.php?operation=set&score=" + info+"&kills="+kills+"&key="+this.MD5Encrypt("set"));

        yield return www;

        if (www.error != null)
        {
            m_info = www.error;
            yield return null;
        }
        m_info = www.text;
    }
    public IEnumerator IGetData()
    {
        WWW www = new WWW("http://121.42.170.120/game_fps.php?operation=get" + "&key=" + this.MD5Encrypt("get"));

        yield return www;
        
        if (www.error != null)
        {
            m_info = www.error;
            yield return null;
        }
        if (www.text != "")
        {
            m_info = www.text;
        }
        else
        {
            m_info = "0";
        }
		Time.timeScale = 1;
    }
    public string GetInfo()
    {
        return m_info;
    }
	public void SetInfo(string info)
	{
		m_info = info;
	}
    public  string MD5Encrypt(string strText)
    {
         System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create(); 
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strText); 
        byte[] hash = md5.ComputeHash(inputBytes); 
        StringBuilder sb = new StringBuilder(); 
        for (int i = 0; i < hash.Length; i++) { 
            sb.Append(hash[i].ToString("X2")); 
        } 
        return sb.ToString(); 
    }
 
}
