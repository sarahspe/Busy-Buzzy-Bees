
using UnityEditor;
using UnityEngine;

public class NewBehaviorScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;

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

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        anim.SetBool("Walk to Run", horizontalInput != 0);
    }

}
