using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public PlayerStates playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerStates.InBetween;
        ActionManager.instance.ArenaSurvived += ArenaSurvived;
        ActionManager.instance.ArenaSurvivalStarted += ArenaSurvivalStarted;
        ActionManager.instance.SeedThrown += SeedThrown;
        ActionManager.instance.GameWin += GameWin;
    }


    private void ArenaSurvived()
    {
        playerState = PlayerStates.InBetween;
        
        DOVirtual.DelayedCall(0.3f,()=>playerState = PlayerStates.ArenaSurvivalEnd);


    }

    private void ArenaSurvivalStarted()
    {
        playerState = PlayerStates.ArenaSurvival;
    }

    private void SeedThrown()
    {
        playerState = PlayerStates.MovingToNewArena;
    }

    public void FinishedGrowing()
    {
        
        playerState = PlayerStates.ArenaSurvival;
        ActionManager.instance.ArenaSurvivalStarted?.Invoke();
    }

    public void PlayerDied()
    {
        ActionManager.instance.PlayerDied?.Invoke();
           
        playerState = PlayerStates.Dead;
    }
    
    
    private void GameWin()
    {
        playerState = PlayerStates.InBetween;
    }
    
}
