using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour{ 
	
	
public static bool created = false;

	
 void Awake () {
	
		if(!created)//Boolean stops multiple objects from being created
		{
         	DontDestroyOnLoad (transform.gameObject); //Dont destroy gameobject 
			created = true;
		}
		else 
		{
			Destroy(gameObject);
		}
     }
}
