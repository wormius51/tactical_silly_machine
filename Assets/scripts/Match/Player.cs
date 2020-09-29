using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string name;
    public bool isAI;
    [HideInInspector]
    public bool isEliminated;
    public ControllableUnit[] units;
}
