using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] bool travellingRight = true;
    [SerializeField] float speed = 1;
    [SerializeField] private int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveCharacter());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision!");
        string collider = collision.collider.tag;
        if (collider == "Player")
        {
            if (collision.collider.transform.position.y > transform.position.y +
                0.5 * GetComponent<BoxCollider2D>().bounds.size.magnitude)
            {
                StartCoroutine(killCharacter());
            }
            else SceneManager.LoadScene("NotQuitePlatformerScene");
        }
        else if (collider == "Bullet")
        {
            StartCoroutine(damageCharacter());
        }
        else if (collider != "Ground")
        {
            travellingRight = !travellingRight;
        }
        
    }
    IEnumerator moveCharacter() {
        while (true)
        {
            transform.position += new Vector3(1f,0,0) * (travellingRight ? 1 : -1) * speed * Time.deltaTime;
            GetComponent<SpriteRenderer>().flipX = !travellingRight;
            yield return null;
        }
    }

    IEnumerator killCharacter()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private static readonly WaitForSeconds flashWait = new WaitForSeconds(0.1f);
    IEnumerator damageCharacter()
    {
        health -= 20;
        GetComponent<SpriteRenderer>().color = Color.blue;
        yield return flashWait;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
