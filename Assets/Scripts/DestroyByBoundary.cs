using UnityEngine;
using UnityEditor;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other) {
        Destroy(other.gameObject);
    }
}
