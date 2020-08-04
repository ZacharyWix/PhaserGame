using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class saveGame
{
    public List<List<float>> levelSave = new List<List<float>>();
    public List<int> achievementSave = new List<int>();
    public List<float> optionsSave = new List<float>();
    public List<int> skins = new List<int>();
    public List<int> accessories = new List<int>();
    public int runDeaths, bestDeaths, runLevel;
    public float runTime, bestTime;
    public int skin, accessory;
}
