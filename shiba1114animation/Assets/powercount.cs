using UnityEngine;
using System.Collections;

public class powercount : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.guiText.text = "パワー:" +smartball.power *100+"%";
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.guiText.text = "パワー:" +smartball.power *100+"%";
		if(smartball.power *100 == 100){
			gameObject.guiText.text = "パワー:めっちゃつよい";
		}
	}
}
