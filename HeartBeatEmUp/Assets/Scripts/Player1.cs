using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private int hits;
    public int maxHealth = 100;
    public int currentHealth;
    public KeyCode Left,Right,JumpButton,AttackKey;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers2;
    private bool WalKing;
    public float moveSpeed;
    public float JumpForce,knockback;
    private Animator anim;
    public HealthBar healthBar;
    public Player2 player2;
    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    //if spacebar is pressed swap controls,invert controls etc..(depends on MUSIC - makes it viable for jam)

    // Update is called once per frame
    void Update()
    {
        
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
            Swish();

        }
        Debug.Log(hits);
        
        
    }

    void Walk()
    {
        anim.Play("Duckwalk");
    }

    void Jump()
    {
        anim.Play("Jump");
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0f, JumpForce), ForceMode.Impulse);
    }

    void Swish()
    {
        anim.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint.position, attackRange, enemyLayers2);
        foreach (Collider enemy in hitEnemies)
        {
            player2.TakeDamage(10);
        }
    }

    void Idle()
    {
        anim.Play("IdleDucks");
    }

    IEnumerator Walking()
    {

        while(WalKing == true)
        {
            anim.Play("Duckwalk");
            yield return null;
        }
    }

    public void TakeDamage(int damage)
    {
        GetComponent<Rigidbody>().AddRelativeForce(-Vector3.right * knockback);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

    
    
}

