﻿using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;

public class InteractableChest : Interactable
{
    [SerializeField, ReadOnly] private List<Item> rewards;

    public List<Item> GetItems()
    {
        return rewards;
    }

    public void SetItem(Item item)
    {
        if (item == null)
            return;
        rewards.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (item == null || !rewards.Contains(item))
            return;
        rewards.Remove(item);
    }

    private void OnEnable()
    {
        rewards = new List<Item>();
        var count = Random.Range(3, 20);
        for (int i = 0; i < count; i++)
        {
            rewards.Add(GameData.GetEquipmentItems().RandomItem());
        }
    }

    public override void Interact()
    {
        base.Interact();


        var chestPage = UI_Manager.instance.GetPageOfType<ChestPage>();
        UI_Manager.instance.OpenPage(chestPage);
        chestPage.SetChest(this);
    }
}
