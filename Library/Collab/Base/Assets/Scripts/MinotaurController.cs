using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinotaurController : MonoBehaviour
{
    public float speed = 2.9f;
    private Vector2 direction = Vector2.zero;
    public Rigidbody2D rb;
    public Node startingpPosition;
    public bool right = false;
    public bool up = false;
    public bool left = false;
    public bool down = false;

    public bool lockRight = false;
    public bool lockUp = false;
    public bool lockLeft = false;
    public bool lockDown = false;

    [Header("INIT")]
    [SerializeField] public LayerMask PlayerLayer;
    [SerializeField] private Transform player = null;
    [SerializeField] public Tilemap tiles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

        determineMovement();
    }

    private void determineMovement()
    {

        if (left == true && lockLeft == false)
        {
            MoveLeft();
        }
  
        if (right == true && lockRight == false)
        {
            MoveRight();

        }
            
        if (up == true && lockUp == false)
        {
            MoveUp();
        }
            
        if (down == true && lockDown == false)
        {
            MoveDown();
        }

        else
        {
            MoveUp();
        }

    }

    private void SelectMovement()
    {
        int chooseMovement = Random.Range(1, 4);
        //Debug.Log(chooseMovement);
        if (chooseMovement == 2)
        {
            right = false;
            up = true;
            left = false;
            down = false;
        }
        if (chooseMovement == 1)
        {
            right = true;
            up = false;
            left = false;
            down = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "nodes")
        {
            Debug.Log("NODES");
        }
    }

    public void MoveUp()
    {
        //Debug.Log("u");
        //direction = Vector2.up;
        //transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
        //Vector3 thisposition = transform.position;
        //float y = rb.velocity.y;
        //if (Mathf.Approximately(rb.velocity.y, 0))
        //{
        //    SelectMovement();
        //}
        Debug.Log("u");
        rb.AddForce(transform.up * speed);
        float y = rb.velocity.y;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        Debug.DrawRay(transform.position, Vector2.up);
        if (hit.collider.transform.root.tag == "wallhit")
        {
            Debug.Log("HIt");
            SelectMovement();
        }

    }

    public void MoveDown()
    {
        Debug.Log("d");
        rb.AddForce(transform.up * -speed);
        float y = rb.velocity.y;
        // Debug.Log(y);
        if (Mathf.Approximately(rb.velocity.y, 0))
        {
            SelectMovement();
        }
    }

    public void MoveLeft()
    {
        Debug.Log("l");
        rb.AddForce(transform.right * -speed);
        float x = rb.velocity.x;
        if (Mathf.Approximately(rb.velocity.x, 0))
        {
            SelectMovement();
        }
    }

    public void MoveRight()
    {
        Debug.Log("r");
        rb.AddForce(transform.right * speed);
        float x = rb.velocity.x;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
        Debug.DrawRay(transform.position, Vector2.right);
        if (hit.collider.transform.root.tag == "nodes")
        {
            Debug.Log("HIt");
            down = true;
        }
    }



    public Vector2 GetPlayerPosition()
    {

        return player.position;
    }


}
