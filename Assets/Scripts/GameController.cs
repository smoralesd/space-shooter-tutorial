using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public int hazardCount;
    public GameObject hazard;

    public Vector3 spawnValue;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    private int playerScore;

    public void Start() {
        playerScore = 0;
        UpdateScore();
        StartCoroutine(SpawnWave());
    }

    public IEnumerator SpawnWave() {
        yield return new WaitForSeconds(startWait);

        while (true) {
            
            for (int i = 0; i < hazardCount; ++i) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
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
}
