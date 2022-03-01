using BigRookGames.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayer : MonoBehaviour
{
    public static FPSPlayer instance;

    [SerializeField] private Transform shootPosition;
    [SerializeField] private Transform head;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private FPSUI fpsUI;
    [SerializeField] public int maxHealth;
    [SerializeField] public int maxAmmo = 200;

    public AudioSource damageSound;
    public Image damageIndicator;
    public Image ammoIndicator;



    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        Health = maxHealth;
        Ammo = maxAmmo;
    }

    // Update is called once per frame

    private float lastShootTime = 0;
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastShootTime > 0.1f && Ammo > 0) {
            GameObject bulletPrefab = bullets[Random.Range(0, bullets.Length)];
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.SetPositionAndRotation(shootPosition.position, shootPosition.rotation);
            GunfireController.instance.FireWeapon();
            Ammo--;
            lastShootTime = Time.time;
        }
    }

    private float lastHitTime;

    private int health = 0;
    public int Health { 
        get { return health; } private set {
            health = value > maxHealth ? maxHealth : value < 0 ? 0 : value;
            fpsUI.ShowHealthFraction((float)Health / (float)maxHealth);
            if (health <= 0)
            {
                LoadingScreen.LoadScene("MainMenu");
            }
        } 
    }

    private int ammo = 0;
    public int Ammo
    {
        get { return ammo; }
        private set
        {
            ammo = value > maxAmmo ? maxAmmo : value < 0 ? 0 : value;
            fpsUI.showAmmo(Ammo);
        }
    }

    public void IncreaseAmmo() {
        Ammo += 100;
    }

    public void IncreaseHealth()
    {
        Health += 5;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy") && (Time.time - lastHitTime > 0.5f))
        {
            lastHitTime = Time.time;
            Destroy(hit.gameObject);
            if (Health > 0)
            {
                Health--;
                StartCoroutine(showDamageIndicator());
                damageSound.Play();
            }
        }
    }

    private IEnumerator showDamageIndicator() {
        Color originalColor = damageIndicator.color;
        damageIndicator.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        damageIndicator.color = originalColor;
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
