using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {

    public float dodge;
    public float smoothing;
    public float tilt;

    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;

    private float targetManeuver;
    private Rigidbody rb;

    public void Start() {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Evade());
    }

    IEnumerator Evade() {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true) {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);

            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    public void FixedUpdate() {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, rb.velocity.z);

        float clampX = Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax);
        float clampZ = Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax);
        rb.position = new Vector3(clampX, 0.0f, clampZ);

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
