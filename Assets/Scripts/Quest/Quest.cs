using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Quest : MonoBehaviour
{
    [SerializeField]
    QuestScriptableObj questInfo;
    [SerializeField]
    Text QuestName;
    [SerializeField]
    Text QuestDescription;
    [SerializeField]
    Text QuestProgress;
    [SerializeField]
    int progress;
    bool init = false;

    private void FixedUpdate()
    {
        //init = true;
        if (!init)
            return;

        //QuestName.text = questInfo.qname;
        //QuestDescription.text = questInfo.qdesc;
        progress = GameObject.FindGameObjectsWithTag(questInfo.qtag).Length;
        QuestProgress.text = progress + " / " + questInfo.targetNum;

        if (progress >= questInfo.targetNum)
        {
            if (questInfo.nextQ != null)
            {
                GameObject.FindGameObjectWithTag("QuestManager").GetComponent<QuestManager>().CreateNewQuest(questInfo.nextQ);
                //spawn next quest
            }

            Destroy(gameObject);
            // clean up
        }
    }

    public void Initalize (QuestScriptableObj _qinfo)
    {
        questInfo = _qinfo;
        init = true;
        QuestName.text = questInfo.qname;
        QuestDescription.text = questInfo.qdesc;
    }
}
