using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = FPSPlayer.instance.transform.position;
        transform.LookAt(playerPos);

        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.x = 0;
        transform.eulerAngles = currentRotation;

        Vector3 directionToPlayer = (playerPos - transform.position).normalized;
        Vector3 modified = directionToPlayer * moveSpeed * Time.deltaTime;
        modified.y = 0;
        transform.position += modified;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            FPSPlayer.instance.HandleEnemyDefeat();
        }
    }
}
