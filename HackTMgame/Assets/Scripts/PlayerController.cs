using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rigidBody;
    private Transform transform;
    public Joystick joyStick;
    public Joystick rotateStick;
    public float speed;


    // Use this for initialization
    void Start () {
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
        else
        {
            rigidBody.velocity = Vector2.zero;
        }


        RotatePlayer();
    }

    private void RotatePlayer()
    {
        float movementX = rotateStick.Horizontal;
        float movementY = rotateStick.Vertical;
        double angle;


        if(movementY != 0 || movementX != 0)
        {
            angle = Mathf.Atan2(movementX, movementY) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, (float)angle);
        }

    }
}
