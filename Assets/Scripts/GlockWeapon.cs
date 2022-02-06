using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockWeapon : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPosition;
    [SerializeField] GameObject muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shootBullets());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shootBullets()
    {
        while (true)
        {
            muzzleFlash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.SetPositionAndRotation(shootPosition.position, shootPosition.rotation);
            muzzleFlash.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
    }

}
