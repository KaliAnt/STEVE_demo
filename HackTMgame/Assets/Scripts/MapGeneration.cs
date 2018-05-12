using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGeneration : MonoBehaviour {

    public GameObject player;
    public GameObject res;
    public Color pink;
    public float mapWidth;
    public float mapHeight;
    public float spawnRate;
    public float rarity;

    public GameObject planet;


    private float planetSpawnRate = 10;
    
    
    private Transform pinkT;
	// Use this for initialization
	void Start () {
        //FF00FF pink

        //GameObject instance = (GameObject)Instantiate(res);
        SpriteRenderer resPink = res.transform.GetComponentInChildren<SpriteRenderer>();
        resPink.color = pink;

        int tiles = (int)((mapHeight * mapWidth * spawnRate / 100));
        int rate = (int) (tiles / ((mapHeight + mapWidth)/2));

        int planets = 6; 

        for (int i = rate; i > 0; i--)
        {
            if(planets > 0)
            {
                GameObject clonePlanet = (GameObject)Instantiate(planet);
                float siz = Random.Range(0.3f, 0.7f);
                SpriteRenderer planetColor = clonePlanet.transform.GetComponent<SpriteRenderer>();
                planetColor.color = new Color32((byte)Random.Range(0x00, 0xFF), (byte)Random.Range(0x00, 0xFF), (byte)Random.Range(0x00, 0xFF), 0xFF);
                clonePlanet.transform.localScale = new Vector3(siz, siz, 0);
                
                clonePlanet.transform.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 180.0f));
               
                clonePlanet.transform.position = new Vector3(Random.Range(-mapWidth + 30, mapWidth - 30), Random.Range(-mapHeight + 30, mapHeight - 30), 0);
                planets--;
            }
            GameObject cloneInstance = (GameObject)Instantiate(res);

            float size = Random.Range(0.3f, 0.7f);
            cloneInstance.transform.GetChild(0).localScale = new Vector3(size, size, cloneInstance.transform.position.z);
            cloneInstance.transform.GetChild(1).localScale = new Vector3(size, size, cloneInstance.transform.position.z);
            cloneInstance.transform.GetChild(0).transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 180.0f)) ;
            cloneInstance.transform.GetChild(1).transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 180.0f));
            cloneInstance.transform.position = new Vector3(Random.Range(-mapWidth, mapWidth), Random.Range(-mapHeight, mapHeight), cloneInstance.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update () {
        
	}
}
