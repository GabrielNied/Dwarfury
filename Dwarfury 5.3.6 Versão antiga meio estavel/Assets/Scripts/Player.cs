using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public delegate void DeadEventHandler();

public class Player : Character {
    private Enemy enemy;
    private LevelLoader lvl;

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
    private Rigidbody2D myRigidbody;

    public event DeadEventHandler Dead;

    public DashState dashState;
    public float dashTimer;
    public float maxDash = 5f;
    public Vector2 savedVelocity;

    int knockDirection;

    public bool LevelingUp { get; set; }

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
    public int exp =0;
    public int maxexp = 10;

    private GUIStyle guiStyle = new GUIStyle();

    public override void Start () {
		if (Application.loadedLevel == 0) {
			randomStats ();
			PlayerPrefs.SetInt ("Vida", basehealth);
			PlayerPrefs.SetInt ("Atq", baseatk);
			PlayerPrefs.SetInt ("Def", basedef);
			health = basehealth;
			maxhealth = basehealth;
			atk = baseatk;
			def = basedef;
		}
        
		enemy = FindObjectOfType<Enemy>();
        base.Start ();

        spriteRenderer = GetComponent<SpriteRenderer>();
		myRigidbody = GetComponent<Rigidbody2D> ();
		//basehealth = PlayerPrefs.GetInt("Vida");
		//baseatk = PlayerPrefs.GetInt("Atq");
		//basedef = PlayerPrefs.GetInt("Def");

        exp = PlayerPrefs.GetInt("Exp");


    
	}
	void Awake(){
		health = PlayerPrefs.GetInt("Vida1");
		maxhealth = PlayerPrefs.GetInt("Vida2");
		atk = PlayerPrefs.GetInt("Atq1");
		def = PlayerPrefs.GetInt("Def1");
	}

	void Update(){
        recalculateStats();
        PlayerPrefs.SetInt("Exp", exp);



        if (!TakingDamage && !IsDead && !LevelingUp) {
			if (transform.position.y <= -14f) {
				myRigidbody.velocity = Vector2.zero;
			}
			HandleInput ();
		}
	}
		
	void FixedUpdate () {
		if (!TakingDamage && !IsDead && !LevelingUp) {
			float horizontal = Input.GetAxis ("Horizontal");
            levelup();

            isGrounded = IsGrounded ();

			HandleMovement (horizontal);
			HandleMovementEscada ();
			Flip (horizontal);

			HandleAttacks ();
		}
		ResetValues ();
	}

    public void OnDead()
    {
        if (Dead != null)
        {
            Dead();
        }
    }

    void OnGUI()
    {
		  
        GUI.Label(new Rect(20, 10, 200, 40), "<color=red><size=20> Vida = " + health + " / " + maxhealth + "</size></color>");
		GUI.Label(new Rect(600, 10, 200, 40), "<color=white><size=20> Ataque = " + atk + "</size></color>");
		GUI.Label(new Rect(600, 40, 200, 40), "<color=white><size=20> Defesa = " + def + "</size></color>");
        GUI.Label(new Rect(20, 40, 200, 40), "<color=green><size=20> EXP = " + exp + " / " + maxexp + "</size></color>");
    }


    private void HandleMovement(float horizontal)
	{
		//		if (!this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {                                     PARA MOVIMENTAÇÃO QUANDO ATACA

		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);


		MyAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
		//		}																											PARA MOVIMENTAÇÃO QUANDO ATACA

	
		if (pulando && jump2 && !isGrounded) {
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.y, jumpForce);
			pulando = false;
		
		} else {
			if (isGrounded && jump) {
				isGrounded = false;
				myRigidbody.AddForce (new Vector2 (0, jumpForce));
				pulando = true;
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

    private void HandleAttacks(){
//		if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {							 PARA MOVIMENTAÇÃO QUANDO ATACA
		if (attack && !this.MyAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
			MyAnimator.SetTrigger ("attack");
//			myRigidbody.velocity = Vector2.zero;																 PARA MOVIMENTAÇÃO QUANDO ATACA
		}
	}


	/*
	private void HandleMovementBau(){
		if (abrir == true) {
			if (Input.GetKey(KeyCode.E)) {

			}
		}
	}
	*/

	private void HandleMovementEscada()
	{
		
		if (subir == true) {
			if (Input.GetKey(KeyCode.W)) {
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 1 * movementSpeed / 2);
				//this.myRigidbody.gravityScale = 0.0f;
			}
		}

		if (descer == true) {
			if (Input.GetKey(KeyCode.S)) {
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -2 * movementSpeed / 2);
				//this.myRigidbody.gravityScale = 0.0f;
			}
		}
	}

	private void HandleInput(){
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			attack = true;
		}


		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			jump2 = true;
		}




//        if (Input.GetKeyDown(KeyCode.E))
//    {
//        isDashKeyDown = true;
//    }
	}

	private void Flip(float horizontal){
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			ChangeDirection ();
		}
	}

	private void ResetValues(){
		attack = false;
       // isDashKeyDown = false;
		jump = false;
		jump2 = false;
	}

	private bool IsGrounded(){
		if (myRigidbody.velocity.y <= 0) {
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						return true;
					}
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


	public override IEnumerator TakeDamage(){
        if (!immortal)
        {
            health -= enemy.enemyatk;

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
	

	public override bool IsDead{
		get{
            if (health <= 0) {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = true;
                exp = 0;
                MyAnimator.SetTrigger("die");
                OnDead();
                this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                myRigidbody.velocity = new Vector2(0 * 0, 1*1);
                spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
               // GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            return health <= 0;
		}
	}
    public void randomStats()
    {
        baseatk = 3;
        basedef = 3;
        basehealth = 5;
        while (baseatk + basedef + basehealth < 16)
        {
            int choice = Random.Range(0, 4); //random entre 0 e 3
            switch (choice)
            {
                case 0:
                    if (baseatk < 6)
                        baseatk++;
                    break;
                case 1:
                    if (basedef < 6)
                        basedef++;
                    break;
                default:
                case 2:
                    if (basehealth < 8)
                        basehealth++;
                    break;

            }
        }
    }

    public void recalculateStats()
    {
        //atk = baseatk;
       // def = basedef;

        
        //health = basehealth;

        // checar por mudança de estadus aqui ex:
        //if (UsandoAneldeAtaque+2) atk = atk + 2;

    }
    public void levelup()
    {
        if (exp >= maxexp)
        {
            exp = 0;
            atk += 1;
            def += 1;
            health += 1;
            maxhealth += 1;
            MyAnimator.SetTrigger("levelup");
        }

    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        float timer = 0;

        while (knockDur > timer)
        {

            timer += Time.deltaTime;

                myRigidbody.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

           
        }

        yield return 0;

    }

    public void killPlayer()
    {
        health = 0;
    }
}
