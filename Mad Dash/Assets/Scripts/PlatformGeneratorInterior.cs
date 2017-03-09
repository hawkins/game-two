using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorInterior : MonoBehaviour
{

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public ObjectPooler theObjectPool;
    private ItemGenerator itemGenerator;
    private int selector;
    private int decider;
    private int deltaXo;
    private int deltaXi;
    private int deltaYo;
    private int deltaYi;
    private int selectorStore;

    // Use this for initialization
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        itemGenerator = FindObjectOfType<ItemGenerator>();
        selectorStore = 0;
        selector = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(thePlatform, transform.position, transform.rotation);
            GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            selectorStore = selector;

            selector = Random.Range(1, 6);
            decider = Random.Range(1, 3);
            deltaXo = Random.Range(1, 15);
            deltaXo = Random.Range(1, 15);
            deltaYi = Random.Range(1, 25);
            deltaYo = Random.Range(1, 25);

            while (selector == selectorStore)
            {
                selector = Random.Range(1, 6);
            }
            while (deltaXo == deltaXi)
            {
                deltaXi = Random.Range(1, 15);
            }



            /*if (selector == 1)
            {
                if (decider == 1) { itemGenerator.SpawnMushrooms(new Vector3(transform.position.x + deltaXo, transform.position.y + deltaYi, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnMushrooms(new Vector3(transform.position.x - deltaXo, transform.position.y + deltaYi, transform.position.z)); }
            }

            if (selector == 2)
            {
                if (decider == 1) { itemGenerator.SpawnPills(new Vector3(transform.position.x + deltaXo, transform.position.y + deltaYi, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnPills(new Vector3(transform.position.x - deltaXo, transform.position.y + deltaYi, transform.position.z)); }
            }*/

            if (selector == 1)
            {
                if (decider == 1) { itemGenerator.SpawnSecurity_1(new Vector3(transform.position.x + deltaXo, transform.position.y, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnSecurity_1(new Vector3(transform.position.x - deltaXo, transform.position.y, transform.position.z)); }
            }

            if (selector == 2)
            {
                if (decider == 1) { itemGenerator.SpawnSecurity_2(new Vector3(transform.position.x + deltaXo, transform.position.y, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnSecurity_2(new Vector3(transform.position.x - deltaXo, transform.position.y, transform.position.z)); }
            }

            if (selector == 3)
            {
                if (decider == 1) { itemGenerator.SpawnDoctor(new Vector3(transform.position.x + deltaXo, transform.position.y, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnDoctor(new Vector3(transform.position.x - deltaXo, transform.position.y, transform.position.z)); }
            }

            /*if (selector == 6)
            {
                if (decider == 1) { itemGenerator.SpawnBench(new Vector3(transform.position.x + deltaXo, transform.position.y, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnBench(new Vector3(transform.position.x - deltaXo, transform.position.y, transform.position.z)); }
            }

            if (selector == 7)
            {
                if (decider == 1) { itemGenerator.SpawnDog(new Vector3(transform.position.x + deltaXo, transform.position.y + 1f, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnDog(new Vector3(transform.position.x - deltaXo, transform.position.y + 1f, transform.position.z)); }
            }

            if (selector == 8)
            {
                if (decider == 1) { itemGenerator.SpawnBird(new Vector3(transform.position.x + deltaXo, transform.position.y + deltaYo, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnBird(new Vector3(transform.position.x - deltaXo, transform.position.y + deltaYo, transform.position.z)); }
            }*/

            if (selector == 4)
            {
                if (decider == 1) { itemGenerator.SpawnChair(new Vector3(transform.position.x + deltaXo, transform.position.y - 5f, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnChair(new Vector3(transform.position.x - deltaXo, transform.position.y - 5f, transform.position.z)); }
            }

            if (selector == 5)
            {
                if (decider == 1) { itemGenerator.SpawnClock(new Vector3(transform.position.x + deltaXo, transform.position.y + 1000f, transform.position.z)); }

                if (decider == 2) { itemGenerator.SpawnClock(new Vector3(transform.position.x - deltaXo, transform.position.y + 1000f, transform.position.z)); }
            }



        }

    }
}
