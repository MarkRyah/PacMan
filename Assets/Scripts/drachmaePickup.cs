using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drachmaePickup : MonoBehaviour {
    public static int drachmaeCount
	{
		get { return drachmaeCount; }
		set { drachmaeCount = 3700; }
	}
    

    void Start () {
        
    }
    void Update () {

    }
    void OnTriggerEnter2D (Collider2D other) {

        PlayerController controller = other.GetComponent<PlayerController> ();

        if (controller != null) {
            drachmaeCount = drachmaeCount + 10;
            
            Destroy (gameObject);
            controller.scoreText.text = drachmaeCount.ToString("D6");
            
        }
    }
}