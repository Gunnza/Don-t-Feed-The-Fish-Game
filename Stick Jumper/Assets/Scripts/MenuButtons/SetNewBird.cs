using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;


//inefficient way to change the color of the bird on menu select 
public class SetNewBird : MonoBehaviour {

	public GameObject player;
	public GameObject setPlayer;
	public GameObject button, creditsButton;
	public  AnimatorOverrideController blue;
	public  AnimatorOverrideController electro;
	public  AnimatorOverrideController red;
	public  AnimatorOverrideController marble;
	public  AnimatorOverrideController yellow;
	public  AnimatorOverrideController green;
	
	public static bool haveYellow = false;
	public static bool haveRed = false;
	public static bool haveGreen = false;
	public static bool haveMarble = false;
	public static bool haveElectro = false;
	
	static bool isYellow = false;
	static bool isBlue = false;
	static bool isRed = false;
	static bool isGreen = false;
	static bool isElectro = false;
	static bool isMarble = false;
	
	//Number for analytics
	float blueNumber;
	float redNumber;
	float yellowNumber;
	float electroNumber;
	float marbleNumber;
	float greenNumber;
	
	public Sprite selectedSprite;
	public GameObject touchStart;
	public GameObject Insufficient;
	public GameObject thePlayer;
	JumpHard jumpHard;	
	
	Animator animator;
	
	public void Start()
	{
		animator = player.GetComponent<Animator>();
		jumpHard = thePlayer.GetComponent<JumpHard>();	
		
		//Load Colour
		isYellow = ES2.Load<bool>("savefile.txt?tag=isYellow");
		isBlue = ES2.Load<bool>("savefile.txt?tag=isBlue");
		isRed = ES2.Load<bool>("savefile.txt?tag=isRed");
		isGreen = ES2.Load<bool>("savefile.txt?tag=isGreen");
		isMarble = ES2.Load<bool>("savefile.txt?tag=isMarble");
		isElectro = ES2.Load<bool>("savefile.txt?tag=isElectro");
		
		if(isYellow)
		{
			animator.runtimeAnimatorController = yellow;	
		}
		if(isBlue)
		{
			animator.runtimeAnimatorController = blue;
		}	
		if(isRed)
		{
			animator.runtimeAnimatorController = red;
		}	
		if(isGreen)
		{
			animator.runtimeAnimatorController = green;
		}	
		if(isMarble)
		{
			animator.runtimeAnimatorController = marble;
		}	
		if(isElectro)
		{
			animator.runtimeAnimatorController = electro;
		}	
		
		
	}
	
	//tell user they dont have enough shells 
	IEnumerator InsufficientShells()
	{
		Insufficient.SetActive(true);
		yield return new WaitForSeconds(1);
		Insufficient.SetActive(false);
	}
	
	public void setBlue()
	{
	    animator.runtimeAnimatorController = blue;
		
		//Set all others to false
		isYellow = false;
		isBlue = true;
		isRed = false;
		isGreen = false;
		isElectro = false;
		isMarble = false;
		
		blueNumber ++;
		 Analytics.CustomEvent("Blue", new Dictionary<string, object>
 					 {
						 { "How many times blue has been selected", blueNumber }
					 });
		
		//Save Colour
		ES2.Save(isYellow = false,  "savefile.txt?tag=isYellow");
		ES2.Save(isBlue = true,  "savefile.txt?tag=isBlue");
		ES2.Save(isRed = false,  "savefile.txt?tag=isRed");
		ES2.Save(isGreen = false,  "savefile.txt?tag=isGreen");
		ES2.Save(isElectro = false,  "savefile.txt?tag=isElectro");
		ES2.Save(isMarble = false,  "savefile.txt?tag=isMarble");
		
		//UI off
		setPlayer.SetActive(false);
		button.SetActive(true);
		jumpHard.enabled = true;
		touchStart.SetActive(true);
	}
	
