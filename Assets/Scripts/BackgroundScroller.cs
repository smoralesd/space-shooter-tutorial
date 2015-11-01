using UnityEngine;
using UnityEditor;

public class BackgroundScroller : MonoBehaviour {

    public float scrollSpeed;
    private Vector3 startPosition;

    void Start() {
        startPosition = transform.position;
    }

	void Update () {
        float length = gameObject.transform.localScale.y;
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, length);
        transform.position = startPosition +  Vector3.forward * newPosition;
	}
}
