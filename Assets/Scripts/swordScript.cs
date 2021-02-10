using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour {
    public AudioClip drachmaePickupClip;

    void Start () {

    }
    void Update () {

    }
    void OnTriggerEnter2D (Collider2D other) {

        PlayerController controller = other.GetComponent<PlayerController> ();

        if (controller != null) {
			drachmaePickup.drachmaeCount = drachmaePickup.drachmaeCount + 50;
			Destroy (gameObject);
            controller.scoreText.text = drachmaePickup.drachmaeCount.ToString("D6");
            //controller.PlaySound(drachmaePickupClip);
        }
    }
}