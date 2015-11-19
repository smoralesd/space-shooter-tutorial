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

    public Transform shotSpawn;
    public Transform[] shotSpawns;
    public Constants.RATES speed;
    public PlayerWeaponController weaponController;
    public SimpleTouchPad touchPad;

    private float speedValue;
    private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); 
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        weaponController.UpdateFireRateValue();
        UpdateSpeed();
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

    public void FireRateUp() {
        weaponController.FireRateUp();
    }

    public void UpdateSpeed() {
        speedValue = UtilFunctions.GetSpeedValue(speed);
        int speedToText = (int)speed + 1;
        gameController.SetSpeedText(speedToText + "");
    }

    public void SetWeaponType(Constants.WEAPON_TYPES type) {
        weaponController.SetWeaponType(type);
    }
}
