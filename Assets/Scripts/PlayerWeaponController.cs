using UnityEngine;
using System.Collections.Generic;

public class PlayerWeaponController : MonoBehaviour {

    public Constants.RATES fireRate;
    public GameObject shot;
    public ShotSpawnController[] shotSpawns;
    public Constants.WEAPON_TYPES currentWeapon;

    private float fireRateValue;
    private float nextShot = 0f;
    private Dictionary<Constants.WEAPON_TYPES, ShotSpawnController> availableShotSpawns;
    private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); 
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (shotSpawns != null && shotSpawns.Length > 0) {
            availableShotSpawns = new Dictionary<Constants.WEAPON_TYPES, ShotSpawnController>(shotSpawns.Length);
            for (int i = 0; i < shotSpawns.Length; ++i) {
                ShotSpawnController current = shotSpawns[i];
                availableShotSpawns.Add(current.type, current);
            }
        }

        UpdateFireRateValue();
    }

    void Update() {
        if (Time.time > nextShot) {
#if UNITY_EDITOR
            UpdateFireRateValue();
#endif
            FireWeapon();
        }
    }

    private void FireWeapon() {
        nextShot = Time.time + fireRateValue;
        InstanciateShots();
        AudioSource shotAudio = GetComponent<AudioSource>();
        shotAudio.Play();
    }

    private void InstanciateShots() {
        ShotSpawnController current = availableShotSpawns[currentWeapon];

        foreach (var spawnPoint in current.shotSpawn) {
            Instantiate(shot, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void UpdateFireRateValue() {
        fireRateValue = UtilFunctions.GetFireRateValue(fireRate);
        gameController.SetFireRateText(((int)fireRate) + "");
    }

    public void FireRateUp() {
        fireRate = UtilFunctions.GetNextRate(fireRate);
        UpdateFireRateValue();
    }

    public void SetWeaponType(Constants.WEAPON_TYPES type) {
        if (ShouldSetWeaponType(type)) {
            currentWeapon = type;
        }
    }

    private bool ShouldSetWeaponType(Constants.WEAPON_TYPES newType) {
        // WEAPON HIERARCHY 
        // LVL 1            SINGLE_SHOT
        // LVL 2    DOUBLE_SHOT     TRI_WAY
        // LVL 3    TRIPLE_SHOT     FIVE_WAY
        // current weapon can move one or more levels up
        // current weapon can swap from one type to another if the types are on the same level
        // current weapon CANNOT move one or more levels down

        if (currentWeapon == Constants.WEAPON_TYPES.SINGLE_SHOT) {
            return true;
        }

        if (newType == Constants.WEAPON_TYPES.FIVE_WAY || newType == Constants.WEAPON_TYPES.TRIPLE_SHOT) {
            return true;
        }

        if (currentWeapon == Constants.WEAPON_TYPES.DOUBLE_SHOT && newType == Constants.WEAPON_TYPES.TRI_WAY) {
            return true;
        }

        if (currentWeapon == Constants.WEAPON_TYPES.TRI_WAY && newType == Constants.WEAPON_TYPES.DOUBLE_SHOT) {
            return true;
        }

        return false;
    }
}
