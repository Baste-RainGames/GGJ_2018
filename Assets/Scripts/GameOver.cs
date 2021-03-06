﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private static GameOver instance;
    public TMP_Text gameOverText;
    public TMP_Text winText;
    private string originalWinText;

    private void Awake() {
        instance = this;
        originalWinText = winText.text;
    }

    public static void DoGameOver() {
        if (instance == null) {
            Debug.LogError("Can't game over with no game over!");
            return;
        }
        instance.StartCoroutine(instance.DoGameOverThang());
    }

    private IEnumerator DoGameOverThang() {
        gameOverText.enabled = true;

        foreach (var playerInput in FindObjectsOfType<PlayerInput>()) {
            playerInput.enabled = false;
        }

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void ShowNextLevelScreen() {
        instance.winText.text = instance.originalWinText;
        instance.winText.enabled = true;
    }

    public static void Show(string text) {
        instance.winText.text = text;
        instance.winText.enabled = true;
    }

    public static void Hide() {
        instance.winText.enabled = false;
    }
}