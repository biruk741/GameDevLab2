using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(takeCoin());
        }
    }
    IEnumerator takeCoin() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 6000));
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

}
