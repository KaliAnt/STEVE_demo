using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rigidBody;
    private Transform transform;
    public GameObject minion;
    public int maxNrOfMinions;
    public int currentNrOfMinions;
    public int minionSpawnForce;
    public float speed;

    public float resources;
	public Text text;

    private float rotationOffset;
    private List<Transform> hiddenEyes;
    private List<Transform> visibleEyes;


    // Use this for initialization
    void Start () {
        transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        currentNrOfMinions = 0;
        resources = 0;
        rotationOffset = -110.0f;
        hideAllEyes();
        showAnEye();
    }

    private void hideAllEyes()
    {
        hiddenEyes = new List<Transform>();
        visibleEyes = new List<Transform>();
        Transform body = transform.GetChild(0);
        int childCount = body.GetChildCount();
        for (int i = 0; i < childCount; i++)
        {
            Transform eye = body.GetChild(i);
            changeEyeStatus(eye, false);
            hiddenEyes.Add(eye);
        }

    }

    private void showAnEye()
    {
        if(hiddenEyes.Count > 0)
        {
            Transform eye = hiddenEyes[0];
            hiddenEyes.RemoveAt(0);
            changeEyeStatus(eye, true);
            visibleEyes.Add(eye);
        }
    }

    private void changeEyeStatus(Transform eye, bool status)
    {
        var renderer = eye.gameObject.GetComponent<Renderer>();
        renderer.enabled = status;
        var pupil = eye.GetChild(0);
        renderer = pupil.gameObject.GetComponent<Renderer>();
        renderer.enabled = status;
    }

    // Update is called once per frame
    void Update () {

        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");
 
        if (movementY!= 0 || movementX != 0)
        {
            rigidBody.velocity = new Vector2(movementX * speed, movementY * speed);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.gameObject.tag == "Resource")
                {
                    spawnMinion(hit.collider.gameObject);
                }
            }
        }


        RotatePlayer();
    }

    public void minionReturn(float minedResource)
    {
        resources += minedResource * 100;
		text.text =(int) resources + "#";
        currentNrOfMinions--;
    }

    private void RotatePlayer()
    {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f;
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

    }

    public void spawnMinion(GameObject target)
    {
        if(currentNrOfMinions < maxNrOfMinions) { 
            GameObject instance = (GameObject)Instantiate(minion);
            currentNrOfMinions++;
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

            MinionScript minionScript = instance.GetComponent<MinionScript>();
            minionScript.ownerPlayer = gameObject;
            minionScript.target = target;
        }
    }
}
