using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    GameObject QuestPrefab;
    [SerializeField]
    List<GameObject> questList;
    [SerializeField]
    QuestScriptableObj QuestStart;


    public void CreateNewQuest (QuestScriptableObj info)
    {
        GameObject temp = Instantiate(QuestPrefab);
        temp.transform.SetParent(transform);
        temp.transform.localPosition = new Vector3(10, 0, 0);
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.GetComponent<Quest>().Initalize(info);
        questList.Add(temp);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(QuestPrefab);
        temp.transform.SetParent(transform);
        temp.transform.localPosition = new Vector3 (10, 0, 0);
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.GetComponent<Quest>().Initalize(QuestStart);
        questList.Add(temp);
    }

   
}
