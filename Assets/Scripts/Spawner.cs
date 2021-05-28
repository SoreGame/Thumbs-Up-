using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;
    public GameObject area;
    public int numberToSpawn;

    private void Start()
    {
        SpawnObjects();
    }

    public void SpawnObjects()
    { 
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = area.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 position;

        for (int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, objectsToSpawn.Count);
            toSpawn = objectsToSpawn[randomItem];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            position = new Vector2(screenX, screenY);

            Instantiate(toSpawn, position, toSpawn.transform.rotation);
        }
    }
}
