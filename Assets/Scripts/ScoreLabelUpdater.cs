using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreLabelUpdater : MonoBehaviour {

	public PlayerController playerController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = "Score " + playerController.currentLevel;	
	}
}
