using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    public float scrollSpeed;
    private Vector3 startPosition;

    void Start() {
        Transform objectTransform = GetComponent<Transform>();
        startPosition = objectTransform.position;
    }

    void Update () {
        Transform objectTransform = GetComponent<Transform>();
        float length = objectTransform.localScale.y;
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, length);
        objectTransform.position = startPosition +  Vector3.forward * newPosition;
    }
}
