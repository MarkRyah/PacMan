using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinotaurController : MonoBehaviour
{
    public float speed = 2.9f;
    private Vector2 direction = Vector2.zero;

    [Header("INIT")]
    [SerializeField] public LayerMask PlayerLayer;
    [SerializeField] public PlayerController playerScript;
     public Tilemap tiles;


    [Header("STATES")]
    [SerializeField]public bool terrified = false;
    [SerializeField] public bool pursuing = true;
    [SerializeField] public Vector3 targetPos;
    [SerializeField] public bool destroyed = false;
    [SerializeField] public bool runningAway;

    private float PursueTimer;
    public float totalPursueTime;
    private float attackableTimer;
    private float totalAttackableTimer;

    public Vector3 prevDirection = new Vector3(0, 0, 0);
    public float totalScatterTime;
    
    public float destroyedTimer;
    public GameObject boxWaypoint;
    public GameObject player;
    private int maxPellets;
    public float startPercent;
    private bool isMoving;
    private float elapsedTime;
    public int targetOffset;
    public Vector3 scatterPos;
    private Vector3 prevPosition;
    public float timeToMove;
    public GameObject waypoint;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        Check();
    }

    private bool Look(Vector3 direction)
    {
        int layerMask = (LayerMask.GetMask("wall"));
        Debug.DrawRay(transform.position, direction, Color.green, 0.9f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.9f, layerMask);
        if (hit == true)
        {
            return true;
        }
        return false;
    }

    private void Check()
    {
        if (terrified == false)
        {
            PursueTimer -= Time.deltaTime;
        }
        else //terrified is true
        {
            attackableTimer -= Time.deltaTime;
        }
        if (PursueTimer <= 0)
        {
            pursuing = !pursuing;
            prevDirection *= -1; 
            if (pursuing)
            {
                totalPursueTime += 5;
                PursueTimer = totalPursueTime;
            }
            else
            {
                totalScatterTime *= 0.9f;
                PursueTimer = totalScatterTime;
            }
        }


        if (destroyed == true && transform.position == boxWaypoint.transform.position)
        {
            destroyed = false;
            //GetComponent<CircleCollider2D>().enabled = true;
            //GetComponent<SpriteRenderer>().enabled = true;
        }

        if (terrified == true && attackableTimer < 0)
        {
            terrified = false;
 
        }

        if (isMoving)
            return;

        if (destroyed)
        {
            targetPos = boxWaypoint.transform.position;
        }
        else if (pursuing && terrified == false)
        {
            targetPos = player.transform.position + (playerScript.currentDirection * targetOffset); 
            if (runningAway && Vector3.Distance(targetPos, transform.position) < 4)
                targetPos = scatterPos;
        }
        else
        {
            targetPos = scatterPos;
        }

        CheckMovement();


    }



    private void CheckMovement()
    {
        Vector3 newDirection = new Vector3(0, 0, 0);
        float distance = 1000000;
        if (prevDirection != Vector3.up && Look(Vector3.up) == false) //checking if we're going backwards, then if there's a wall in the way
        {
            //Debug.Log("Can go Up");
            if (Vector3.Distance(targetPos, transform.position + Vector3.up) <= distance) //comparing our future position's distance
            {
                distance = Vector3.Distance(targetPos, transform.position + Vector3.up);
                newDirection = Vector3.up;
            }
        }
        //now check the same for the other 3 directions
        if (prevDirection != Vector3.left && Look(Vector3.left) == false)
        {
            //Debug.Log("Can go left");
            if (Vector3.Distance(targetPos, transform.position + Vector3.left) <= distance)
            {
                distance = Vector3.Distance(targetPos, transform.position + Vector3.left);
                newDirection = Vector3.left;
            }
        }
        if (prevDirection != Vector3.down && Look(Vector3.down) == false)
        {
            //.Log("Can go Down");
            if (Vector3.Distance(targetPos, transform.position + Vector3.down) <= distance)
            {
                distance = Vector3.Distance(targetPos, transform.position + Vector3.down);
                newDirection = Vector3.down;
            }
        }
        if (prevDirection != Vector3.right && Look(Vector3.right) == false)
        {
            //Debug.Log("Can go Right");
            if (Vector3.Distance(targetPos, transform.position + Vector3.right) <= distance)
            {
                distance = Vector3.Distance(targetPos, transform.position + Vector3.right);
                newDirection = Vector3.right;
            }
        }
        //Debug.Log(newDirection);
        {
            StartCoroutine(MoveEnemy(newDirection));
        }
    }

    private IEnumerator MoveEnemy(Vector3 direction)
    {
        isMoving = true;
        elapsedTime = 0;
        prevDirection = direction * -1; //flip it to check if we go backwards later

        prevPosition = transform.position;
        targetPos = prevPosition + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(prevPosition, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }


}
