using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectName",menuName ="Data/Effects", order =1)]
public class EffectData: ScriptableObject {
    public EffectType type;
    public string textNone;
    public int valueSmall;
    public string textSmall;
    public int valueBig;
    public string textBig;
}
