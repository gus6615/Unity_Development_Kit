using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuest : Quest
{
    public override string Title => $"{Target.QuestID}��(��) ��ƶ�!";
    public override string Description => $"{Target.QuestID}��(��) {MaxQuantity}�� óġ�Ͻÿ�.";

    public KillQuest(string id, IQuestTarget target, int maxQuantity) : base(id, QuestType.Kill, target, maxQuantity)
    {

    }

    public override void GetReward()
    {
        Debug.Log($"'{Target}' óġ ����Ʈ �Ϸ�. ������ �����մϴ�.");
    }
}
