using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnShell : MonoBehaviour {
	
	
    public List<Sprite> iList = new List<Sprite>(); //List for different type of sprite
	public List<int> xpos = new List<int>(); //Xposition list 
	public List<int> ypos = new List<int>();//Yposition list 
	
	int index; //X position access variable 
	int yposIndex; //Y position access variable 
	
	public GameObject shellSprite; // The actual shell gameobject 
	
    public static SpriteRenderer sr; 
	public static BoxCollider2D shellBox;
	
	// Use this for initialization
	void Start () 
	{	
		shellBox = GetComponent<BoxCollider2D>(); //The box collider for the shell 
		sr = shellSprite.GetComponent<SpriteRenderer>(); //The sprite for the shell on the child
		shellBox.enabled = false; // disabling the box collider 
		sr.sprite = null; 
		
		StartCoroutine(newShell()); //Start of the game will bring new shell 
	}
	
	public void changeShell()
	{
		StartCoroutine(newShell()); 
	}
	
    IEnumerator newShell() // New shell every 5 seconds after no shell being on screen. Spawning at a random location
	{
		yield return new WaitForSeconds(5);
		index = Random.Range(0,3); //Number of different x positions on the list
		yposIndex = Random.Range(0,5);
		
		shellBox.enabled = true; //enabling the box collider 
		sr.sprite = iList[index]; //choosing and new sprite 
		transform.position = new Vector3(xpos[index], ypos[yposIndex], 0); //setting position
		
		//Test Code
		//yield return new WaitForSeconds(1);
		//shellBox.enabled = false;
		//sr.sprite = null;
		//StartCoroutine(newShell());
		//Test Code
	}
}

