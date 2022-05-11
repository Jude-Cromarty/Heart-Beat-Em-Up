using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
public float speed;
	public float jumpForce;
	public float moveInput;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;
	public int extraJump;
	public int ejV;

	private bool isGrounded;
	private bool facingRight = true;
	private Rigidbody2D rb;

	void Start()
	{
		extraJump = ejV;
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
    {
		if (isGrounded == true)
        {
			extraJump = ejV;
        }

        if (Input.GetKey(KeyCode.Space) && extraJump > 0)
        {
			rb.velocity = Vector2.up * jumpForce;
			extraJump--;
        }else if (Input.GetKey(KeyCode.Space) && extraJump == 0 && isGrounded == true)
        {
			rb.velocity = Vector2.up * jumpForce;
		}
    }

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		if (facingRight == false && moveInput > 0)
        {
			Flip();
        }else if (facingRight == true && moveInput < 0)
        {
			Flip();
        }
	}

	void Flip()
    {
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
    }
}