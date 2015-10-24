using UnityEngine;
using UnityEditor;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other) {
        Debug.Log("OnTriggerExit"); 
        Destroy(other.gameObject);
    }
}
