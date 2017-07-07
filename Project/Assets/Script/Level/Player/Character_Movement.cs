using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour {

    Rigidbody2D Player;

	private float jump;
	private bool canJump;


    public float moveSpeed;
	public static float jumpHeight;

    public float flySpeed;
    public float flyHeight;
    public int waitTimme;

    public float speedModifyer;

    int doublejump;
    bool isDoubleJumping;


    public static bool flying;
    public static bool running;

    private void Start()
    {
		jumpHeight = 350;
        Player = GetComponent<Rigidbody2D>();
        running = true;
        doublejump = PlayerPrefs.GetInt("DOUBLEJUMP", 0);
        if (doublejump == 1) isDoubleJumping = true;
        if (PlayerPrefs.GetInt("SPEED", 0) == 1) moveSpeed *= speedModifyer;
    }


    protected float OnMouseDown_()
	{

		if (Input.GetMouseButtonDown(0))
		{
			//if (CorpseButton.kill_button_pressed == false)
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
            jump = OnMouseDown_();
            canJump = false;

            //Debug.Log("canJump");
        }
        else if (isDoubleJumping)
        {
            //Debug.Log("isDoubleJumping");
            jump = OnMouseDown_();
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
		Player.AddForce(new Vector2(moveSpeed, (jumpHeight * jump)), ForceMode2D.Impulse);
    }
    IEnumerator Wait(int sec)
    {
        
        yield return new WaitForSeconds(sec);
    }

    void fly()
    {
        Debug.Log("Flying");
        Player.AddForce(new Vector2(0, flyHeight), ForceMode2D.Impulse);
        Wait(waitTimme);
        Player.AddForce(new Vector2(flySpeed, 0), ForceMode2D.Impulse);
        flying = false;
        running = true;
    }


	void FixedUpdate()
	{
        if(running)
            run();
        if(flying)
            fly();
        //Debug.Log(jump);
	}
}