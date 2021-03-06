﻿using UnityEngine;

public abstract class BaseBoost : MonoBehaviour {

    public float speed;

    protected PlayerController playerController;

    void Start() {

        GetComponent<Rigidbody>().velocity = GetComponent<Transform>().forward * speed;

        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null) {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
    }

    protected abstract void Apply();

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && playerController != null) {
            Apply();               
            Destroy(gameObject);
        }

    }

    public abstract Constants.BOOST_TYPES GetBoostType(); 
}
