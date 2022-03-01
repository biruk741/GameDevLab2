using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSConsumable : MonoBehaviour
{
    public float speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(transform.rotation.x,Time.deltaTime * speed, transform.rotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            FPSPlayer.instance.IncreaseAmmo();
            Destroy(gameObject);
        }
    }
}
