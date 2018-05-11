using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rigidBody;
    private Transform transform;
    private Joystick joyStick;
    public float speed;

    // Use this for initialization
    void Start () {
        joyStick = FindObjectOfType<Joystick>();
        transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        float movementX = joyStick.Horizontal;
        float movementY = joyStick.Vertical;

 
        if (movementY!= 0 || movementX != 0)
        {
            rigidBody.velocity = new Vector2(movementX * speed, movementY * speed);
        }
    }
}
