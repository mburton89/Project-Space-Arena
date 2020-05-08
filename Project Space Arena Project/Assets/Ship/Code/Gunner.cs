using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : EnemyShip
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heading = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //TODO Follow player
        MoveToPosition(heading);
    }
}
