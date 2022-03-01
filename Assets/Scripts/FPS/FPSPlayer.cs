using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    public static FPSPlayer instance;

    [SerializeField] private Transform shootPosition;
    [SerializeField] private Transform head;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private FPSUI fpsUI;
    [SerializeField] private int maxHealth;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        Health = maxHealth;
    }

    // Update is called once per frame

    private float lastShootTime = 0;
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastShootTime > 0.1f) {
            GameObject bulletPrefab = bullets[Random.Range(0, bullets.Length)];
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.SetPositionAndRotation(shootPosition.position, shootPosition.rotation);
            shootSound.Play();
            lastShootTime = Time.time;
        }
    }

    private float lastHitTime;

    private int health = 0;
    public int Health { 
        get { return health; } private set {
            health = value;
            fpsUI.ShowHealthFraction((float)Health / (float)maxHealth);
            if (health <= 0)
            {
                LoadingScreen.LoadScene("MainMenu");
            }
        } 
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy") && (Time.time - lastHitTime > 1f))
        {
            lastHitTime = Time.time;
            Destroy(hit.gameObject);
            if (Health > 0)
            {
                Health--;
            }
        }
    }

    private int enemyDefeatCount;
    public void HandleEnemyDefeat()
    {
        enemyDefeatCount++;
        fpsUI.ShowEnemyDefeatCount(enemyDefeatCount);
    }

    public bool ShouldSpawn(Vector3 pos)
    {
        Vector3 posDiff = pos - transform.position;

        Vector3 faceDirection = head.forward;

        float distanceFromPlayer = posDiff.magnitude;

        return (Vector3.Dot(posDiff.normalized, faceDirection) < 0.5f) && (distanceFromPlayer > 10f);
    }
}
