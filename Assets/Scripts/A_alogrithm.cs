using UnityEngine;
using System.Collections;
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
    }

	void InitMap()
	{

	}

    public void Move(float speed)
    {
        if (enemy != null && is_wolking)
        {

        }
    }
   public void SetDestination(Vector3 play_position)
    {
        this.destination = play_position;
    }
    public void ResetPath()
    {
        is_wolking = false;
    }

	// Update is called once per frame
    void Update()
    {
        
    }
}
