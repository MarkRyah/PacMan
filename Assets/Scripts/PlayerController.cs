using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.Experimental;

public class PlayerController : MonoBehaviour {
    public float speed = 1.0f;
    public int maxHealth = 3;
	public static int score;
	public Text scoreText;
    bool isMoving = false;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    public float updateSpeed;
    public int totalPellets;
    public Vector3 currentDirection;
    private Vector2 direction = Vector2.zero;
    public int totalSwords = 0;
    public int health { get { return currentHealth; } }
    int currentHealth;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    AudioSource drachmaePickupClip;

    // Start is called before the first frame update
    void Start () {
        //rigidbody2d = GetComponent<rigidbody2d>();
        drachmaePickupClip =GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update () {
        //MoveCharacter ();
        updateSpeed = 0.15f;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private bool Look(Vector3 direction)
    {
        currentDirection = direction;

        int layerMask = (LayerMask.GetMask("wall"));
        Debug.DrawRay(transform.position, direction, Color.green, 0.9f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.9f, layerMask);
        if (hit == true )
        {
            return true;
        }
        return false;
    }

    private void MoveCharacter()
    // Left, Right, Up, Down
    {
        if (Input.GetKey(KeyCode.UpArrow) && isMoving == false && Look(Vector3.up) == false)
        {
            StartCoroutine(setMovement(Vector3.up));
        }

        if (Input.GetKey(KeyCode.LeftArrow) && isMoving == false && Look(Vector3.left) == false)
        {
            StartCoroutine(setMovement(Vector3.left));
        }

        if (Input.GetKey(KeyCode.DownArrow) && isMoving == false && Look(Vector3.down) == false)
        {
            StartCoroutine(setMovement(Vector3.down));
        }

        if (Input.GetKey(KeyCode.RightArrow) && isMoving == false && Look(Vector3.right) == false)
        {
            StartCoroutine(setMovement(Vector3.right));
        }
        //collision update
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Death();
        }
    }
    private IEnumerator setMovement(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        currentPosition = transform.position;
        newPosition = currentPosition + direction;

        while (elapsedTime < updateSpeed)
        {
            transform.position = Vector3.Lerp(currentPosition, newPosition, (elapsedTime / updateSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = newPosition;

        isMoving = false;
    }
    void OnTriggerEnter2D (Collider2D other) {

        drachmaePickup controller = other.GetComponent<drachmaePickup> ();

        if (controller != null) {
            
            drachmaePickupClip.Play();
        }

        if (other.tag == "enemy")
        {
            Death();
        }
        if (other.tag == "pellet")
        {
            totalPellets++;
            Destroy(other.gameObject);
            drachmaePickupClip.Play();
        }
        if (other.tag == "sword")
        {
            totalPellets++;
            Destroy(other.gameObject);
        }
        if (other.tag == "powerup")
        {
            totalPellets++;
            Destroy(other.gameObject);
        }
    }
    private void Death()
    {
        //actual death script
        maxHealth = maxHealth - 1;
    }
}