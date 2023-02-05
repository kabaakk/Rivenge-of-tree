using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionManager : Singleton<ActionManager>
{

    public Action ArenaSurvived;

    public Action ArenaSurvivalStarted;

    public Action SeedThrown;

    public Action PlayerDied;

    public Action GameWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
