using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//This script is to be attached to the text of the button
public class ChangeLevelButton : MonoBehaviour {

	//name of the scene to be loaded
	public string levelToLoad;

	//function to load the scene 
	public void loadLevel(){

		SceneManager.LoadScene (levelToLoad);
	}
}
