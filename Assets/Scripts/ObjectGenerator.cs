using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] spawnLocals;
    public float spawnCooldown;
    public float spawnTimeLeft;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimeLeft = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimeLeft -= Time.deltaTime;

        if (spawnTimeLeft <= 0)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        int randomObject = Random.Range(0, spawnObjects.Length);
        int randomLocal = Random.Range(0, spawnLocals.Length);

        Instantiate(spawnObjects[randomObject], spawnLocals[randomLocal].position, spawnObjects[randomObject].transform.rotation);
        spawnTimeLeft = spawnCooldown;
    }
}
