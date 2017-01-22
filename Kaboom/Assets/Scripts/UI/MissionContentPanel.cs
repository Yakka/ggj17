using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionContentPanel : MonoBehaviour {
    
	void Start () {
        GetComponent<Text>().text = Gameloop.instance.missionDataList[Gameloop.instance.playerProgression].briefing;
	}
}
