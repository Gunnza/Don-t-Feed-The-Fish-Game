using UnityEngine;
using System.Collections;


public class Background : MonoBehaviour {
	
	//speed of moving background
	public float speed = 1.5f;
	
	void Update() {
        
        //moving the background 
		Vector2 offset = new Vector2( Time.time * speed , 0);

        //getting the background
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}


 
/*
 public class Background : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;

    void Start () {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset ("_MainTex");
    }

    void Update () {
        float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2 (x, savedOffset.y);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
    }

    void OnDisable () {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
    }
}
*/
		