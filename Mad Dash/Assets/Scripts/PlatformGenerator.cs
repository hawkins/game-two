using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public ObjectPooler theObjectPool;
    private ItemGenerator itemGenerator;
    private int selector;

	// Use this for initialization
	void Start () {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        itemGenerator = FindObjectOfType<ItemGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(thePlatform, transform.position, transform.rotation);
            GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            selector = Random.Range(1, 5);
            if(selector == 2)
            {
                itemGenerator.SpawnMushrooms(new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z));
            }
            if (selector == 1)
            {
                itemGenerator.SpawnPills(new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z));
            }
            if (selector == 3)
            {
                itemGenerator.SpawnSecurity_1(new Vector3(transform.position.x, transform.position.y, transform.position.z));
            }
            if (selector == 4)
            {
                itemGenerator.SpawnBench(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z));
            }


        }

	}
}
