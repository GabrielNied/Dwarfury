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
	public bool abriu = false;

    public virtual void Start() 
	{
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
    }

    void Update()
	{

    }

    public abstract IEnumerator TakeDamage();

    public void ChangeDirection()
    {
        facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * 1, transform.localScale.z * 1);
        
    }

	public void MeleeAttack()
	{
		WeaponCollider.enabled = true;
	}

	public virtual void OnTriggerEnter2D(Collider2D target)
	{
		if (damageSources.Contains (target.tag))
		{
			if (!IsDead)
			{
				
				StartCoroutine (TakeDamage ());

				//Debug.Log ("PlayerPos " + this.GetComponent<Player> ().transform.position.x);
				//Debug.Log ("EspinhosPos " + target.transform.position.x);
				//Debug.Log ("EspinhosLocalPos " + target.transform.localPosition.x);

				//Se o player está vindo da esquerda
				if (this.GetComponent<Player> ().transform.position.x >= target.transform.position.x)
				{	
					this.GetComponent<Player> ().myRigidbody.AddForce(transform.right * 1000);
				}
				//Se o player está vindo da direita
				if (this.GetComponent<Player> ().transform.position.x < target.transform.position.x)
				{	
					this.GetComponent<Player> ().myRigidbody.AddForce(-transform.right * 1000);
				}

			}
		}
        if (target.tag == "Escada")
        {
            subir = true;
            descer = true;
        }		      

		if (target.tag == "BauAberto")
		{
			abrir = false;	
			abriu = false;
		}
	}

	public virtual void OnTriggerStay2D(Collider2D target)
	{
		if (target.tag == "Escada") {
				subir = true;
				descer = true;
				MyAnimator.SetBool ("naEscada", true);
				this.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				this.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
			}

		if (target.tag == "BauAberto")
		{
			abrir = false;	
			abriu = false;
		}

		if (target.tag == "Bau")
		{
			abrir = true;

			if (abriu == true) {
				target.tag = "BauAberto";
			}
		}
	}

	public virtual void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Escada")
        {
			MyAnimator.SetBool ("naEscada", false);
            subir = false;
            descer = false;
			this.GetComponent<Rigidbody2D>().gravityScale = 2.0f;
        }

		if (target.tag == "Bau")
		{
			abrir = false;
		}
    }

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector2 knockbackDir)
	{
		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime;
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (knockbackDir.x * knockbackPwr, knockbackDir.y * knockbackPwr));
		}
		yield return 0;
	}
}