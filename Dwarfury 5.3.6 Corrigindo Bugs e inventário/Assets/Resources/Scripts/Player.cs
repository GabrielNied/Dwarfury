using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public delegate void DeadEventHandler();

public class Player : Character
{
    private Enemy enemy;
    private LevelLoader lvl;

    public GameObject canvasBoard;
    public GameObject jumpParticle;
    public Transform playersfeet;

    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }
    public Rigidbody2D myRigidbody;

    public event DeadEventHandler Dead;

    public DashState dashState;
    public float dashTimer;
    public float maxDash = 5f;
    public Vector2 savedVelocity;

    int knockDirection;

    public bool LevelingUp { get; set; }

	public bool trancaMovimento = false;
    private bool attack;
    private bool isGrounded;
    private bool jump;
    private bool jump2;
    private bool pulando;
    //private bool isDashKeyDown;
    private bool immortal = false;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private float immortalTime;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float dashForce;

    public int health;
    public int atk;
    public int def;
    public int maxhealth;
    public int basehealth;
    public int baseatk;
    public int basedef;
    public int level = 1;
	public int baselevel = 1;
    public int exp = 0;
    public int maxexp = 10;
    public int skillpoint;
	public int gold;
	public int basegold;

    public FadeManager fM;

    private GUIStyle guiStyle = new GUIStyle();

    public override void Start()
    {
        fM.Fade(false, 2.0f);

        if (Application.loadedLevel == 1)
        {
			
            randomStats();

            PlayerPrefs.SetInt("Vida", basehealth);
            PlayerPrefs.SetInt("Atq", baseatk);
            PlayerPrefs.SetInt("Def", basedef);
            health = basehealth;
            maxhealth = basehealth;
            atk = baseatk;
            def = basedef;
        }
        enemy = FindObjectOfType<Enemy>();
        base.Start();

        spriteRenderer = GetComponent<SpriteRenderer>();
        myRigidbody = GetComponent<Rigidbody2D>();




    }

    void Awake()
    {
        health = PlayerPrefs.GetInt("Vida1");
        maxhealth = PlayerPrefs.GetInt("Vida2");
        atk = PlayerPrefs.GetInt("Atq1");
        def = PlayerPrefs.GetInt("Def1");
		gold = PlayerPrefs.GetInt ("Gold1");
		level = PlayerPrefs.GetInt ("Level1");
		exp = PlayerPrefs.GetInt ("Exp1");
		if (level < 1) {
			level = 1;
		}
    }

    void Update()
    {

        if (TakingDamage)
        {
            myRigidbody.AddForce(transform.position * -1, ForceMode2D.Impulse);
        }
        if (!TakingDamage && !IsDead && !LevelingUp)
        {
            if (transform.position.y <= -14f)
            {
                myRigidbody.velocity = Vector2.zero;
            }
			if (!trancaMovimento) {
				HandleInput ();
			}else{
				myRigidbody.velocity = Vector2.zero;
				MyAnimator.SetFloat ("speed", Mathf.Abs (0));
				MyAnimator.SetFloat ("speedvertical", Mathf.Abs (0));
			}
        }
    }

    void FixedUpdate()
    {
        if (!TakingDamage && !IsDead && !LevelingUp)
        {
            isGrounded = IsGrounded();
            float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");
            levelup();


			if (!trancaMovimento) {
				HandleMovement (horizontal, vertical);
				HandleMovementEscada ();
				Flip (horizontal);

				HandleAttacks ();
				HandleMovementBau ();
			}
        }
        ResetValues();
    }

    public void OnDead()
    {
        if (Dead != null)
        {
            Dead();
        }
    }

	private void HandleMovement(float horizontal, float vertical)
    {
        //		if (!this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {                                     PARA MOVIMENTAÇÃO QUANDO ATACA
		if (!this.MyAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Bau")) {
			myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);


			MyAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
			MyAnimator.SetFloat ("speedvertical", Mathf.Abs (vertical));
			//		}																											PARA MOVIMENTAÇÃO QUANDO ATACA

			if (pulando && jump2 && !isGrounded) {
				Instantiate (jumpParticle, playersfeet.position, Quaternion.identity);
				myRigidbody.velocity = new Vector2 (0, jumpForce / 50);
				pulando = false;

			} else {
				if (isGrounded && jump) {
					//isGrounded = false;
					myRigidbody.AddForce (new Vector2 (0, jumpForce));
					pulando = true;
					MyAnimator.SetBool ("pulando", true);
				}
			}
		}
    }



    /*            switch (dashState)
                {
                    case DashState.Ready:

                        if (isDashKeyDown)
                        {
                            savedVelocity = GetComponent<Rigidbody2D>().velocity;
                            // myRigidbody.velocity = new Vector2(10 * movementSpeed, 0 * 0);
                            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * 10f, GetComponent<Rigidbody2D>().velocity.y);
                            dashState = DashState.Dashing;
                        }
                        break;
                    case DashState.Dashing:
                        dashTimer += Time.deltaTime * 3;
                        if (dashTimer >= maxDash)
                        {
                            dashTimer = maxDash;
                            GetComponent<Rigidbody2D>().velocity = savedVelocity;
                            dashState = DashState.Cooldown;
                        }
                        break;
                    case DashState.Cooldown:
                        dashTimer -= Time.deltaTime;
                        if (dashTimer <= 0)
                        {
                            dashTimer = 0;
                            dashState = DashState.Ready;
                        }
                        break;
                }                    
        }


    public enum DashState
    {
        Ready,
        Dashing,
        Cooldown
    }
    */

    private void HandleAttacks()
    {
								 //PARA MOVIMENTAÇÃO QUANDO ATACA
			if (attack && !this.MyAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
				MyAnimator.SetTrigger ("attack");
				CombatTextManager.Instance.CreateText (myRigidbody.transform.position, "" + atk);
				//myRigidbody.velocity = Vector2.zero;																 //PARA MOVIMENTAÇÃO QUANDO ATACA
			}
    }

	private void HandleMovementBau(){
		if (abrir == true) {
			if (Input.GetKey(KeyCode.E)) {
				myRigidbody.velocity = Vector2.zero;
				MyAnimator.SetTrigger("bau");					
				abriu = true;
			}
		}
	}


	private void HandleMovementEscada()
	{

		if (subir == true)
		{
			if (Input.GetButton("Subir"))
			{
				MyAnimator.SetBool ("naEscada 0", true);
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 1 * movementSpeed / 2);
			}
		}

		if (descer == true)
		{
			if (Input.GetButton("Descer"))
			{
				MyAnimator.SetBool ("naEscada 0", true);
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -2 * movementSpeed / 2);
			}
		}
	}

    private void HandleInput()
    {
		if (Input.GetButtonDown("Ataca"))
        {
            attack = true;
        }

		if (!subir || !descer) { 
			if (Input.GetButtonDown ("Pular")) {
				jump = true;
			}

			if (Input.GetButtonDown ("Pular")) {
				jump2 = true;
			}
		}

        //        if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        isDashKeyDown = true;
        //    }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            ChangeDirection();
            if (!facingRight)
            {
                canvasBoard.transform.localScale = new Vector3(-0.004f, 0.004f, 0.004f);
            }
            else
            {
                canvasBoard.transform.localScale = new Vector3(0.004f, 0.004f, 0.004f);
            }
        }
    }

    private void ResetValues()
    {
        attack = false;
        // isDashKeyDown = false;
        jump = false;
        jump2 = false;
    }

    private bool IsGrounded()
    {
        //	if (myRigidbody.velocity.y <= 0) {

        foreach (Transform point in groundPoints)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
					MyAnimator.SetBool ("pulando", false);
                    return true;
                    //			}
                }
            }
        }
        return false;
    }

    private IEnumerator IndicateImmortal()
    {
        while (immortal)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            //  spriteRenderer.enable = false;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.enabled = !spriteRenderer.enabled;
            //spriteRenderer.enable = true;
            yield return new WaitForSeconds(.1f);
        }
    }

    public override IEnumerator TakeDamage()
    {
        if (!immortal)
        {

            health -= enemy.enemyatk;
            //myRigidbody.AddForce (-transform.forward * 1000);
            if (!IsDead)
            {
                MyAnimator.SetTrigger("damage");
                immortal = true;

                StartCoroutine(IndicateImmortal());
                yield return new WaitForSeconds(immortalTime);

                immortal = false;
            }
        }

    }


    public override bool IsDead
    {
        get
        {
            if (health <= 0)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = true;
                exp = 0;
                MyAnimator.SetTrigger("die");
                OnDead();
                this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                myRigidbody.velocity = new Vector2(0 * 0, 1 * 1);
                spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
                // GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            return health <= 0;
        }
    }
    public void randomStats()
    {
        baseatk = 1;
        basedef = 1;
        basehealth = 3;
        while (baseatk + basedef + basehealth < 8)
        {
            int choice = Random.Range(0, 3); //random entre 0 e 3
            switch (choice)
            {
                case 0:
                    if (baseatk < 3)
                        baseatk++;
                    break;
                case 1:
                    if (basedef < 3)
                        basedef++;
                    break;
                default:
                case 2:
                    if (basehealth < 5)
                        basehealth++;
                    break;

            }
        }
    }


    public void levelup()
    {
        if (exp >= maxexp)
        {
            exp -= maxexp;
            atk += 1;
            def += 1;
            health += 1;
            maxhealth += 1;
            MyAnimator.SetTrigger("levelup");
            skillpoint += 1;
            level += 1;
			maxexp += maxexp / 10;
        }

    }

    public void killPlayer()
    {
        health = 0;
    }
}
