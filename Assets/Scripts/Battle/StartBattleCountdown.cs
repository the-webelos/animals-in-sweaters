using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattleCountdown : MonoBehaviour
{
    public MusicManager musicManager;
   
    public void StartCountdown()
    {
        musicManager.PlayClips();
    }
}
