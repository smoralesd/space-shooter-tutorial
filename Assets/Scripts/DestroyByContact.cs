using UnityEngine;
using UnityEditor;

public class DestroyByContact : MonoBehaviour {

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundary") {
            return;
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}