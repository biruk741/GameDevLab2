using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerSwimmer : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private float speed = 200;
    
    private static readonly int SWIMMING = Animator.StringToHash("isSwimming");

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isSwimming = false;
        //
        if (Input.GetKey(KeyCode.W)) {
            rigidBody.AddForce(new Vector2(0,Time.deltaTime * speed));
            isSwimming = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddForce(new Vector2(0, -1 * Time.deltaTime * speed));
            isSwimming = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(new Vector2(-1 * Time.deltaTime * speed, 0));
            spriteRenderer.flipX = true;
            isSwimming = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(new Vector2(Time.deltaTime * speed, 0));
            spriteRenderer.flipX = false;
            isSwimming = true;

        }

        animator.SetBool(SWIMMING, isSwimming );
        Debug.Log(isSwimming);

    }
}
