using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class S_QuestTracker : MonoBehaviour
{
    public List<List<string>> testQuest = new List<List<string>>();
    private bool isQuestOpen = false;
    public GameObject QuestMenu;
    public TextMeshProUGUI questTitle;
    public CharacterController cc;
    public TextMeshProUGUI questJob;
    private int questLevelCount = 2;
    private GameObject questIndicator;
    private float timer = 0;
    private bool isTimerAlreadyActive = false;

    void Start(){
        List<string> name = new List<string>{"Test Quest",};
        List<string> Task1 = new List<string>{"Talk to Agent", "Talk:Agent"};
        List<string> Task2 = new List<string>{"Roam around the environment", "Roam:15"};
        testQuest.Add(name);
        testQuest.Add(Task1);
        testQuest.Add(Task2);
        questTitle.text = testQuest[0][0];
        questJob.text = testQuest[questLevelCount][0];
        QuestMenu.SetActive(false);
        ChecknUpdateQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(!isQuestOpen){
                isQuestOpen = true;
                QuestMenu.SetActive(true);
                cc.enabled = false;
            } else {
                isQuestOpen = false;
                QuestMenu.SetActive(false);
                cc.enabled = true;
            }
        }
        // if(!questIndicator.GetComponent<S_DialogueScript>().isCurrentQuestNPC){
        //     questLevelCount++;
        //     ChecknUpdateQuest();
        // }
        if(timer>0){
            timer-=Time.deltaTime;
            if (timer<0){
                timer = 0;
                ChecknUpdateQuest();
                Debug.Log("Done");
            }
        }
    }

    void ChecknUpdateQuest(){
        if(testQuest[questLevelCount][1].Split(':')[0] == "Talk"){
            questIndicator = GameObject.Find(testQuest[questLevelCount][1].Split(':')[1]);
            questIndicator.GetComponent<S_DialogueScript>().isCurrentQuestNPC = true;
            questIndicator.transform.Find("marker").gameObject.SetActive(true);
        } else if (testQuest[questLevelCount][1].Split(':')[0] == "Roam")
        {
            if(!isTimerAlreadyActive){
                timer = float.Parse(testQuest[questLevelCount][1].Split(':')[1]);
                isTimerAlreadyActive = true;
            }
        }
    }
}
