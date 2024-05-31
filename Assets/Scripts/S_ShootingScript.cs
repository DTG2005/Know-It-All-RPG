using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ShootingScript : MonoBehaviour
{
    float range = 100f;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(player.transform.position, player.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            try {
                S_EnemyScript gb = hit.transform.GetComponent<S_EnemyScript>();
                gb.Kill();
            } catch {
                
            }
        }
    }
}
