using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIController : MonoBehaviour
{
    public QuestInfoSlot[] InfoSlots;
    public QuestCompleteSlot[] CompleteSlots;

    public void SetInfoSlotInit(List<Quest> quests)
    {
        for (int i = 0; i < InfoSlots.Length; i++)
        {
            InfoSlots[i].SetQuestInfoSlot(quests[i]);
        }
    }

    public void SetQuestCompleteInit()
    {
        foreach (var slot in CompleteSlots)
        {
            slot.Init();
        }
    }

    public void RefreshInfoSlot(string questID)
    {
        foreach (var slot in InfoSlots)
        {
            if (slot.Quest.ID.Equals(questID))
            {
                slot.RefreshInfoSlot();
            }
        }
    }
}
