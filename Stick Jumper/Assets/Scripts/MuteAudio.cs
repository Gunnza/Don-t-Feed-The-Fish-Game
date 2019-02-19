using UnityEngine;
using System.Collections;

public class MuteAudio : MonoBehaviour {

	void muteAudio() //Mute Audio when this method is called
	{
		AudioListener.pause = true;
		
		AudioListener.volume = 0;
	}
}
