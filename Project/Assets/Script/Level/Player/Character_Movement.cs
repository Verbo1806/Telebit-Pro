using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour {
	
	private float jump;
	private bool canJump;
	public float moveSpeed;
	public float jumpHeight;
    int doublejump;
    bool isDoubleJumping;
    private void Start()
    {
        doublejump = PlayerPrefs.GetInt("DOUBLEJUMP", 0);
        if (doublejump == 1) isDoubleJumping = true;
    }
    // Update is called once per frame
    protected float OnMouseDown()
	{
		if (Input.GetMouseButtonDown(0))
		{
			return (float)1;
		}
		return (float)0;
	}
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.collider.tag == "Floor") {
            canJump = true;
            if(doublejump == 1) isDoubleJumping = true;
        }
	}
    void Jump()
    {
        if (canJump == true)
        {
            jump = OnMouseDown();
            canJump = false;

            Debug.Log("canJump");
        }
        else if (isDoubleJumping)
        {
            Debug.Log("isDoubleJumping");
            jump = OnMouseDown();
            if (jump == (float)1)
            {
                isDoubleJumping = false;
                jump = (float)0.8;
            }
        }
        else jump = 0;
        
    }
    void run()
    {
        Jump();
        Debug.Log("Run");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed, jumpHeight * jump), ForceMode2D.Impulse);
    }
	void FixedUpdate()
	{
        run();
        Debug.Log(jump);
	}
}