using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public event Action onScore;
    [Range(1,2)]
    [SerializeField] private int player = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball")) switch (player) {
            case 1:
                    onScore();
                break;
            case 2:
                    onScore();
                break;
        }
    }
}
