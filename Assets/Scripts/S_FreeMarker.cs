using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FreeMarker : MonoBehaviour
{
    public GameObject marker;
    public S_QuestTracker questTracker;

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Player"){
            questTracker.questLevelCount++;
            questTracker.ChecknUpdateQuest();
            Destroy(marker);
        }
    }
}
