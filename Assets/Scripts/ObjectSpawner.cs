using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private Transform spawnLocation;
    [SerializeField] private SpawnObject objectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            SpawnObject newObject = Instantiate(objectPrefab);
            newObject.transform.SetPositionAndRotation(spawnLocation.position, spawnLocation.rotation);
        }
    }
}
