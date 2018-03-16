using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneHandler : MonoBehaviour {

     public void LoadScene(string levelName)
     {
		Time.timeScale = 1;// resumes game time
        SceneManager.LoadScene(levelName);
     }
}
