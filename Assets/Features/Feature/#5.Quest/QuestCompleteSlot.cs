using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class QuestCompleteSlot : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private QuestType questType;
    [SerializeField] private string questID;

    public void Init()
    {
        IQuestTarget questTarget = QuestController.Instance.GetQuestTarget(questID);
        button.onClick.AddListener(() => QuestController.Instance.CheckQuest(questType, questTarget));
    }
}
