using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float cameraSmooth;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraSmooth);
    }
}
