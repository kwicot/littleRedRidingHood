using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using SO;
using UnityEngine;

namespace Models
{
    public class GameData
    { 
        public Dictionary<string, bool> PickUpItemState;
        public List<string> ItemsOnInventory;
        public string HandSlot;


        private List<PickUp> PickUpScripts = new List<PickUp>();

        public Inventory inventory;

        public void SaveData()
        {
            PersistentCache.Remove("HandSlotItem");

            if (ItemsOnInventory == null) ItemsOnInventory = new List<string>();
            ItemsOnInventory.Clear();
            for (int i = 0; i < inventory.ItemsCount; i++)
                if(inventory[i] != null)ItemsOnInventory.Add(inventory[i].MainData.Name);

            if (inventory.HandSlot.selectedItemController != null)
                HandSlot = inventory.HandSlot.selectedItemController.MainData.Name;
            
            PersistentCache.Save("PickUpItemState", PickUpItemState);
            PersistentCache.Save("InventoryData", ItemsOnInventory);
            if(!string.IsNullOrEmpty(HandSlot))PersistentCache.Save("HandSlotItem", HandSlot);
        }

        public void LoadData()
        {
            ItemsOnInventory = PersistentCache.TryLoad<List<string>>("InventoryData");
            if (ItemsOnInventory == null) ItemsOnInventory = new List<string>();
            inventory.CreateItemByName(ItemsOnInventory);

            var hand = PersistentCache.TryLoad<string>("HandSlotItem");
            if (!string.IsNullOrEmpty(hand))
            {
                inventory.CreateItemByName(hand, out ItemController item);
                inventory.Equipt(item);
                // handItem = item;
            }


            // if(handItem) inventory.Equipt(handItem);
        }

        public void NewGame()
        {
            PersistentCache.ClearPersistentStorage();
        }

        public void AddPickUpScript(PickUp item)
        {
            foreach (var b in PickUpItemState)
            {
                if(b.Key== item.KeyName) return;
            }
            PickUpItemState.Add(item.KeyName,true);
        }

        public void PickUp(string name)
        {
            try
            {
                PickUpItemState[name] = false;
            }
            catch (Exception e)
            {
                
            }
            
            
        }

        public GameData()
        {
            PickUpItemState = PersistentCache.TryLoad<Dictionary<string, bool>>("PickUpItemState");
            if (PickUpItemState == null) PickUpItemState = new Dictionary<string, bool>();
        }
    }
}