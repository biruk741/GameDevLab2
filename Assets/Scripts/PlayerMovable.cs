using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovable : MonoBehaviour
{
    [SerializeField] KeyCode positive;
    [SerializeField] KeyCode negative;
    [SerializeField] float speed;
    [SerializeField] Transform cameraTransform;
    [SerializeField] Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(positive)) GetComponent<Rigidbody>().velocity += vector * speed * Time.deltaTime;
        if (Input.GetKey(negative)) GetComponent<Rigidbody>().velocity -= vector * speed * Time.deltaTime;
    }
}
