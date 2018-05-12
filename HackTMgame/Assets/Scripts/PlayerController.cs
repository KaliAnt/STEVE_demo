using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rigidBody;
    private Transform transform;
    public Joystick joyStick;
    public Joystick rotateStick;
    public GameObject minion;
    public int maxNrOfMinions;
    public int currentNrOfMinions;
    public int minionSpawnForce;
    public float speed;


    // Use this for initialization
    void Start () {
        transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        currentNrOfMinions = 0;
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(currentNrOfMinions < maxNrOfMinions)
            {
                spawnMinion();
            }   
            
        }
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

    private void spawnMinion()
    {
        GameObject instance = (GameObject)Instantiate(minion);
        SpriteRenderer minionRenderer = instance.GetComponent<SpriteRenderer>();
        SpriteRenderer playerRenderer = GetComponentInChildren<SpriteRenderer>();

        minionRenderer.color = playerRenderer.color;
        instance.transform.position = transform.position;

        Rigidbody2D minionBody = instance.GetComponent<Rigidbody2D>();

        float angle = Random.value * 360 * Mathf.Deg2Rad;
        float forceX, forceY;
        forceX = minionSpawnForce * Mathf.Sin(angle);
        forceY = minionSpawnForce * Mathf.Cos(angle);

        minionBody.velocity = new Vector3(forceX, forceY);
        currentNrOfMinions++;
    }
}
