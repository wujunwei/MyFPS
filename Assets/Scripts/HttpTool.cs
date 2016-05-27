using UnityEngine;
using System.Collections;

public class HttpTool {

    private string m_info = "0";

    public IEnumerator ISetData(string info)
    {
        WWW www = new WWW("http://121.42.170.120/game_fps.php?opreation=save&score=" + info);

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
        WWW www = new WWW("http://121.42.170.120/game_fps.php?operation=set&score=" + info);

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
        WWW www = new WWW("http://121.42.170.120/game_fps.php?operation=get");

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
}
