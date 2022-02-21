using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] private float speed;
    [SerializeField] private Transform startPos;
    [SerializeField] private AudioSource bouncePlayer;
    [SerializeField] private AudioSource bounceEdge;
    [SerializeField] private AudioSource goalSound;
    [SerializeField] private SpriteRenderer renderer;



    private WaitForSeconds beginDelay = new WaitForSeconds(1);


    public void Restart() {
        StartCoroutine(moveBall());
    }

    IEnumerator moveBall() {
        transform.position = startPos.position;
        rigidBody.velocity = Vector3.zero;
        yield return beginDelay;
        float y;
        float x = Random.Range(2f, 5f);
        do
        {
            y = Random.Range(0.5f, 1f);
        } while (Mathf.Abs(y) < 0.4f);
        if (Random.Range(0f, 1f) > 0.5f)
        {
            y = -y;
        } else x = -x;
        Vector3 vector = new Vector3(x, y, 0);
        rigidBody.AddForce(vector.normalized * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            bouncePlayer.Play();
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            goalSound.Play();
        }
        if (collision.gameObject.CompareTag("Edge"))
        {
            bounceEdge.Play();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float velocity = rigidBody.velocity.magnitude;

        int luminance = (int)(255 - velocity);
        luminance = (int)(luminance >= 0 ?  luminance * 0.8 : 0);
        renderer.color = new Color(255, luminance, luminance);
    }
}
