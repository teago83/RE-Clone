﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState_Biting : ZombieState_Base
{
    public override void OnCollisionEnter(ZombieAIFSM zScript)
    {
    }

    public override void OnEnterState(ZombieAIFSM zScript)
    {

        Debug.Log("I'm biting nhom nhom");

    }

    public override void Update(ZombieAIFSM zScript)
    {
    }
}
