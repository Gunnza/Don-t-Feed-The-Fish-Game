using UnityEngine;
using System.Collections;

public class MoveSpikes : MonoBehaviour {
	
    //Speed variable 
	public float speed = 2;

    //init spikes score variable
	public static float startSpikes = 3;

    //spikes game object
	public GameObject spikesCollider;
	
	// Update is called once per frame
	void Update () {
        
        //Play spikes when user is at the right score
		if(Score.score >= startSpikes)
		{
            //timer for the spikes to become active
			StartCoroutine(WaitForSpikes());

            //move the spikes across the screen 
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
		}
	}
	
	IEnumerator WaitForSpikes()
	{
        //wait 3 seconds then activate spikes
		yield return new WaitForSeconds(3);	
		spikesCollider.SetActive(true);
	}
	
}
