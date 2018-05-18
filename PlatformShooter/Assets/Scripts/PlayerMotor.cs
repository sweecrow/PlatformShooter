using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerMotor : NetworkBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;
    
    public float healthMax = 100;
    public float healthCurrent;
    public Image currentHealthBar;
    public Text ratiotext;
    public float ratio;
    public bool isRegenHealthTrue;
    public int healthReg;
    public Text healthText;
 
    private Rigidbody2D rigidbody2d;
    public Transform groundCheckPoint;
    public float GroundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
 
    private Animator anim;

    public void UpdateHealthBar()
    {
        ratio = healthCurrent / healthMax;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratiotext.text = (ratio * 100).ToString() + "%";
    }

    void Awake()
    {
        healthCurrent = healthMax;
    }

    void Start ()
    {
        UpdateHealthBar();

        rigidbody2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        if (isLocalPlayer == true)
        {
            if(Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(Vector2.right * Time.deltaTime * 3f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(Vector2.left * Time.deltaTime * 3f);
            }


            /*
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
            
            anim.SetFloat("Speed", Mathf.Abs(rigidbody2d.velocity.x));
            anim.SetBool("Grounded", isGrounded);
            */
        }

        

        
        /*
        if (healthCurrent != healthMax && !isRegenHealthTrue)
        {
            StartCoroutine(RegainHealth());
        }

        healthText.text = "Health: " + healthCurrent.ToString();

        if (healthCurrent <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator RegainHealth()
    {
        isRegenHealthTrue = true;
        while (healthCurrent < healthMax)
        {
            healthCurrent += healthReg;
            UpdateHealthBar();
            yield return new WaitForSeconds(0.5f);
        }
        isRegenHealthTrue = false;
    }

    public void TakeDamage()
    {
        healthCurrent -= 10;
        UpdateHealthBar();
    }
    */
}