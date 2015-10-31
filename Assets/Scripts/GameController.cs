using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public int hazardCount;
    public GameObject[] hazards;

    public Vector3 spawnValue;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;

    public GUIText resetText;
    public GUIText gameOverText;

    private int playerScore;
    private bool gameOver;
    private bool restart;

    public void Start() {
        playerScore = 0;
        gameOver = false;
        restart = false;

        resetText.text = "";
        gameOverText.text = "";

        UpdateScore();
        StartCoroutine(SpawnWave());
    }

    public void Update() {

        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public IEnumerator SpawnWave() {
        yield return new WaitForSeconds(startWait);

        while (true) {

            for (int i = 0; i < hazardCount; ++i) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                int hazardIndex = Random.Range(0, hazards.Length);
                GameObject hazard = hazards[hazardIndex];
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver) {
                resetText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
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
}
