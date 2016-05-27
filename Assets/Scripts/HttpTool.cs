using UnityEngine;
using System.Collections;
public class HttpTool
{

    private string m_info = "0";

    public IEnumerator ISetData(string info)
    {
        WWW www = new WWW("http://121.42.170.120/game_fps.php?opreation=set&score=" + info + "&key=" + this.MD5Encrypt("set"));

        yield return www;

        if (www.error != null)
        {
            m_info = www.error;
            yield return null;
        }
        m_info = www.text;
    }
    public IEnumerator ISetData(int info)
    {
        WWW www = new WWW("http://121.42.170.120/game_fps.php?operation=set&score=" + info+"&key="+this.MD5Encrypt("set"));

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
         System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
         byte[] testEncrypt = System.Text.Encoding.Unicode.GetBytes(strText);
         byte[] resultEncrypt = md5CSP.ComputeHash(testEncrypt);
         string testResult = System.Text.Encoding.Unicode.GetString(resultEncrypt);
         string ans = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "MD5");
         return ans;
    }
 
}
