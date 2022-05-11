using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorplay : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public KeyCode Left,Right,JumpButton,AttackKey;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private bool WalKing;
    public float moveSpeed;
    public float JumpForce;
    private Animator anim;
    public HealthBar healthBar;
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
        
         Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        
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
        Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            TakeDamage(10);
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

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
