using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bulletTravel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator bulletTravel()
    {
        float currentTime = 0;
        while (currentTime < 2)
        {
            currentTime += Time.deltaTime;
            transform.position += transform.right * speed * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
