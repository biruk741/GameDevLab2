using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button openCreditsButton;
    [SerializeField] private Button closeCreditsButton;
    [SerializeField] private GameObject creditsUI;
    [SerializeField] private Button platformerButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() => {
            doSomething();
        });
        openCreditsButton.onClick.AddListener(() => {
            creditsUI.SetActive(true);
        });
        closeCreditsButton.onClick.AddListener(() => {
            creditsUI.SetActive(false);
        });
        platformerButton.onClick.AddListener(() => {
            LoadingScreen.LoadScene("NotQuitePlatformerScene");
        });
    }

    private void doSomething()
    {
        LoadingScreen.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
