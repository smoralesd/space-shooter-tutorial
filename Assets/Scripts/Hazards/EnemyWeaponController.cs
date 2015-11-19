using UnityEngine;

public class EnemyWeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform spawnShot;
    public float fireRate;
    public float firstFireDelay;

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", firstFireDelay, fireRate);
    }

    private void Fire() {
        Instantiate(shot, spawnShot.position, spawnShot.rotation);
        audioSource.Play();
    }
}
