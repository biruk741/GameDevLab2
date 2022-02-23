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
    [SerializeField] private Button spawnButton;
    [SerializeField] private Button FPSButton;

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
        Button[] buttons = {
            platformerButton,
            spawnButton,
            FPSButton
        };

        string[] scenes = {
            "NotQuitePlatformerScene",
            "3DSpawn",
            "FirstPersonShooter"
        };
        platformerButton.onClick.AddListener(() => {
            LoadingScreen.LoadScene(scenes[0]);
        });
        spawnButton.onClick.AddListener(() => {
            LoadingScreen.LoadScene(scenes[1]);
        });
        FPSButton.onClick.AddListener(() => {
            LoadingScreen.LoadScene(scenes[2]);
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
