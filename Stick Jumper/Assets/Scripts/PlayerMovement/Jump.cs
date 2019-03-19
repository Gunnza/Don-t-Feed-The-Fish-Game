using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	
	float maxSpeed = 10f;
	bool clicked = false;
	
	bool moveRight = false;
	bool moveLeft = true;
	
	public float upSpeed = 500;
	public static float rightSpeed = 80;
	public static float leftSpeed = 80;
	
	

	Rigidbody2D rb;
	
	void Start()
	{
		rightSpeed = 150;
		leftSpeed = 150;
		Time.timeScale = 0;
	rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
						
	  foreach (Touch touch in Input.touches)		
	{
			//if(transform.position.x >= 3.3)
				// transform.position = new Vector3(2.9f, transform.position.y, transform.position.z);
	
	if (Time.timeScale<=1)
		Time.timeScale = 1;		
			
	if (clicked == false)
	{
		if (touch.phase == TouchPhase.Began)
		{
				if(moveLeft == true)
				{
					rb.AddForce(Vector3.up * upSpeed);
					rb.AddForce(Vector3.left * leftSpeed);
					clicked = true; 	
				}
			    if(moveRight == true)
				{
					rb.AddForce(Vector3.up * upSpeed);
					rb.AddForce(Vector3.right * rightSpeed);
					clicked = true; 	
				}
					
		}			
	 }
				
		if (touch.phase == TouchPhase.Ended)
		{
			clicked = false;
		}
	}
		
}
	
	void OnTriggerEnter2D (Collider2D myTrigger) {
		
		if(myTrigger.gameObject.tag == ("LeftWall"))
			{
				rb.AddForce(Vector3.right * rightSpeed);
				moveLeft = false;
				moveRight = true;
			}
		if(myTrigger.gameObject.tag == ("RightWall"))
			{
			rb.AddForce(Vector3.left * leftSpeed);
				moveLeft = true;
				moveRight = false;
			}
		if(myTrigger.gameObject.tag == ("TopWall"))
			{
			rb.AddForce(Vector3.down * upSpeed);	
			}
		if(myTrigger.gameObject.tag == ("BottomWall"))
			{
			rb.AddForce(Vector3.up * upSpeed);
			}
		
		if(myTrigger.gameObject.tag == ("Circle"))
			{
			 Score.score = 0;
			 Application.LoadLevel("Prototype");
			}
		
		
		
		
	}
	

	
	void FixedUpdate() {
		
			
		if (rb.velocity.magnitude > maxSpeed)	
		{
			 rb.velocity = rb.velocity.normalized * maxSpeed;
		}
			
	}
}

	

