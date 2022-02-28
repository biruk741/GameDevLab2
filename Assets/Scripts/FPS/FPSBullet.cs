using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float moveTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    IEnumerator FireRoutine()
    {
        float elapsedTime = 0;
        while (elapsedTime <= moveTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
