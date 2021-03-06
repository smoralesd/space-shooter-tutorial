﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public int hazardCount;
    public GameObject[] hazards;

    public Vector3 spawnValue;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text playerSpeed;
    public Text playerFireRate;
    public Text gameOverText;
    public GameObject restartButton;
    public BoostController boostController;

    private int playerScore;
    private bool gameOver;

    public void Start() {
        playerScore = 0;

        restartButton.SetActive(false);
        gameOverText.text = "";

        UpdateScore();
        StartCoroutine(SpawnWave());
    }

    public IEnumerator SpawnWave() {
        yield return new WaitForSeconds(startWait);

        while (true) {

            for (int i = 0; i < hazardCount; ++i) {
                if (gameOver) {
                    break;
                }
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                int hazardIndex = Random.Range(0, hazards.Length);
                GameObject hazard = hazards[hazardIndex];
                if (hazard != null) {
                    //Debug.Log("hazard: " + hazard);
                    //Debug.Log("position: " + spawnPosition);
                    //Debug.Log("rotation: " + spawnRotation);
                    Instantiate(hazard, spawnPosition, spawnRotation);
                } else {
                    Debug.Log("no hazard found for index: " + hazardIndex);
                }

                yield return new WaitForSeconds(spawnWait);
            }

            if (gameOver) {
                restartButton.SetActive(true);
                break;
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int score) {
        playerScore += score;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: " + playerScore;
    }

    public void GameOver() {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    public void RestartGame() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void SpawnRandomBoost(Vector3 position) {
        boostController.SpawnRandomBoost(position);
    }

    public void SetSpeedText(string speed) {
        playerSpeed.text = "Speed: " + speed;
    }

    public void SetFireRateText(string fireRate) {
        playerFireRate.text = "Fire Rate: " + fireRate;
    }
}
