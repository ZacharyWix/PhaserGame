﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class saveGame
{
    public List<List<float>> levelSave = new List<List<float>>();
    public List<int> achievementSave = new List<int>();
    public List<float> optionsSave = new List<float>();
    public int skin;
}
