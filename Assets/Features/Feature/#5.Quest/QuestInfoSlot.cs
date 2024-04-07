using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestInfoSlot : MonoBehaviour
{
    public Quest Quest;

    [SerializeField] private Image background;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;

    public void SetQuestInfoSlot(Quest quest)
    {
        this.Quest = quest;
        RefreshInfoSlot();
    }

    public void RefreshInfoSlot()
    {
        if (Quest.IsCompleted())
        {
            background.color = new Color(0f, 0f, 0f, 0.4f);
            title.color = description.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        }
        else
        {
            background.color = new Color(1f, 1f, 1f, 0.4f);
            title.color = description.color = new Color(0.2f, 0.2f, 0.2f, 1f);
        }

        title.SetText(Quest.Title);
        description.SetText($"{Quest.Description} ({Quest.CurrentQuantity}/{Quest.MaxQuantity})");
    }
}
