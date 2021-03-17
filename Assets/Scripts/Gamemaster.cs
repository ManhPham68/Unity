using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour

{
    public int points = 0;
    public Text pointtext;
    
    void Update() { pointtext.text = ("Points:" + points); }
}
