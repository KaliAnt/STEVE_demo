using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour {

    public GameObject ownerPlayer;
    public float speed;
    

    public float destX, destY;
    private Rigidbody2D minionBody;

	// Use this for initialization
	void Start () {
        minionBody = GetComponent<Rigidbody2D>();
	}
	
    public void setDestination(int x, int y)
    {
        destX = x;
        destY = y;
    }

	// Update is called once per frame
	void Update () {
		
        while(transform.position.x != destX && transform.position.y != destY)
        {
            
        }
	}
}
