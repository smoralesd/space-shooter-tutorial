using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    public SimpleTouchPad touchPad;

    private Quaternion calibrationQuaternion;
    private float nextShot = 0f;

    void Update() {
        if (Time.time > nextShot) {
            nextShot = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            AudioSource shotAudio = GetComponent<AudioSource>();
            shotAudio.Play();
        }
    }

    public void FixedUpdate() {
        Rigidbody playerRigidBody = GetComponent<Rigidbody>();

        Vector2 direction = touchPad.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);
        playerRigidBody.velocity = speed * movement;

        Vector3 currentPosition = playerRigidBody.position;
        float clampX = Mathf.Clamp(currentPosition.x, boundary.xMin, boundary.xMax);
        float clampZ = Mathf.Clamp(currentPosition.z, boundary.zMin, boundary.zMax);
        playerRigidBody.position = new Vector3(clampX, 0, clampZ);

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, playerRigidBody.velocity.x * -tilt);
    }
}
