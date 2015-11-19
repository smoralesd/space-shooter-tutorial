using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

    public int scoreValue;

    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); 
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null) {
            Debug.Log("No game controller found");
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (!ShouldInteractWith(other)) {
            return;
        }

        if (explosion != null) {
            Transform thisTransform = GetComponent<Transform>();
            Instantiate(explosion, thisTransform.position, thisTransform.rotation);
            gameController.SpawnRandomBoost(thisTransform.position);
        }

        if (other.CompareTag("Player")) {
            Transform playerTransform = other.GetComponent<Transform>();
            Instantiate(playerExplosion, playerTransform.position, playerTransform.rotation);
            gameController.GameOver();
        }
        
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private bool ShouldInteractWith(Collider other) {
        return !(other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Boost"));
    }
};
