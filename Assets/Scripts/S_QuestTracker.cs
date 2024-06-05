using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S_QuestTracker : MonoBehaviour
{
    public List<List<string>> testQuest = new();
    private bool isQuestOpen = false;
    public GameObject QuestMenu;
    public TextMeshProUGUI questTitle;
    public CharacterController cc;
    public TextMeshProUGUI questJob;
    public int questLevelCount = 1;
    public GameObject questIndicator;
    private float timer = 0;
    private bool isTimerAlreadyActive = false;

    void Start(){
        List<string> name = new() { "Test Quest",};
        List<string> Task1 = new() { "Talk to Agent", "Talk:Agent"};
        List<string> Task2 = new() { "Kill enemy", "Kill:Enemy"};
        List<string> Task3 = new() {"Talk to Agent 2", "Talk:Agent (1)"};
        testQuest.Add(name);
        testQuest.Add(Task1);
        testQuest.Add(Task2);
        testQuest.Add(Task3);
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
        if(timer>0){
            timer-=Time.deltaTime;
            if (timer<0){
                timer = 0;
                ChecknUpdateQuest();
                Debug.Log("Done");  
            }
        }
    }

    public void ChecknUpdateQuest(){
        if(testQuest[questLevelCount][1].Split(':')[0] == "Talk"){
            questIndicator = GameObject.Find(testQuest[questLevelCount][1].Split(':')[1]);
            questIndicator.GetComponent<S_DialogueScript>().isCurrentQuestNPC = true;
            questIndicator.transform.Find("marker").gameObject.SetActive(true);
            questIndicator.GetComponent<S_DialogueScript>().questTracker = this;
            questJob.text = testQuest[questLevelCount][0];
            Debug.Log("Done");
        } else if (testQuest[questLevelCount][1].Split(':')[0] == "Roam")
        {
            if(!isTimerAlreadyActive){
                timer = float.Parse(testQuest[questLevelCount][1].Split(':')[1]);
                isTimerAlreadyActive = true;
            }
            questIndicator = null;
        } else if (testQuest[questLevelCount][1].Split(':')[0] == "Kill"){
            questIndicator = GameObject.Find(testQuest[questLevelCount][1].Split(':')[1]);
            questIndicator.transform.Find("marker").gameObject.SetActive(true);
            questJob.text = testQuest[questLevelCount][0];
        }
        Debug.Log(questIndicator.name);
        Debug.Log(questLevelCount);
    }
}
