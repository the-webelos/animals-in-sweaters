﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    void Start()
    {
		GameManager.GetStageManager().LoadStage();
	}
}
