using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 1)]
public class QuestScriptableObj : ScriptableObject
{
    public string qname => QuestName;
    public string qdesc => QuestDescription;
    public string qtag => tag;
    public int targetNum => targetNumber;
    public QuestScriptableObj nextQ => nextQuest;

    [SerializeField]
    string QuestName;
    [SerializeField]
    string QuestDescription;
    [SerializeField]
    int targetNumber;
    [SerializeField]
    string tag;
    [SerializeField]
    QuestScriptableObj nextQuest;
}
