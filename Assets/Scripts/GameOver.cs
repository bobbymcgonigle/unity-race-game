using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour {

	public Transform canvas;
	
	public void TriggerGameOver(){
		if(canvas.gameObject.activeInHierarchy == false)// if the canvas that is being modified is not being rendered
		{
			canvas.gameObject.SetActive(true); //the selected canvas will now be rendered
			Time.timeScale = 0;// pauses game time
				
		}
		else
		{
			canvas.gameObject.SetActive(false); //the selected canvas will now not be rendered				
			Time.timeScale = 1;// resumes game time
		}
	}
	public void restart(){
		 Scene scene = SceneManager.GetActiveScene();
		 Time.timeScale = 1;
		 SceneManager.LoadScene(scene.name);
	}
}

