using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Vector3 scaleChange,positionChange;
    public GameObject Player;
    public GameObject floatingPoints;
    private int hits;
    public int maxHealth = 100;
    public int currentHealth, Damage;
    public KeyCode Left,Right,JumpButton,AttackKey,SpecialKey;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private bool WalKing;
    public float moveSpeed, RotateX, RotateY, RotateZ;
    public float JumpForce,knockback;
    private Animator anim;
    public HealthBar healthBar;
    public Player1 player1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Snow_Attack"))//spam prevention
                    {
                    return;
                    }
        if(currentHealth <= 0)
        {
            Dead();
        }
         Vector3 movement2 = new Vector3(Input.GetAxis("Horizontal2"), 0.0f);//, Input.GetAxis("Vertical"));
        
        transform.position += movement2 * Time.deltaTime * moveSpeed;
        
        if (Input.GetKeyDown(JumpButton))
        {
    
                Jump();  
        }
        if(Input.GetKeyDown(Left)||Input.GetKeyDown(Right))
        {    
                WalKing = true;
               StartCoroutine(Walking());
        }
        if(Input.GetKeyUp(Left)||Input.GetKeyUp(Right))
        {
            WalKing = false;
        }
        if(Input.GetKeyDown(AttackKey))
        {
            Swish();

        }
        Debug.Log(hits);
        
          if(Input.GetKeyDown(SpecialKey))
        {
            Special();
        }
    }

    void Walk()
    {
        anim.Play("Snow_Move");
    }

    void Jump()
    {
        anim.Play("Snow_Jump");
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0f, JumpForce), ForceMode.Impulse);
    }

    void Swish()
    {
        anim.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            player1.TakeDamage(7);
        }
    }

    void Idle()
    {
        anim.Play("Snow_Idle");
    }

    void Dead()
    {
        anim.Play("Snow_Dead");
    }

    IEnumerator Walking()
    {
        Player.transform.localScale += scaleChange;
        Player.transform.position += positionChange;
        transform.localRotation = Quaternion.Euler(RotateX, RotateY, RotateZ);

        while(WalKing == true)
        {
            anim.Play("Snow_Move");
            yield return null;
        }
    }

   public void TakeDamage(int damage)
    {
        Damage = damage;
        anim.Play("Snow_Stunned");
        GetComponent<Rigidbody>().AddRelativeForce(-Vector3.right * knockback);
        Instantiate(floatingPoints, transform.position, Quaternion.identity);//spawns damage
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
        void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

        public void Special()
    {
        anim.Play("SpecialSlug2");
    }
}