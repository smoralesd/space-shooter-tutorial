using UnityEngine;
using UnityEditor;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

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

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
};
