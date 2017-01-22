using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MissionName", menuName = "Data/Mission", order = 3)]
public class MissionData : ScriptableObject {
    [System.Serializable]
    public struct Goal { public EffectType type; public EffectScale scale; }
	public int budget = 0;
    public string name = string.Empty;
    public string briefing = string.Empty;

    public List<Goal> goals = new List<Goal>();

}
