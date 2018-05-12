using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGeneration : MonoBehaviour {

    public GameObject res;
    public Color pink;
    public float mapWidth;
    public float mapHeight;

    public float spawnRate;
    public float rarity;
    
    private Transform pinkT;
	// Use this for initialization
	void Start () {
        //FF00FF pink

        GameObject instance = (GameObject)Instantiate(res);
        SpriteRenderer resPink = instance.transform.GetComponentInChildren<SpriteRenderer>();
        resPink.color = pink;

        int tiles = (int)((mapHeight * mapWidth * spawnRate / 100));
        int rate = (int) (tiles / ((mapHeight + mapWidth)/2));


        for (int i = rate; i > 0; i--)
        {
            GameObject cloneInstance = (GameObject)Instantiate(instance);

            float size = Random.Range(0.5f, 1f);
            cloneInstance.transform.GetChild(0).localScale = new Vector3(size, size, cloneInstance.transform.position.z);
            cloneInstance.transform.GetChild(1).localScale = new Vector3(size, size, cloneInstance.transform.position.z);
            cloneInstance.transform.GetChild(0).transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 180.0f)) ;
            cloneInstance.transform.GetChild(1).transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 180.0f));
            cloneInstance.transform.position = new Vector3(Random.Range(-mapWidth, mapWidth), Random.Range(-mapHeight, mapHeight), instance.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
