using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConsumable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gunAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player") { StartCoroutine(takeGun()); }
    }

    IEnumerator takeGun()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    IEnumerator gunAnimation() {
        while (true) {
            if (Time.deltaTime % 2 == 0) {
                Quaternion r = transform.rotation;
                transform.rotation = new Quaternion(r.x, r.y, r.z+0.01f, r.w);
            }
            yield return null;
        }
    }
}
