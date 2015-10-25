using UnityEngine;
using UnityEditor;

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
        if (other.tag == "Boundary") {
            return;
        }

        Transform thisTransform = GetComponent<Transform>();
        Instantiate(explosion, thisTransform.position, thisTransform.rotation);

        if (other.tag == "Player") {
            Transform playerTransform = other.GetComponent<Transform>();
            Instantiate(playerExplosion, playerTransform.position, playerTransform.rotation);
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
};
