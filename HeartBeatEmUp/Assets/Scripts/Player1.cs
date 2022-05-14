using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{   
     Rigidbody m_Rigidbody;
    public Vector3 scaleChange,positionChange,positionChange1;
    public GameObject Player;
    public GameObject floatingPoints;
    private int hits;
    public int maxHealth = 100;
    public int currentHealth, Damage;
    public KeyCode Left,Right,JumpButton,AttackKey,SpecialKey;
    public Transform AttackPoint,AttackPoint1;
    public float attackRange = 0.5f;
    public float attackRange1 = 0.5f;
    public LayerMask enemyLayers2;
    private bool WalKing;
    public float moveSpeed, RotateX, RotateY, RotateZ;
    public float JumpForce,knockback, AttackDelay;
    private Animator anim;
    public HealthBar healthBar;
    public Player2 player2;
    int AttackDamage =3;
    // Start is called before the first frame update

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //if spacebar is pressed swap controls,invert controls etc..(depends on MUSIC - makes it viable for jam)

    // Update is called once per frame
    void Update()
    {
        
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("CloseRangeSlug1"))
                    {
                    return;
                    }

        if(currentHealth <= 0)
        {
            Dead();
        }
         Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f);//, Input.GetAxis("Vertical"));
        
            transform.position += movement * Time.deltaTime * moveSpeed;

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

            StartCoroutine(Swish());

        }
        if(Input.GetKeyDown(SpecialKey))
        {
            StartCoroutine(Special());
        }
        Debug.Log(hits);
        
    }
    

    void Walk()
    {

        anim.Play("WalkSlug1");
    }

    void Jump()
    {
        anim.Play("JumpSlug1");
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0f, JumpForce), ForceMode.Impulse);
    }

    IEnumerator Swish()
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(AttackDelay);
        Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint.position, attackRange, enemyLayers2);
        foreach (Collider enemy in hitEnemies)
        {
            player2.TakeDamage(AttackDamage);
        }
    }

    void Idle()
    {
        anim.Play("IdleSlug1");
    }

    IEnumerator Walking()
    {
        Player.transform.localScale += scaleChange;
        Player.transform.position += positionChange;
        transform.localRotation = Quaternion.Euler(RotateX, RotateY, RotateZ);
        while(WalKing == true)
        {
            anim.Play("WalkSlug1");
            yield return null;
        }
    }

    public void TakeDamage(int damage)
    {
        Damage = damage;
        anim.Play("KnockbackSlug1");
        GetComponent<Rigidbody>().AddRelativeForce(-Vector3.right * knockback);
        Instantiate(floatingPoints, transform.position, Quaternion.identity);//spawns damage
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
          Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPoint1.position, attackRange1);
    }

    void Dead()
    {
        anim.Play("DeadSlug1");
    }

    IEnumerator Special()
    {
        Player.transform.position += positionChange1;
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        anim.Play("SpecialSlug1");
        yield return new WaitForSeconds(1.2f);
        m_Rigidbody.constraints = RigidbodyConstraints.None;
        Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint1.position, attackRange1, enemyLayers2);
        foreach (Collider enemy in hitEnemies)
        {player2.TakeDamage(10);}
    }

       void OnCollisionEnter (Collision targetObj) {
if(targetObj.gameObject.tag == "Trap")
        {
            Debug.Log("TakenCollider");
        }
    }
}

