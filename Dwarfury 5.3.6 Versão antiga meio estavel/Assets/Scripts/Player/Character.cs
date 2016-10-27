using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {
    
    [SerializeField]
    protected float movementSpeed;

    [SerializeField]
    private EdgeCollider2D weaponCollider;

    [SerializeField]
    private List<string> damageSources;

    public abstract bool IsDead { get; }

    public bool Attack { get; set; }

    public bool TakingDamage { get; set; }

    public Animator MyAnimator { get; private set; }

    public EdgeCollider2D WeaponCollider {
        get {
            return weaponCollider;
        }
    }

    protected bool facingRight;

    public bool subir = false;
    public bool descer = false;

    public bool abrir = false;
    // Use this for initialization
    public virtual void Start() {

        facingRight = true;
        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {


    }

    public abstract IEnumerator TakeDamage();

    public void ChangeDirection()
    {
        facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * 1, transform.localScale.z * 1);
        
    }

	public void MeleeAttack(){
		WeaponCollider.enabled = true;
	}

	public virtual void OnTriggerEnter2D(Collider2D target){
        if (damageSources.Contains(target.tag))
        {
            if (!IsDead)
            {
                StartCoroutine(TakeDamage());
            }
        }
		if (target.tag == "Espinhos") {
			this.GetComponent<Player>().health -= 1;
			this.GetComponent<Player>().StartCoroutine(Knockback(0.1f, 5, transform.position));

		}
        if (target.tag == "Escada")
        {
            subir = true;
            descer = true;
        }

        if (target.tag == "Bau")
        {
            abrir = true;
        }
    }

	void OnTriggerStay2D(Collider2D target){
		if (target.tag == "Escada")
		{
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		}
	}
    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Escada")
        {
            subir = false;
            descer = false;
			this.GetComponent<Rigidbody2D>().gravityScale = 2.0f;
        }
    }
	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
	{

		float timer = 0;

		while (knockDur > timer)
		{

			timer += Time.deltaTime;

			this.GetComponent<Rigidbody2D>().AddForce(new Vector3(knockbackDir.x * knockbackPwr , knockbackDir.y * knockbackPwr, transform.position.z));


		}

		yield return 0;

	}
}
