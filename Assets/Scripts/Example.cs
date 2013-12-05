using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {

	MonsterPattern monsterPattern;

	// Use this for initialization
	void Awake () {
	
		monsterPattern = gameObject.GetComponent<MonsterPattern>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("space"))
		{
			if (monsterPattern != null)
				monsterPattern.OnEvent();
		}

	}
}
