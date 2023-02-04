using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public PlayerStates playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerStates.ArenaSurvival;
        ActionManager.instance.ArenaSurvived += ArenaSurvived;
        ActionManager.instance.ArenaSurvivalStarted += ArenaSurvivalStarted;
        ActionManager.instance.SeedThrown += SeedThrown;
    }


    private void ArenaSurvived()
    {
        playerState = PlayerStates.ArenaSurvivalEnd;


    }

    private void ArenaSurvivalStarted()
    {
        playerState = PlayerStates.ArenaSurvival;
    }

    private void SeedThrown()
    {
        playerState = PlayerStates.MovingToNewArena;
    }
    
}
