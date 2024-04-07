using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance;

    public QuestUIController UI;
    private Dictionary<string, IQuestTarget> questTargetDic;
    private List<Quest> quests;

    private string[][] questKeys =
    {
        new string[] { "Jem", "Potion", "SpellBook" },
        new string[] { "Slime", "Wolf", "Golem" },
    };

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        questTargetDic = new Dictionary<string, IQuestTarget>();

        ItemData jemData = new ItemData("Jem", "광물", "광물입니다.");
        questTargetDic["Jem"] = new Jem(jemData);

        ItemData potionData = new ItemData("Potion", "포션", "포션입니다.");
        questTargetDic["Potion"] = new Potion(potionData);

        ItemData spellBookData = new ItemData("SpellBook", "주문서", "주문서입니다.");
        questTargetDic["SpellBook"] = new SpellBook(spellBookData);

        MonsterData slimeData = new MonsterData("Slime", "슬라임", "슬라임입니다.");
        questTargetDic["Slime"] = new Slime(slimeData);

        MonsterData wolfData = new MonsterData("Wolf", "늑대", "늑대입니다.");
        questTargetDic["Wolf"] = new Wolf(wolfData);

        MonsterData golemData = new MonsterData("Golem", "골렘", "골렘입니다.");
        questTargetDic["Golem"] = new Golem(golemData);

        quests = new List<Quest>();

        UI.SetQuestCompleteInit();
        SetRandomQuests();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetRandomQuests();
        }
    }

    public IQuestTarget GetQuestTarget(string questID) => questTargetDic[questID];

    public void CheckQuest(QuestType questType, IQuestTarget questTarget)
    {
        foreach (var quest in quests)
        {
            if (quest.Type.Equals(questType))
            {
                if (quest.CheckProgress(questTarget))
                {
                    quest.IncrementQuantity();
                    if (quest.IsCompleted())
                        quest.GetReward();

                    UI.RefreshInfoSlot(quest.ID);
                }
            }
        }
    }

    private void SetRandomQuests()
    {
        quests.Clear();

        for (int i = 0; i < 3; i++)
        {
            QuestType type = (QuestType)Random.Range(0, 2);
            string key = questKeys[(int)type][Random.Range(0, questKeys[(int)type].Length)];
            int quantity = Random.Range(1, 5) * 5;
            switch (type)
            {
                case QuestType.Acquire:
                    quests.Add(new AcquireQuest(key, questTargetDic[key], quantity));
                    break;
                case QuestType.Kill:
                    quests.Add(new KillQuest(key, questTargetDic[key], quantity));
                    break;
            }
        }

        UI.SetInfoSlotInit(quests);
    }
}
