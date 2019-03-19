using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Analytics;

public class Circled1 : MonoBehaviour {
	
	//Booleans
	public bool halfCircle = false;
	
	//Audio 
	AudioSource audio;
	public AudioClip circleNoise;
	
	void Start()
	{
		audio = GetComponent<AudioSource>(); // Getting the audio component
	}

	void OnTriggerEnter2D (Collider2D myTrigger) {
		
		if(myTrigger.gameObject.tag == ("HalfCircle"))
			{
				if( halfCircle == true) //If the top trigger(HalfCircle) has been hit, to complete the circle the next trigger to be hit must be the full circle
					halfCircle = false;
				else if (halfCircle == false)
						 halfCircle = true;
			}
		
		if(myTrigger.gameObject.tag == ("FullCircle"))
			{
				if( halfCircle == true) //Completed a full circle
				{
					halfCircle = false; // Reseting circle
					audio.PlayOneShot(circleNoise, 0.7F); // Play circle noise 

					Score.score +=1; // Add one to score on score script
				if (Score.score >= Score.highScoreFloat) //Updates Highscore if score is higher
					Score.highScoreFloat = Score.score;

					ES2.Save(Score.highScoreFloat,  "savefile.txt?tag=highScore");//Save Highscore to Savefile
				
					 Analytics.CustomEvent("NewHighScore", new Dictionary<string, object>
 					 {
						 { "User Set a new personal HighScore", Score.highScoreFloat } //Analytic to show the high scores of players 
					 });
				}
			}					
		}
}
