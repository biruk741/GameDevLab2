using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] private float speed;


    private WaitForSeconds beginDelay = new WaitForSeconds(1);

    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(moveBall());
    }

    IEnumerator moveBall() {
        yield return beginDelay;
        Vector3 vector = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        rigidBody.AddForce(vector.normalized * speed);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
