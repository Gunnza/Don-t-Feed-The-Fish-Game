using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class JumpHard : MonoBehaviour {
	
	//Floats 
	float maxSpeed = 10f;
	public float upSpeed = 500;
	public static float rightSpeed = 80;
	public static float leftSpeed = 80;
	float deaths = 0; //Number of deaths racked up
	float time; // Time played
	
	
	//Booleans
	bool clicked = false;
	bool moveRight = false;
	bool moveLeft = true;
	bool playNormal = false;
	
	//Gameobjects
	public GameObject playerSprite;
	public GameObject font1, font2;
	public GameObject setBirdType, setCredits;
	public GameObject Shell;
	public GameObject touchStart;
	
	//Components
	Animator otherAnimator;
	SpawnShell spawnShell;
	Rigidbody2D rb;
	
	//Audio
	AudioSource audio;
	public AudioClip swim;
	public AudioClip collected;
	
	void Start()
	{
		//Boolean
		playNormal = false;
		
		//Initializing components
		spawnShell = Shell.GetComponent<SpawnShell>();
		otherAnimator = playerSprite.GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();
		
		//Setting speeds 
		rightSpeed = 150;
		leftSpeed = 150;
		//Time.timeScale = 0;
		
		//Turn gravity to zero on start so game wont play 
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
		
		//Activating UI
		font1.SetActive(true);
		font2.SetActive(true);
		setBirdType.SetActive(true);
		Score.highScoreOn = true;
	}

	
	public void TouchedStart() //When user presses UI button this method is called 
	{
		audio.PlayOneShot(swim, 0.7F); // Play jump audio 
		playNormal = true; // Boolean to decide if UI should dissappear and game should start 
		touchStart.SetActive(false); //disable the UI 
		//rb.AddForce(Vector3.up * upSpeed); //Add force of the Jump 
		//rb.AddForce(Vector3.left * leftSpeed);
	}
	
	
	
	/*Touch Option 
	void Update () 	
	{	
	   time += Time.deltaTime; //Counting the time played
		
	  foreach (Touch touch in Input.touches)		
	{
			//if(transform.position.x >= 3.3)
				// transform.position = new Vector3(2.9f, transform.position.y, transform.position.z);
	
	if(playNormal == true)
	{
			
		if (Time.timeScale<=1)
		Time.timeScale = 1;	
		
		//Disabling the UI 
		font1.SetActive(false);
		font2.SetActive(false);
		setBirdType.SetActive(false);
		setCredits.SetActive(false);
		Score.highScoreOn = false;
		rb.gravityScale = 3;
			
	if (clicked == false)//boolean used so user can't hold on the jump button 
	{
		if (touch.phase == TouchPhase.Began)
		{
				audio.PlayOneShot(swim, 0.7F);// Play jump audio once
				if(moveLeft == true)
				{
					//Jump left
					rb.AddForce(Vector3.up * upSpeed);
					rb.AddForce(Vector3.left * leftSpeed);
					clicked = true; 	
				}
			    if(moveRight == true)
				{
					//Jump right		
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
}
	*/

	
	// Mouse Option 
	void Update () 	
	{	
	   time += Time.deltaTime; //Counting the time played
		
	   if (Input.GetMouseButtonDown(0))			
	{
			//if(transform.position.x >= 3.3)
				// transform.position = new Vector3(2.9f, transform.position.y, transform.position.z);
	
	if(playNormal == true)
	{
			
		if (Time.timeScale<=1)
		Time.timeScale = 1;	
		
		//Disabling the UI 
		font1.SetActive(false);
		font2.SetActive(false);
		setBirdType.SetActive(false);
		setCredits.SetActive(false);
		Score.highScoreOn = false;
		rb.gravityScale = 3;
			
	//if (clicked == false)//boolean used so user can't hold on the jump button 
	//{
				audio.PlayOneShot(swim, 0.7F);// Play jump audio once
				if(moveLeft == true)
				{
					//Jump left
					rb.AddForce(Vector3.up * upSpeed);
					rb.AddForce(Vector3.left * leftSpeed);
					//clicked = true; 	
				}
			    if(moveRight == true)
				{
					//Jump right		
					rb.AddForce(Vector3.up * upSpeed);
					rb.AddForce(Vector3.right * rightSpeed);
					//clicked = true; 	
				}		
	//}			
			//clicked = false;
	}
  }
}

	void OnTriggerEnter2D (Collider2D myTrigger) {
		
		if(myTrigger.gameObject.tag == ("LeftWall")) //If touch left wall direction of player is changed to right 
			{
				otherAnimator.CrossFade("BirdRight", 0f);
				rb.AddForce(Vector3.right * rightSpeed);
				moveLeft = false;
				moveRight = true;
			}
		if(myTrigger.gameObject.tag == ("RightWall")) //If touch right wall direction of player is changed to left 
			{
				otherAnimator.CrossFade("BirdLeft", 0f);
				rb.AddForce(Vector3.left * leftSpeed);
				moveLeft = true;
				moveRight = false;
			}
		if(myTrigger.gameObject.tag == ("TopWall")) //Will bounce off top and bottom wall with the add force 
			{
			rb.AddForce(Vector3.down * upSpeed);	
			}
		if(myTrigger.gameObject.tag == ("BottomWall"))
			{
			rb.AddForce(Vector3.up * upSpeed);
			}
		
		if(myTrigger.gameObject.tag == ("Circle")) //If player hits enemy or spikes 
			{
			// showAds.ShowAd(); // calls add counter
			 Score.score = 0; // reset score
			
			 deaths++;
			 Analytics.CustomEvent("Deaths and Time", new Dictionary<string, object>
 					 {
						 { "Number of Deaths", deaths },
						 {"Time played", time}
					 });
			
			 Application.LoadLevel("PrototypeHard"); //start level again 
			}	
		
		if(myTrigger.gameObject.tag == ("Shell")) //Coollect Shell 
			{
				SpawnShell.shellBox.enabled = false;	
				SpawnShell.sr.sprite = null;
				Score.shellsCollected += 10;
				ES2.Save(Score.shellsCollected,  "savefile.txt?tag=shellsCollected");
				audio.PlayOneShot(collected, 0.7F);
				spawnShell.changeShell(); //Call new shell method 
			}		
	}
	void FixedUpdate() {
				
	if (rb.velocity.magnitude > maxSpeed)	
		{
			 rb.velocity = rb.velocity.normalized * maxSpeed;
		}
			
	}
}

	

