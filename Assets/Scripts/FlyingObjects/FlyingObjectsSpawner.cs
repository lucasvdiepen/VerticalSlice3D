using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private int objectsToSpawn = 5;
    [SerializeField] private float randomXRange = 4f;
    [SerializeField] private float randomYRange = 1f;
    [SerializeField] private float minAngle = 20;
    [SerializeField] private float maxAngle = 30;
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnObjects()
    {
        List<Collider> spawnedObjects = new List<Collider>();

        for(int i = 0; i < objectsToSpawn; i++)
        {
            //Spawn random object
            GameObject newObject = Instantiate(objects[Random.Range(0, objects.Length)], transform.position, Quaternion.identity);
            Collider newObjectCollider = newObject.GetComponent<Collider>();

            //Ignore collision with other spawned objects
            foreach(Collider spawnedObject in spawnedObjects)
            {
                Physics.IgnoreCollision(newObjectCollider, spawnedObject);
            }
            spawnedObjects.Add(newObjectCollider);

            //Get target position with random x in range
            Vector3 targetPosition = new Vector3(Random.Range(target.position.x - randomXRange, target.position.x + randomXRange), Random.Range(target.position.y - randomYRange, target.position.y + randomYRange), target.position.z);

            newObject.GetComponent<FlyingObject>().ThrowObject(targetPosition, Random.Range(minAngle, maxAngle));
        }
    }

    private void Update()
    {
        //For testing
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObjects();
        }
    }
}
