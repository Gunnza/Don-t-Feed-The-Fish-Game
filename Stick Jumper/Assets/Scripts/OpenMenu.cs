using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour {
	
public GameObject setPlayer;
public GameObject button, creditsButton;
public GameObject thePlayer;
public GameObject touchStart;
public GameObject yellow, green, marble , red, electro , creditsPanel;
	
public Sprite selectSprite;
	
JumpHard jumpHard;
	
Image redImage, yellowImage, greenImage, marbleImage, electroImage;

	void Start()
	{
		jumpHard = thePlayer.GetComponent<JumpHard>();
	}
	public void OpenCharSelect()	
	{
		SetNewBird.haveYellow = ES2.Load<bool>("savefile.txt?tag=haveYellow");
		SetNewBird.haveRed = ES2.Load<bool>("savefile.txt?tag=haveRed");
		SetNewBird.haveGreen = ES2.Load<bool>("savefile.txt?tag=haveGreen");
		SetNewBird.haveMarble = ES2.Load<bool>("savefile.txt?tag=haveMarble");
		SetNewBird.haveElectro = ES2.Load<bool>("savefile.txt?tag=haveElectro");
		
		
		touchStart.SetActive(false);
		jumpHard.enabled = false;
		setPlayer.SetActive(true); //Diable PlayerMovement
		button.SetActive(false);
		creditsButton.SetActive(false);
		
		if(SetNewBird.haveYellow == true)
		{
			yellowImage = yellow.GetComponent<Image>();
			yellowImage.sprite = selectSprite;
		}
		
		if(SetNewBird.haveRed == true)
		{
			redImage = red.GetComponent<Image>();
			redImage.sprite = selectSprite;
		}
		
		if(SetNewBird.haveGreen == true)
		{
			greenImage = green.GetComponent<Image>();
			greenImage.sprite = selectSprite;
		}
		
		if(SetNewBird.haveMarble == true)
		{
			marbleImage = marble.GetComponent<Image>();
			marbleImage.sprite = selectSprite;
		}
		
		if(SetNewBird.haveElectro == true)
		{
			electroImage = electro.GetComponent<Image>();
			electroImage.sprite = selectSprite;
		}
	}
	
	public void Credits()	
	{
		creditsPanel.SetActive(true);
		button.SetActive(false);
		creditsButton.SetActive(false);
	}
	
	public void ExitMenu()
	{
		creditsPanel.SetActive(false);
		setPlayer.SetActive(false);	
		button.SetActive(true);
		creditsButton.SetActive(true);
		jumpHard.enabled = true;
		touchStart.SetActive(true);
	}
}
