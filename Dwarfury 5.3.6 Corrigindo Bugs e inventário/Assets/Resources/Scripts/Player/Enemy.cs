using UnityEngine;
using System.Collections;

public class Enemy : Character {
    private Player player;
	private FloatingTextController ftc;
    private IEnemyState currentState;

    public GameObject Target { get; set; }
	[SerializeField]
	private float meleeRange;

    [SerializeField]
    private Transform leftEdge;
    [SerializeField]
    private Transform rightEdge;

    private BoxCollider2D boxCollider2D;
    private EdgeCollider2D edgeCollider2D;

    private Rigidbody2D myRigidbody;

    public int enemyhealth = 10;
    public int enemyatk = 1;
    int enemydef = 0;
    public bool InMeleeRange{
		get{
			if (Target != null) {
				return Vector2.Distance (transform.position, Target.transform.position) <= meleeRange;
			}
			return false;
		}
	}

	// Use this for initialization
	public override void Start () {
        FloatingTextController.Initialize();
        player = FindObjectOfType<Player>();
       // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		base.Start ();

        edgeCollider2D = GetComponent<EdgeCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        Player.Instance.Dead += new DeadEventHandler(RemoveTarget);
		ChangeState (new IdleState ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!IsDead){
			if (!TakingDamage) {
				currentState.Execute ();
			}

		LookAtTarget ();

		}
	}

    public void RemoveTarget()
    {
        Target = null;
        if (currentState != null)
        {
            currentState.Exit();
        }
        
        currentState.Enter(this);
    }

    private void LookAtTarget()
    {
        if (Target != null)
        {

            float xDir = Target.transform.position.x - transform.position.x;
            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }

        }
    }

	public void ChangeState(IEnemyState newState){
		if (currentState != null) {
			currentState.Exit ();
		}

		currentState = newState;

		currentState.Enter (this);
	}

	public void Move(){
  /*      if (!Attack)
        {
            if ((GetDirection().x > 0 && transform.position.x < rightEdge.position.x) || (GetDirection().x < 0 && transform.position.x > leftEdge.position.x))
            {
                MyAnimator.SetFloat("speed", 1);
                transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
            }
            else if (currentState is PatrolState)
            {
                ChangeDirection();
            }

            if (InMeleeRange)
            {
*/
            if (!InMeleeRange)
        {
            MyAnimator.SetFloat("speed", 1);
            transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
        }
        else
        {
            MyAnimator.SetFloat("speed", 0);
            new Vector2(0, 0);
        }

}
        
    

	public Vector2 GetDirection(){
		return facingRight ? Vector2.right : Vector2.left;
	}

	public override void OnTriggerEnter2D(Collider2D other){
		base.OnTriggerEnter2D (other);
		currentState.OnTriggerEnter (other);

/*        if (other.CompareTag("Player"))
        {
            if (other.transform.position.x < transform.position.x)
            {
                StartCoroutine(player.Knockback(0.02f, 25, player.transform.position));
            }
            else
            {
                StartCoroutine(player.Knockback(0.02f, 25, -player.transform.position));
            }
       }

 */    }


    public override IEnumerator TakeDamage()
    {
        enemyhealth -= player.atk;

        if (!IsDead) {
			MyAnimator.SetTrigger ("damage");

		} else {
			MyAnimator.SetTrigger("die");
           // this.gameObject.tag = "Untagged";
            player.exp += 1;
			player.gold += Random.Range(1, 11);
            boxCollider2D.enabled = !boxCollider2D.enabled;
            //myRigidbody.velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            movementSpeed = 0;
            this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

            yield return null;
		}
	}

	public override bool IsDead{
		get{
			return enemyhealth <= 0;

        }
	}
  
}

