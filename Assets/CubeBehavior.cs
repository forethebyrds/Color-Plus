using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {

	int colorCount = 5;
	GameController aGameController;
	public bool activeCube = true; 
	public bool blackCube;
	public bool isColored;

	Color[] plusColors = {Color.yellow, Color.blue, Color.green, Color.red, Color.magenta};
	 

	// Use this for initialization
	void Start () {
		
		aGameController = GameObject.Find("GameControlObject").GetComponent<GameController>();

	}


	// Update is called once per frame
	void Update () {
	
	}
}