	public void setRed(Image myImageToUpdate)
	{
		//If player has correct amount of soft currecny 
		if (Score.shellsCollected >= 200 && haveRed == false)
		{
			haveRed = true;
			ES2.Save(haveRed,  "savefile.txt?tag=haveRed");
			Score.shellsCollected -= 200;
			
			redNumber++;
		 	Analytics.CustomEvent("Red", new Dictionary<string, object>
 					 {
						 { "How many times red has been selected", redNumber }
					 });
		}
		if (haveRed == true)
		{
			myImageToUpdate.sprite = selectedSprite;
		 	animator.runtimeAnimatorController = red;
			isYellow = false;
			isBlue = false;
			isRed = true;
			isGreen = false;
			isElectro = false;
			isMarble = false;
			
			ES2.Save(isYellow = false,  "savefile.txt?tag=isYellow");
			ES2.Save(isBlue = false,  "savefile.txt?tag=isBlue");
			ES2.Save(isRed = true,  "savefile.txt?tag=isRed");
			ES2.Save(isGreen = false,  "savefile.txt?tag=isGreen");
			ES2.Save(isElectro = false,  "savefile.txt?tag=isElectro");
			ES2.Save(isMarble = false,  "savefile.txt?tag=isMarble");
		
			
			setPlayer.SetActive(false);	
			button.SetActive(true);
			jumpHard.enabled = true;
			touchStart.SetActive(true);
		}
		else
		{
			StartCoroutine(InsufficientShells());
		}
	}
	public void setYellow(Image myImageToUpdate)
	{
		if (Score.shellsCollected >= 200 && haveYellow == false)
		{
			haveYellow = true;
			ES2.Save(haveYellow,  "savefile.txt?tag=haveYellow");
			Score.shellsCollected -= 200;
			
			yellowNumber++;
		 	Analytics.CustomEvent("Yellow", new Dictionary<string, object>
 					 {
						 { "How many times yellow has been selected", yellowNumber }
					 });
		}
		if (haveYellow == true)
		{
			myImageToUpdate.sprite = selectedSprite;
 			animator.runtimeAnimatorController = yellow;
			isYellow = true;
			isBlue = false;
			isRed = false;
			isGreen = false;
			isElectro = false;
			isMarble = false;
			
			ES2.Save(isYellow = true,  "savefile.txt?tag=isYellow");
			ES2.Save(isBlue = false,  "savefile.txt?tag=isBlue");
			ES2.Save(isRed = false,  "savefile.txt?tag=isRed");
			ES2.Save(isGreen = false,  "savefile.txt?tag=isGreen");
			ES2.Save(isElectro = false,  "savefile.txt?tag=isElectro");
			ES2.Save(isMarble = false,  "savefile.txt?tag=isMarble");
			
			
			setPlayer.SetActive(false);
			button.SetActive(true);
			jumpHard.enabled = true;
			touchStart.SetActive(true);
		}
		else
		{
			StartCoroutine(InsufficientShells());
		}
	}
	public void setMarble(Image myImageToUpdate)
	{
		if (Score.shellsCollected >= 400 && haveMarble == false)
		{
			haveMarble= true;
			ES2.Save(haveMarble,  "savefile.txt?tag=haveMarble");
			Score.shellsCollected -= 400;
			
			marbleNumber++;
			 Analytics.CustomEvent("Marble", new Dictionary<string, object>
 					 {
						 { "How many times marble has been selected", marbleNumber }
					 });
		}
		if (haveMarble == true)
		{
			myImageToUpdate.sprite = selectedSprite;
		    animator.runtimeAnimatorController = marble; 
			isYellow = false;
			isBlue = false;
			isRed = false;
			isGreen = false;
			isElectro = false;
			isMarble = true;
			
			ES2.Save(isYellow = false,  "savefile.txt?tag=isYellow");
			ES2.Save(isBlue = false,  "savefile.txt?tag=isBlue");
			ES2.Save(isRed = false,  "savefile.txt?tag=isRed");
			ES2.Save(isGreen = false,  "savefile.txt?tag=isGreen");
			ES2.Save(isElectro = false,  "savefile.txt?tag=isElectro");
			ES2.Save(isMarble = true,  "savefile.txt?tag=isMarble");
			
			setPlayer.SetActive(false);
			button.SetActive(true);
			jumpHard.enabled = true;	
			touchStart.SetActive(true);
		}
		else
		{
			StartCoroutine(InsufficientShells());
		}
	}
	public void setElectro(Image myImageToUpdate)
	{
		if (Score.shellsCollected >= 500 && haveElectro == false)
		{
			haveElectro= true; //for the button to know it is bought
			ES2.Save(haveElectro,  "savefile.txt?tag=haveElectro");
			Score.shellsCollected -= 500;
			
			electroNumber++;
			 Analytics.CustomEvent("Electro", new Dictionary<string, object>
 					 {
						 { "How many times electro has been selected", electroNumber }
					 });
		}
		if (haveElectro == true)
		{	
			myImageToUpdate.sprite = selectedSprite;
		 	animator.runtimeAnimatorController = electro;
			isYellow = false;
			isBlue = false;
			isRed = false;
			isGreen = false;
			isElectro = true;
			isMarble = false;
			
			ES2.Save(isYellow = false,  "savefile.txt?tag=isYellow");
			ES2.Save(isBlue = false,  "savefile.txt?tag=isBlue");
			ES2.Save(isRed = false,  "savefile.txt?tag=isRed");
			ES2.Save(isGreen = false,  "savefile.txt?tag=isGreen");
			ES2.Save(isElectro = true,  "savefile.txt?tag=isElectro");
			ES2.Save(isMarble = false,  "savefile.txt?tag=isMarble");
			
			
			
			setPlayer.SetActive(false);
			button.SetActive(true);
			jumpHard.enabled = true;	
			touchStart.SetActive(true);
		}
		else
		{
			StartCoroutine(InsufficientShells());
		}
}
	public void setGreen(Image myImageToUpdate)
	{
		if (Score.shellsCollected >= 200 && haveGreen == false)
		{
			haveGreen= true; //for the button to know it is bought
			ES2.Save(haveGreen,  "savefile.txt?tag=haveGreen");
			Score.shellsCollected -= 200;
			
			greenNumber++;
			 Analytics.CustomEvent("Green", new Dictionary<string, object>
 					 {
						 { "How many times green has been selected", greenNumber }
					 });
		}
		if (haveGreen == true)
		{	
			myImageToUpdate.sprite = selectedSprite;
		 	animator.runtimeAnimatorController = green;
			isYellow = false;
			isBlue = false;
			isRed = false;
			isGreen = true;
			isElectro = false;
			isMarble = false;
			
			ES2.Save(isYellow = false,  "savefile.txt?tag=isYellow");
			ES2.Save(isBlue = false,  "savefile.txt?tag=isBlue");
			ES2.Save(isRed = false,  "savefile.txt?tag=isRed");
			ES2.Save(isGreen = true,  "savefile.txt?tag=isGreen");
			ES2.Save(isElectro = false,  "savefile.txt?tag=isElectro");
			ES2.Save(isMarble = false,  "savefile.txt?tag=isMarble");
			
			setPlayer.SetActive(false);	
			button.SetActive(true);
			jumpHard.enabled = true;
			touchStart.SetActive(true);
		}
		else
		{
			StartCoroutine(InsufficientShells());
		}
	}
	
	public void ExitMenu() //Exit UI 
	{
		setPlayer.SetActive(false);	
		button.SetActive(true);
		creditsButton.SetActive(true);
		jumpHard.enabled = true;
		touchStart.SetActive(true);
	}
}

