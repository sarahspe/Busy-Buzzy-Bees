
using UnityEditor;
using UnityEngine;

public class NewBehaviorScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(transform.gameObject);
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        if(Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y/2);

        else
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        anim.SetBool("Walk to Run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Ground")
           grounded = true;
    }

}
