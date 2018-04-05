using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//script for changing resolution and volume levels
public class optionsHandler : MonoBehaviour {


	
	public Slider volumeSlider;
	public Dropdown resolutionOptions;
	public Toggle FullScreenToggle;
	public bool isFullScreen;
	public int currentWidth, currentHeight;
	
	void Start(){
		//FullScreenToggle.enabled = Screen.fullScreen;
		isFullScreen = Screen.fullScreen;
		currentHeight = Screen.height;
		currentWidth = Screen.width;
	}
	
	public void toggleFullscreen(bool toggle){
		
		updateResolution(currentWidth,currentHeight,toggle);
	}
	
	public void changeResolution(){
		
		
		switch(resolutionOptions.value)
		{
			case 0:
			updateResolution(1280,720,isFullScreen);
			break;
			
			case 1:
			updateResolution(1280,600,isFullScreen);
			break;
			
			case 2:
			updateResolution(800,600,isFullScreen);
			break;
			
			case 3:
			updateResolution(640,480,isFullScreen);
			break;
			
			case 4:
			updateResolution(640,400,isFullScreen);
			break;
			
			case 5:
			updateResolution(512,384,isFullScreen);
			break;
			
			case 6:
			updateResolution(400,300,isFullScreen);
			break;
			
			case 7:
			updateResolution(320,240,isFullScreen);
			break;
			
			case 8:
			updateResolution(320,200,isFullScreen);
			break;
			
		}
	
	}
	
	public void updateResolution(int width, int height, bool fullScreen){
		currentHeight = height;
		currentWidth = width;
		isFullScreen = fullScreen;
		Screen.SetResolution(width, height, isFullScreen);
	}
	
	public void changeVolume(){
		 AudioListener.volume =volumeSlider.value;
	 }
	 
}
