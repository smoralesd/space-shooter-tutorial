using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class PlayerController : MonoBehaviour {

    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public Transform[] shotSpawns;
    public Constants.RATES fireRate;
    public Constants.RATES speed;

    public SimpleTouchPad touchPad;

    private float speedValue;
    private float fireRateValue;
    private Quaternion calibrationQuaternion;
    private float nextShot = 0f;

    void Start() {
        UpdateFireRate();
        UpdateSpeed();
    }

    void Update() {
        if (Time.time > nextShot) {
            ShotFire();
        }
    }

    private void ShotFire() {
        nextShot = Time.time + fireRateValue;
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        AudioSource shotAudio = GetComponent<AudioSource>();
        shotAudio.Play();
    }

    public void FixedUpdate() {
        Rigidbody playerRigidBody = GetComponent<Rigidbody>();

        Vector2 direction = touchPad.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);
        playerRigidBody.velocity = speedValue * movement;

        Vector3 currentPosition = playerRigidBody.position;
        float clampX = Mathf.Clamp(currentPosition.x, boundary.xMin, boundary.xMax);
        float clampZ = Mathf.Clamp(currentPosition.z, boundary.zMin, boundary.zMax);
        playerRigidBody.position = new Vector3(clampX, 0, clampZ);

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, playerRigidBody.velocity.x * -tilt);
    }

    public void UpdateFireRate() {
        fireRateValue = UtilFunctions.GetFireRateValue(fireRate);
    }

    public void UpdateSpeed() {
        speedValue = UtilFunctions.GetSpeedValue(speed);
    }
}
