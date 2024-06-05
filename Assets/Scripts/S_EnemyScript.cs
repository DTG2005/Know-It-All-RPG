using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyScript : MonoBehaviour
{
    public GameObject Enemy;
    public S_QuestTracker questTracker;
    public void Kill(){
        Debug.Log(questTracker.questIndicator.name);
        if (questTracker.questIndicator.name == Enemy.name){
            questTracker.questLevelCount++;
            Debug.Log("Done12");
            questTracker.ChecknUpdateQuest();
            Debug.Log("Done22");
        }
        Destroy(Enemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
