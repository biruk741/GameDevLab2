using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    [SerializeField] Rigidbody2D mainRigidBody;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //mainRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            mainSpriteRenderer.flipX = true;
            mainRigidBody.AddForce(new Vector2(-speed * Time.deltaTime,0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            mainSpriteRenderer.flipX = false;
            mainRigidBody.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) if(mainRigidBody.velocity.y==0) mainRigidBody.AddForce(new Vector2(0,jumpSpeed));
    }
}
