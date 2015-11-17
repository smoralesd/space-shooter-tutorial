using UnityEngine;
using System.Collections.Generic;

public class PlayerWeaponController : MonoBehaviour {

    public Constants.RATES fireRate;
    public GameObject shot;
    public ShotSpawnController[] shotSpawns;
    public Constants.WeaponTypes currentWeapon;

    private int shotSpawnIndex = 1;
    private float fireRateValue;
    private float nextShot = 0f;
    private Dictionary<Constants.WeaponTypes, ShotSpawnController> availableShotSpawns;

    void Start() {
        if (shotSpawns != null && shotSpawns.Length > 0) {
            availableShotSpawns = new Dictionary<Constants.WeaponTypes, ShotSpawnController>(shotSpawns.Length);
            for (int i = 0; i < shotSpawns.Length; ++i) {
                ShotSpawnController current = shotSpawns[i];
                availableShotSpawns.Add(current.type, current);
            }
        }
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
    }

    public void FireRateUp() {
        fireRate = UtilFunctions.GetNextRate(fireRate);
        UpdateFireRateValue();
    }
}
