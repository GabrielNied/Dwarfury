﻿using UnityEngine;
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

				Debug.Log ("PlayerPos " + this.GetComponent<Player> ().transform.position.x);
				Debug.Log ("EspinhosPos " + target.transform.position.x);

				//Se o player está vindo da esquerda
				if (this.GetComponent<Player> ().transform.position.x > target.transform.position.x)
				{	
					this.GetComponent<Player> ().StartCoroutine (Knockback (4f, 1, transform.position));
				}
				//Se o player está vindo da direita
				if (this.GetComponent<Player> ().transform.position.x < target.transform.position.x)
				{	
					this.GetComponent<Player> ().StartCoroutine (Knockback (4f, -1, transform.position));
				}
			}
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

	public virtual void OnTriggerStay2D(Collider2D target)
	{
		if (target.tag == "Escada")
		{
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		}
	}

	public virtual void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Escada")
        {
            subir = false;
            descer = false;
			this.GetComponent<Rigidbody2D>().gravityScale = 2.0f;
        }
    }

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector2 knockbackDir)
	{
		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime;
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (knockbackDir.x * knockbackPwr, knockbackDir.y * knockbackPwr/4));
		}
		yield return 0;
	}
}
