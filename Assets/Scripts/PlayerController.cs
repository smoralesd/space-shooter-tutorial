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

    private float nextShot = 0f;

    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextShot) {
            nextShot = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            AudioSource shotAudio = GetComponent<AudioSource>();
            shotAudio.Play();
        }
    }

    public void FixedUpdate() {
        Rigidbody playerRigidBody = GetComponent<Rigidbody>();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        playerRigidBody.velocity = speed * movement;

        Vector3 currentPosition = playerRigidBody.position;
        float clampX = Mathf.Clamp(currentPosition.x, boundary.xMin, boundary.xMax);
        float clampZ = Mathf.Clamp(currentPosition.z, boundary.zMin, boundary.zMax);
        playerRigidBody.position = new Vector3(clampX, 0, clampZ);

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, playerRigidBody.velocity.x * -tilt);
    }
}
