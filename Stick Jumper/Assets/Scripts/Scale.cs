using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {
	
	Animator otherAnimator;
	
	  public GameObject Player;
 
     void Start()
		{
			otherAnimator = Player.GetComponent<Animator> ();
			
            StartCoroutine(ScaleOverTime2()); //Timers of different sizes
        }
     
     
	IEnumerator ScaleOverTimeStart()
	{
   		yield return new WaitForSeconds(Random.Range(6,15));
		otherAnimator.CrossFade("normalToBig", 0f);
		Jump.rightSpeed = 100;
		Jump.leftSpeed = 100;
		 StartCoroutine(ScaleOverTime());
	}
   	IEnumerator ScaleOverTime()
	{
   		yield return new WaitForSeconds(Random.Range(6,15));
		otherAnimator.CrossFade("bigToNormal", 0f);
		Jump.rightSpeed = 150;
		Jump.leftSpeed = 150;
		 StartCoroutine(ScaleOverTime2());
	}
		IEnumerator ScaleOverTime2()
	{
   		yield return new WaitForSeconds(Random.Range(10,30));
		otherAnimator.CrossFade("normalToSmall", 0f);
		Jump.rightSpeed = 300;
		Jump.leftSpeed = 300;
		StartCoroutine(ScaleOverTime3());
		
	}
	IEnumerator ScaleOverTime3()
	{
   		yield return new WaitForSeconds(Random.Range(10,15));
		otherAnimator.CrossFade("smallToNormal", 0f);
		Jump.rightSpeed = 150;
		Jump.leftSpeed = 150;
		StartCoroutine(ScaleOverTime4());
		
	}
	IEnumerator ScaleOverTime4()
	{
   		yield return new WaitForSeconds(Random.Range(15,30));
		otherAnimator.CrossFade("normalToBig", 0f);
		Jump.rightSpeed = 100;
		Jump.leftSpeed = 100;
		StartCoroutine(ScaleOverTime());
		
	}
	
}
         
     
			


 
	
	
	
	 


