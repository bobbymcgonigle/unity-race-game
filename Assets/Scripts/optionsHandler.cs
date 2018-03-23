using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsHandler : MonoBehaviour {

	
	public void changeResolution(int height, int width, bool isFullScreen){
		Screen.SetResolution(width, height, isFullScreen);
	}
	
	public void changeVolume(float volume){
		 AudioListener.volume =volume;
	 }
	 
}
