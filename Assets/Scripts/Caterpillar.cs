using UnityEditor;
using UnityEngine;

public class Caterpillart : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    // private Animator anim;
    private bool grounded = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(transform.gameObject);
        // anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            Debug.Log("Jumping");
        }

        // anim.SetBool("Walk to Run", horizontalInput != 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            grounded = true;
            Debug.Log("Grounded");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            grounded = false;
            Debug.Log("Not Grounded");
        }
    }
}
