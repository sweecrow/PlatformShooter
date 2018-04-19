using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public int healthMax = 100;
    public int healthCurrent;

    public bool isRegenHealthTrue;
    public int healthReg;

    public Text healthText;

    private Rigidbody2D rigidbody2d;

    public Transform groundCheckPoint;
    public float GroundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator anim;

    void Awake()
    {
        healthCurrent = healthMax;
    }

    void Start ()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        healthText.text = "Health: " + healthCurrent.ToString();

        if (healthCurrent <= 0)
        {
            Destroy(gameObject);
        }

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
/*
        if (rigidbody2d.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rigidbody2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
*/
        anim.SetFloat("Speed", Mathf.Abs(rigidbody2d.velocity.x));
        anim.SetBool("Grounded", isGrounded);

        if (healthCurrent != healthMax && !isRegenHealthTrue)
        {
            StartCoroutine(RegainHealth());
        }
    }

    private IEnumerator RegainHealth()
    {
        isRegenHealthTrue = true;
        while (healthCurrent < healthMax)
        {
            healthCurrent += healthReg;
            yield return new WaitForSeconds(0.5f);
        }
        isRegenHealthTrue = false;
    }

    public void TakeDamage()
    {
        healthCurrent -= 10;
    }
}