using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemData
{
    public string ID;
    public string Name;
    public string Description;

    public ItemData(string id, string name, string description)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
    }
}

public abstract class Item
{
    public ItemData Data;

    public Item(ItemData data)
    {
        this.Data = new ItemData();
        this.Data.ID = data.ID;
        this.Data.Name = data.Name;
        this.Data.Description = data.Description;
    }
}

public class Jem : Item, IQuestTarget
{
    public Jem(ItemData data) : base(data)
    {

    }

    string IQuestTarget.QuestID { get => Data.ID; }

    public bool CheckFullFill()
    {
        throw new System.NotImplementedException();
    }
}

public class Potion : Item, IQuestTarget
{
    public Potion(ItemData data) : base(data)
    {

    }

    string IQuestTarget.QuestID { get => Data.ID; }

    public bool CheckFullFill()
    {
        throw new System.NotImplementedException();
    }
}

public class SpellBook : Item, IQuestTarget
{
    public SpellBook(ItemData data) : base(data)
    {

    }

    string IQuestTarget.QuestID { get => Data.ID; }

    public bool CheckFullFill()
    {
        throw new System.NotImplementedException();
    }
}