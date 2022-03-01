using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSConsumable : MonoBehaviour
{
    public enum ConsumableType
    {
        HEALTH, AMMO
    }
    public float speed = 100;
    public ConsumableType consumableType = ConsumableType.AMMO;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(transform.rotation.x, Time.deltaTime * speed, transform.rotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FPSPlayer instance = FPSPlayer.instance;
            switch (consumableType)
            {
                case ConsumableType.HEALTH:
                    if (instance.Health != instance.maxHealth)
                    {
                        FPSPlayer.instance.IncreaseHealth();
                        Destroy(gameObject);
                    }
                    break;
                case ConsumableType.AMMO:
                    if (instance.Ammo != instance.maxAmmo)
                    {
                        FPSPlayer.instance.IncreaseAmmo();
                        Destroy(gameObject);
                    }
                    break;
            }

        }
    }
}
