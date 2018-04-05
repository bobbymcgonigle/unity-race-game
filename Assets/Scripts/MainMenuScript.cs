using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	public Transform StartCanvas;
	public Transform LevelCanvas;
	public Transform OptionsCanvas;
	


	private string activeCanvas;
	
	// Use this for initialization
	void Start () {
		activeCanvas = "start";
		setAllToFalse();
		switchMenu(activeCanvas);
	}
	//method for switching between the menu screens 
	public void switchMenu(string menu){
		
		setAllToFalse();
		
		switch(menu)
		{
			case "start":
			StartCanvas.gameObject.SetActive(true);
			activeCanvas = "start";
			break;
			
			case "level":
			LevelCanvas.gameObject.SetActive(true);
			activeCanvas = "level";
			break;
			
			case "options":
			OptionsCanvas.gameObject.SetActive(true);
			activeCanvas = "options";
			break;
			
		}
		
	}
	
	private void setAllToFalse(){
		StartCanvas.gameObject.SetActive(false);
		LevelCanvas.gameObject.SetActive(false);
		OptionsCanvas.gameObject.SetActive(false);
	}
}
