﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    public override void HandleDamageTaken()
    {
        
    }

    public override void HandleDeath()
    {
        if (EnemyShipSpawner.Instance != null)
        {
            EnemyShipSpawner.Instance.CheckEnemyCount();
        }
    }
}
