using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Electric : MonoBehaviour {
	
	public List<GameObject> iList = new List<GameObject>(); //List for Bolt strikes
	
	//GameObjects
	public GameObject boltSizzle;
	
	//Ints
	public int electricTime = 1; //Time before it goes into electric mode 
	
	//Componants
	AudioSource audio;
	public AudioClip sparkAudio;
	
	BoxCollider2D electricCollider;
	
	//Booleans
	bool isOn;

	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource>();
		electricCollider = GetComponent<BoxCollider2D>();
		boltSizzle.SetActive(false);// On start make sure sizzle is not active
		//StartCoroutine(RandomSpot());
		
        //Electric starts as off 
		isOn = false;
	}
	void Update()
	{
        //when score reaches number then electric is turned on 
		if(Score.score >= 6)
		
			if(isOn == false)
		    {
			    isOn = true;
            
               //play the electric loop
			   StartCoroutine(RandomSpot());
		    }
	}
	IEnumerator RandomSpot() // 
	{
		yield return new WaitForSeconds(electricTime);
		boltSizzle.SetActive(true);//Enemy starts charging up 
		
		//Choose Angle
		yield return new WaitForSeconds(5);
		if(Score.score <= 9)
		{
			int index = Random.Range(0,8); //Dfferent angles of bolt strike
			
			//Bolt Charge
			iList[index].SetActive(true); //Set gameobject in the list to active
			yield return new WaitForSeconds(2f);//2 seconds to see charge up
		
			//Bolt Strike
			audio.PlayOneShot(sparkAudio, 0.7F); 
			iList[index].transform.GetChild(0).gameObject.SetActive(true);//Set bolt strike object active
			yield return new WaitForSeconds(.7f); 
			iList[index].transform.GetChild(0).gameObject.SetActive(false);//Set bolt strike object false
			iList[index].SetActive(false);//wait and deactive electric again
			
			
			StartCoroutine(RandomSpot()); // Restart Coroutine
		}
		
		/*
		else if(multiStrike > 10)
		{
			//Bolt Charge
			iList[0].SetActive(true); //Set gameobject in the list to active
			iList[1].SetActive(true); //Set gameobject in the list to active
			iList[4].SetActive(true); //Set gameobject in the list to active
			iList[8].SetActive(true); //Set gameobject in the list to active
			yield return new WaitForSeconds(2f);//2 seconds to see charge up
			
			//Bolt Strike
			iList[0].transform.GetChild(0).gameObject.SetActive(true);//Set bolt strike object active
			iList[1].transform.GetChild(0).gameObject.SetActive(true);//Set bolt strike object active
			iList[4].transform.GetChild(0).gameObject.SetActive(true);//Set bolt strike object active
			iList[8].transform.GetChild(0).gameObject.SetActive(true);//Set bolt strike object active
			yield return new WaitForSeconds(.7f); 
			iList[0].transform.GetChild(0).gameObject.SetActive(false);//Set bolt strike object false
			iList[1].transform.GetChild(0).gameObject.SetActive(false);//Set bolt strike object false
			iList[4].transform.GetChild(0).gameObject.SetActive(false);//Set bolt strike object false
			iList[8].transform.GetChild(0).gameObject.SetActive(false);//Set bolt strike object false
			
			iList[0].SetActive(false);//wait and deactive electric again
			iList[1].SetActive(false);//wait and deactive electric again
			iList[4].SetActive(false);//wait and deactive electric again
			iList[8].SetActive(false);//wait and deactive electric again
			
			multiStrike = 0;
			
			StartCoroutine(RandomSpot());
		}
		*/
		
		else if(Score.score >= 10)
		{
			
			int index1 = Random.Range(0,3); //Dfferent angles of bolt strike
			int index2 = Random.Range(4,8); // so it will always pick diffferent object
			
			//Bolt Charge
			iList[index1].SetActive(true); //Set gameobject in the list to active
			iList[index2].SetActive(true); //Set gameobject in the list to active
			yield return new WaitForSeconds(2f);//2 seconds to see charge up
	
			//Bolt Strike
			audio.PlayOneShot(sparkAudio, 0.5F); 
			iList[index1].transform.GetChild(0).gameObject.SetActive(true);//Set bolt strike object active
			iList[index2].transform.GetChild(0).gameObject.SetActive(true);//Set bolt strike object active
			
			yield return new WaitForSeconds(.2f);
			iList[index1].transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;//Set bolt strike object false
			iList[index2].transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;//Set bolt strike object false
			
			yield return new WaitForSeconds(.7f); 
			iList[index1].transform.GetChild(0).gameObject.SetActive(false);//Set bolt strike object false
			iList[index2].transform.GetChild(0).gameObject.SetActive(false);//Set bolt strike object false
			
			iList[index1].SetActive(false);//wait and deactive electric again
			iList[index2].SetActive(false);//wait and deactive electric again
			
			StartCoroutine(RandomSpot());
		}
			
		
		
		
		
		
		/*
		shellBox.enabled = true; //enabling the box collider 
		sr.sprite = iList[index]; //choosing and new sprite 
		transform.position = new Vector3(xpos[index], ypos[yposIndex], 0); //setting position
		*/
		
	}
	
}
