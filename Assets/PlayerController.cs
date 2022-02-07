using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    [SerializeField] Rigidbody2D mainRigidBody;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] private TMPro.TextMeshProUGUI coinCounter;


    [SerializeField] private bool usingGun = false;
    private Quaternion defaultRotation;
    [SerializeField] private int coins = 0;


    // Start is called before the first frame update
    void Start()
    {
        //mainRigidBody = GetComponent<Rigidbody2D>();
        defaultRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = defaultRotation;
            Quaternion rotation = transform.rotation;
            transform.rotation = new Quaternion(rotation.x, rotation.y + 180f, rotation.z, rotation.w);
            mainRigidBody.AddForce(new Vector2(-speed * Time.deltaTime,0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = defaultRotation;
            Quaternion rotation = transform.rotation;
            transform.rotation = new Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);
            mainRigidBody.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }

        //if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        //{
          //  transform.rotation = new Quaternion(defaultRotation.x, defaultRotation.y, defaultRotation.z, defaultRotation.w);
        //}

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) if(mainRigidBody.velocity.y==0) mainRigidBody.AddForce(new Vector2(0,jumpSpeed));
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Glock")) { transform.GetChild(0).gameObject.SetActive(true); }
        if (collision.gameObject.CompareTag("Coin")) {
            coins++;
            coinCounter.SetText(coins + "");
        }


    }
}
