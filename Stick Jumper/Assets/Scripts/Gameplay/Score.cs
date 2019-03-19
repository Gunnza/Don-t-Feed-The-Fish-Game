using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
    //Score Variables
	public static int score = 0;
	public static float highScoreFloat;
	public static bool highScoreOn;
	public static float shellsCollected = 0;
	
	public GameObject highScore;
	public GameObject shellScore;

	// Use this for initialization
	//score = ES2.Load<float>("savefile.txt?tag=score");
	
	
	void Start() {

        //load the highscore 
		highScoreFloat = ES2.Load<float>("savefile.txt?tag=highScore");

        //load the number of shells collected
		shellsCollected = ES2.Load<float>("savefile.txt?tag=shellsCollected");

	}
	// Update is called once per frame
	void Update () {
		
		if(highScoreOn == true)
		{
			highScore.SetActive(true);
			highScore.GetComponent<GUIText>().text = "HighScore: " + highScoreFloat.ToString();
		}
		else
			highScore.SetActive(false);
		
		
		shellScore.GetComponent<GUIText>().text =  shellsCollected.ToString();
		GetComponent<GUIText>().text = score.ToString();
	
	}
}
