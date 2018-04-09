using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rigidbody2d;

    public Transform groundCheckPoint;
    public float GroundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator anim;

    void Start ()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, GroundCheckRadius, whatIsGround);

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
        }

        if (rigidbody2d.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rigidbody2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(rigidbody2d.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }
}