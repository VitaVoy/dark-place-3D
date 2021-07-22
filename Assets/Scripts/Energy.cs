using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private Texture2D energyBar;
    [SerializeField] private Texture2D energy;
    public static float energyLenghth = 200.0f;
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width * 0.5f + 300, 30, 200, 25), energyBar);
        GUI.DrawTexture(new Rect(Screen.width * 0.5f + 300, 30, energyLenghth, 25), energy);
    }   
}
