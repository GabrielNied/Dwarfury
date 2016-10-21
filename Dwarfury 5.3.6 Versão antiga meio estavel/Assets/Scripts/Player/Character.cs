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
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        
    }

	public void MeleeAttack(){
		WeaponCollider.enabled = true;
	}

	public virtual void OnTriggerEnter2D(Collider2D other){
        if (damageSources.Contains(other.tag))
        {
            if (!IsDead)
            {
                StartCoroutine(TakeDamage());
            }
        }
        if (other.tag == "Escada")
        {
            subir = true;
            descer = true;
        }

        if (other.tag == "Bau")
        {
            abrir = true;
        }
    }
    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Escada")
        {
            subir = false;
            descer = true;
        }
    }
}
