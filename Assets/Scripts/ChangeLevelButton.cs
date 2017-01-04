using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;	//SceneManager is a class in SceneManagement required to manage scenes at runtime

//This script is to be attached to the text of the button
public class ChangeLevelButton : MonoBehaviour {

	//name of the scene to be loaded
	public string levelToLoad;

	//function to load the scene 
	public void loadLevel(){

		SceneManager.LoadScene (levelToLoad);	//this function Loads the scene by its name 
	}
}
