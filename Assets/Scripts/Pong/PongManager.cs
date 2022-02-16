using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    [SerializeField] private Goal leftGoal;

    private void Awake()
    {
        p1Goal.onScore += HandleP2Score;
        p2Goal.onScore += HandleP1Score;
        ball.Restart();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
