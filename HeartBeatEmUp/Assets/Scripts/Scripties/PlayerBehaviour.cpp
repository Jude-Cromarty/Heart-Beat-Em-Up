using UnityEngine;


public class Monobehaviour : PlayerBehaviour
{

public float moveSpeed;//allows to set move speed in inspector
void awake()
{

}

void Start()
{

}

void Update()
{
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);//get direction of input 
    transform.position += movement * Time.deltaTime * moveSpeed; //apply force in direction 
    Jump();//calls jump class
}

public void Jump()
{
    if(Input.GetKeyDown("Space"))//if Space is pressed
    {
    gameObject.GetComponent<RigidBody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse); //apply force in vertical direction
    }
}

public void Attack()//public so can be called from other scipts(as long as this script is refrenced)
{
    anim.Play(Attack);//play animation Attack
}

public void AttackOff()
{
    anim.Play(AttackOff);//play animation AttackOff
}
}