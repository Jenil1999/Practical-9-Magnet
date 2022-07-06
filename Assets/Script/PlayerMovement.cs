using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] Animator anim;
	[SerializeField] AudioClip DieSound;
	[Header("Running")]
	float horizontal,vertical;
    [SerializeField] float MovementSpeed = 5f;
	private bool facingRight = true;
	BoxCollider2D MyFeetCollider;
	CapsuleCollider2D MyBodyCollider2D;
	//public AudioSource Audio;
	[SerializeField] Vector2 DeathJump = new Vector2(10f, 10f);
	[SerializeField] float RollSpeed = 30f;
	

	public ParticleSystem JumpEffect;
	public ParticleSystem FlipEffect;
	public ParticleSystem RunEffect;

	//float GravityScaleatStart;
	

	bool IsAlive = true;

	[SerializeField] private float jumpForce = 300f;

	Rigidbody2D rb;

	private void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
		MyFeetCollider = GetComponent<BoxCollider2D>();
		//GravityScaleatStart = rb.gravityScale;
		MyBodyCollider2D = GetComponent<CapsuleCollider2D>();
	}
    private void Update()
    {
			 horizontal = Input.GetAxis("Horizontal");
			 vertical = Input.GetAxis("Vertical");	
			OnRun();
			OnJump();
			OnRoll();
			Die();
	}
    private void OnRun()
    {
		if (IsAlive)
		{
			anim.SetFloat("Running", Mathf.Abs(horizontal));


			rb.velocity = new Vector2(horizontal * MovementSpeed, rb.velocity.y);

			if (MyFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && horizontal < 0 || horizontal > 0)
			{ RunEffect.Play(); }

            if (horizontal > 0 && !facingRight)
            {	
				Flip();
			}

            else if (horizontal < 0 && facingRight)
            {
				Flip();
              
            }
        }
		
	}

    private void Flip()

    {
		facingRight = !facingRight;
		
		transform.Rotate(0, 180, 0);
		if (MyFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
		{ FlipPartEffect(); }
		
	}

    private void OnRoll()
    {
		if(IsAlive)
        {
			if (Input.GetKeyDown(KeyCode.LeftControl))
			{ 
				if (!MyFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
				{ return; }
				anim.SetBool("Roll", true);
				rb.velocity = new Vector2(horizontal * RollSpeed, rb.velocity.y);
			}
			else
			{
				anim.SetBool("Roll", false);
			}
		}
	
	}

    private void OnJump()
    {
		if(IsAlive)
        {
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (!MyFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "Climb")))
				{ return; }

					anim.SetBool("Jump", true);
					rb.AddForce(new Vector2(0, jumpForce));
					JumpEffect.Play();
			}
			else
			{
				anim.SetBool("Jump", false);
				rb.AddForce(new Vector2(0, 0));
			}
		}
		
	}
	void Die()
	{
		if (MyBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Hezards")))
		{
			IsAlive = false;
			rb.velocity = DeathJump;
			anim.SetTrigger("Die");
			//Audio.mute = true;
			AudioSource.PlayClipAtPoint(DieSound, Camera.main.transform.position , 0.1f);
		}
	}
    public void DestroyMe()
    {
		Destroy(gameObject);
		
	}

	void FlipPartEffect()
    {
		FlipEffect.Play();
	}

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }


}
