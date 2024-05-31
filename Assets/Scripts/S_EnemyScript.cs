using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyScript : MonoBehaviour
{
    public GameObject Enemy;
    public void Kill(){
        Destroy(Enemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
