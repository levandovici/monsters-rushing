using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory
{
    public const string Cell = "UI/Items/cell";

    public const string Gems = "UI/Items/gems";
    public const string Energy = "UI/Items/energy";
    public const string Key = "UI/Items/key";

    public const string Fuel = "UI/Items/fuel";
    public const string ToolBox = "UI/Items/toolbox";

    public const string Common_1 = "UI/Items/common-1";
    public const string Common_2 = "UI/Items/common-2";
    public const string Common_3 = "UI/Items/common-3";
    public const string Common_4 = "UI/Items/common-4";
    public const string Common_5 = "UI/Items/common-5";
    public const string Common_6 = "UI/Items/common-6";
    public const string Common_7 = "UI/Items/common-7";

    public const string Rare_1 = "UI/Items/rare-1";
    public const string Rare_2 = "UI/Items/rare-2";
    public const string Rare_3 = "UI/Items/rare-3";
    public const string Rare_4 = "UI/Items/rare-4";
    public const string Rare_5 = "UI/Items/rare-5";

    public const string Epic_1 = "UI/Items/epic-1";
    public const string Epic_2 = "UI/Items/epic-2";
    public const string Epic_3 = "UI/Items/epic-3";




    [System.Serializable]
    public class InventoryObject
    {
        public string location;
        public EInventoryObjectRarity rarity;
        public int count;



        public InventoryObject(string location, EInventoryObjectRarity rarity, int count)
        {
            this.location = location;
            this.rarity = rarity;
            this.count = count;
        }


        public InventoryObject Clone()
        {
            return new InventoryObject(location, rarity, count);
        }
    }

    [System.Serializable]
    public class InventoryObjects
    {
        public InventoryObject[] inventoryObjects;

        public void TryAdd(InventoryObject inventoryObject)
        {
            foreach (InventoryObject obj in inventoryObjects)
            {
                if (obj.location == inventoryObject.location)
                {
                    obj.count += inventoryObject.count;
                    return;
                }
            }

            AddNew(inventoryObject);
        }

        private void AddNew(InventoryObject obj)
        {
            InventoryObject[] arr = new InventoryObject[inventoryObjects.Length + 1];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = inventoryObjects[i];
            }

            arr[arr.Length - 1] = obj;

            inventoryObjects = arr;
        }

        public bool TryGetClone(string location, out InventoryObject obj)
        {
            InventoryObject o = null;
            bool b = TryGet(location, out o);

            if (b)
            {
                obj = o.Clone();
            }
            else obj = null;


            return b;
        }

        private bool TryGet(string location, out InventoryObject obj)
        {
            for (int i = 0; i < inventoryObjects.Length; i++)
            {
                if (inventoryObjects[i].location == location)
                {
                    obj = inventoryObjects[i];
                    return true;
                }
            }

            obj = null;
            return false;
        }

        public int GetCount(string location)
        {
            InventoryObject obj;
            bool b = TryGetClone(location, out obj);


            if (b) return obj.count;

            return 0;
        }

        public InventoryObject GetMaxClone(EInventoryObjectRarity rarity)
        {
            InventoryObject maxObj = null;

            foreach(InventoryObject obj in inventoryObjects)
            {
                if (obj.rarity == rarity && (maxObj == null || maxObj.count < obj.count))
                    maxObj = obj;
            }

            return maxObj.Clone();
        }

        public bool Contains(string location)
        {
            foreach (InventoryObject obj in inventoryObjects)
                if (obj.location == location)
                    return true;

            return false;
        }

        public InventoryObjects()
        {
            inventoryObjects = new InventoryObject[0];
        }

        public InventoryObjects(InventoryObject[] inventoryObjects)
        {
            this.inventoryObjects = inventoryObjects;
        }

        public bool CanUpgrade(InventoryObjects upgradeSet)
        {
            foreach (InventoryObject obj in upgradeSet.inventoryObjects)
            {
                if (GetCount(obj.location) < obj.count)
                    return false;
            }

            return true;
        }

        public void Use(InventoryObjects upgradeSet)
        {
            foreach (InventoryObject obj in upgradeSet.inventoryObjects)
            {
                Use(obj);
            }
        }

        public void Use(InventoryObject upgrade)
        {
                InventoryObject io = null;
                if (TryGet(upgrade.location, out io))
                {
                    io.count -= upgrade.count;
                }
        }
    }


    public static InventoryObjects CheckInventory(InventoryObjects all)
    {
        if (all == null)
        {
            all = new InventoryObjects();
        }
        else if (all.inventoryObjects == null)
        {
            all.inventoryObjects = new InventoryObject[0];
        }

        all.TryAdd(new InventoryObject(Fuel, EInventoryObjectRarity.none, 0));
        all.TryAdd(new InventoryObject(ToolBox, EInventoryObjectRarity.none, 0));

        all.TryAdd(new InventoryObject(Common_1, EInventoryObjectRarity.common, 0));
        all.TryAdd(new InventoryObject(Common_2, EInventoryObjectRarity.common, 0));
        all.TryAdd(new InventoryObject(Common_3, EInventoryObjectRarity.common, 0));
        all.TryAdd(new InventoryObject(Common_4, EInventoryObjectRarity.common, 0));
        all.TryAdd(new InventoryObject(Common_5, EInventoryObjectRarity.common, 0));
        all.TryAdd(new InventoryObject(Common_6, EInventoryObjectRarity.common, 0));
        all.TryAdd(new InventoryObject(Common_7, EInventoryObjectRarity.common, 0));

        all.TryAdd(new InventoryObject(Rare_1, EInventoryObjectRarity.rare, 0));
        all.TryAdd(new InventoryObject(Rare_2, EInventoryObjectRarity.rare, 0));
        all.TryAdd(new InventoryObject(Rare_3, EInventoryObjectRarity.rare, 0));
        all.TryAdd(new InventoryObject(Rare_4, EInventoryObjectRarity.rare, 0));
        all.TryAdd(new InventoryObject(Rare_5, EInventoryObjectRarity.rare, 0));

        all.TryAdd(new InventoryObject(Epic_1, EInventoryObjectRarity.epic, 0));
        all.TryAdd(new InventoryObject(Epic_2, EInventoryObjectRarity.epic, 0));
        all.TryAdd(new InventoryObject(Epic_3, EInventoryObjectRarity.epic, 0));

        return all;
    }

    public enum EInventoryObjectRarity
    {
        none, common, rare, epic,
    }

    public static InventoryObjects Sort(InventoryObjects all)
    {
        List<InventoryObject> none = new List<InventoryObject>();
        List<InventoryObject> common = new List<InventoryObject>();
        List<InventoryObject> rare = new List<InventoryObject>();
        List<InventoryObject> epic = new List<InventoryObject>();

        foreach (InventoryObject obj in all.inventoryObjects)
        {
            if (obj.rarity == EInventoryObjectRarity.none)
                none.Add(obj);

            if (obj.rarity == EInventoryObjectRarity.common)
                common.Add(obj);

            if (obj.rarity == EInventoryObjectRarity.rare)
                rare.Add(obj);

            if (obj.rarity == EInventoryObjectRarity.epic)
                epic.Add(obj);
        }

        InventoryObject[] arrNone = none.ToArray();
        InventoryObject[] arrCommon = common.ToArray();
        InventoryObject[] arrRare = rare.ToArray();
        InventoryObject[] arrEpic = epic.ToArray();


        for (int i = 0; i < arrNone.Length; i++)
        {
            for (int j = i; j < arrNone.Length; j++)
            {
                if (arrNone[i].count < arrNone[j].count)
                {
                    InventoryObject io = arrNone[i];
                    arrNone[i] = arrNone[j];
                    arrNone[j] = io;
                }
            }
        }

        for (int i = 0; i < arrCommon.Length; i++)
        {
            for (int j = i; j < arrCommon.Length; j++)
            {
                if (arrCommon[i].count < arrCommon[j].count)
                {
                    InventoryObject io = arrCommon[i];
                    arrCommon[i] = arrCommon[j];
                    arrCommon[j] = io;
                }
            }
        }

        for (int i = 0; i < arrRare.Length; i++)
        {
            for (int j = i; j < arrRare.Length; j++)
            {
                if (arrRare[i].count < arrRare[j].count)
                {
                    InventoryObject io = arrRare[i];
                    arrRare[i] = arrRare[j];
                    arrRare[j] = io;
                }
            }
        }

        for (int i = 0; i < arrEpic.Length; i++)
        {
            for (int j = i; j < arrEpic.Length; j++)
            {
                if (arrEpic[i].count < arrEpic[j].count)
                {
                    InventoryObject io = arrEpic[i];
                    arrEpic[i] = arrEpic[j];
                    arrEpic[j] = io;
                }
            }
        }


        List<InventoryObject> objects = new List<InventoryObject>();
        objects.AddRange(arrNone);
        objects.AddRange(arrCommon);
        objects.AddRange(arrRare);
        objects.AddRange(arrEpic);

        return new InventoryObjects(objects.ToArray());
    }

    public static InventoryObject GetRandomClone(EInventoryObjectRarity rarity, int count)
    {
        List<InventoryObject> none = new List<InventoryObject>();
        List<InventoryObject> common = new List<InventoryObject>();
        List<InventoryObject> rare = new List<InventoryObject>();
        List<InventoryObject> epic = new List<InventoryObject>();

        foreach (InventoryObject obj in CheckInventory(null).inventoryObjects)
        {
            if (obj.rarity == EInventoryObjectRarity.none)
                none.Add(obj);

            if (obj.rarity == EInventoryObjectRarity.common)
                common.Add(obj);

            if (obj.rarity == EInventoryObjectRarity.rare)
                rare.Add(obj);

            if (obj.rarity == EInventoryObjectRarity.epic)
                epic.Add(obj);
        }

        InventoryObject[] arrNone = none.ToArray();
        InventoryObject[] arrCommon = common.ToArray();
        InventoryObject[] arrRare = rare.ToArray();
        InventoryObject[] arrEpic = epic.ToArray();

        InventoryObject inventoryObject;
        switch (rarity)
        {
            case EInventoryObjectRarity.none:
                inventoryObject = arrNone[UnityEngine.Random.Range(0, arrNone.Length)];
                break;

            case EInventoryObjectRarity.common:
                inventoryObject = arrCommon[UnityEngine.Random.Range(0, arrCommon.Length)];
                break;

            case EInventoryObjectRarity.rare:
                inventoryObject = arrRare[UnityEngine.Random.Range(0, arrRare.Length)];
                break;

            case EInventoryObjectRarity.epic:
                inventoryObject = arrEpic[UnityEngine.Random.Range(0, arrEpic.Length)];
                break;

            default:
                throw new NotImplementedException();
        }

        inventoryObject = inventoryObject.Clone();
        inventoryObject.count = count;
        return inventoryObject;
    }

    public static Chest GenerateChest(EInventoryChestType chest)
    {
        switch (chest)
        {
            case EInventoryChestType.small:
                return GenerateSmallChest();

            case EInventoryChestType.middle:
                return GenerateMiddleChest();

            case EInventoryChestType.big:
                return GenerateBigChest();
        }

        throw new NotImplementedException();
    }

    private static Chest GenerateSmallChest()
    {
        Chest chestData = new Chest();
        chestData.chestType = EInventoryChestType.small;

        chestData.gems = 100;

        int iterations = 400;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 70)
            {
                chestData.gems += 1;
            }
        }

        iterations = 10;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 20)
            {
                chestData.energy += 1;
            }
        }

        iterations = 1;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 5)
            {
                chestData.keys += 1;
            }
        }

        iterations = 1;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 5)
            {
                chestData.InventoryObjects.TryAdd(new InventoryObject(Fuel, EInventoryObjectRarity.none, 1));
            }
        }

        iterations = 1;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 5)
            {
                chestData.InventoryObjects.TryAdd(new InventoryObject(ToolBox, EInventoryObjectRarity.none, 1));
            }
        }

        chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.common, 3));

        iterations = 7;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 50)
            {
                chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.common, 1));
            }
        }

        iterations = 2;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 30)
            {
                chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.rare, 1));
            }
        }

        iterations = 1;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 10)
            {
                chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.epic, 1));
            }
        }

        return chestData;
    }

    private static Chest GenerateMiddleChest()
    {
        Chest chestData = new Chest();
        chestData.chestType = EInventoryChestType.middle;

        chestData.gems = 1000;

        int iterations = 2000;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 70)
            {
                chestData.gems += 1;
            }
        }

        iterations = 20;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 20)
            {
                chestData.energy += 1;
            }
        }

        iterations = 2;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 5)
            {
                chestData.keys += 1;
            }
        }

        iterations = 2;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 5)
            {
                chestData.InventoryObjects.TryAdd(new InventoryObject(Fuel, EInventoryObjectRarity.none, 1));
            }
        }

        iterations = 2;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 5)
            {
                chestData.InventoryObjects.TryAdd(new InventoryObject(ToolBox, EInventoryObjectRarity.none, 1));
            }
        }

        chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.common, 15));

        iterations = 35;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 50)
            {
                chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.common, 1));
            }
        }

        chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.rare, 3));

        iterations = 7;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 30)
            {
                chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.rare, 1));
            }
        }

        iterations = 5;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 10)
            {
                chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.epic, 1));
            }
        }

        return chestData;
    }

    private static Chest GenerateBigChest()
    {
        Chest chestData = new Chest();
        chestData.chestType = EInventoryChestType.big;

        chestData.gems = 2000;

        int iterations = 3000;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 70)
            {
                chestData.gems += 1;
            }
        }

        iterations = 30;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 20)
            {
                chestData.energy += 1;
            }
        }

        iterations = 3;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 5)
            {
                chestData.keys += 1;
            }
        }

        iterations = 3;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 5)
            {
                chestData.InventoryObjects.TryAdd(new InventoryObject(Fuel, EInventoryObjectRarity.none, 1));
            }
        }

        iterations = 3;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 5)
            {
                chestData.InventoryObjects.TryAdd(new InventoryObject(ToolBox, EInventoryObjectRarity.none, 1));
            }
        }

        chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.common, 75));

        iterations = 175;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 50)
            {
                chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.common, 1));
            }
        }

        chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.rare, 15));

        iterations = 35;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 30)
            {
                chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.rare, 1));
            }
        }

        chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.epic, 3));

        iterations = 7;
        while (iterations-- > 0)
        {
            if (UnityEngine.Random.Range(0, 100) + 1 <= 10)
            {
                chestData.InventoryObjects.TryAdd(GetRandomClone(EInventoryObjectRarity.epic, 1));
            }
        }

        return chestData;
    }


    public class Chest
    {
        public EInventoryChestType chestType;
        public int gems = 0;
        public int energy = 0;
        public int keys = 0;
        public InventoryObjects InventoryObjects = new InventoryObjects();

        public int Count()
        {
            int count = 0;
            if (gems > 0)
                count++;

            if (energy > 0)
                count++;

            if (keys > 0)
                count++;

            count += InventoryObjects.inventoryObjects.Length;


            return count;
        }
    }



    public static InventoryObjects GenerateUpgrade(InventoryObjects all, PlayerData.CarData.Level level)
    {
        int max = 8;
        UpgradeSet set = GetUpgradeSet(level);


        int epicCount = set.epic <= 0 ? 0 : Mathf.Clamp(UnityEngine.Random.Range(1, set.epic % 2), 1, 2);
        
        int rareCount = set.rare <= 0 ? 0 : Mathf.Clamp(UnityEngine.Random.Range(1, set.rare % 3), 1, 3);
        
        int commonCount = max - epicCount - rareCount;
        commonCount = commonCount - UnityEngine.Random.Range(0, commonCount - 2);


        InventoryObjects upgradeObjects = new InventoryObjects();

        if (commonCount > 0 && UnityEngine.Random.Range(0, 2) == 0)
        {
            InventoryObject obj = all.GetMaxClone(EInventoryObjectRarity.common);
            int count = Mathf.Clamp(set.common / 3, 1, set.common);
            set.common -= count;
            obj.count = commonCount == 1 ? set.common : count;
            commonCount--;

            upgradeObjects.TryAdd(obj);
        }

        if (rareCount > 0 && UnityEngine.Random.Range(0, 3) == 0)
        {
            InventoryObject obj = all.GetMaxClone(EInventoryObjectRarity.rare);
            int count = Mathf.Clamp(set.rare / 3, 1, set.rare);
            set.rare -= count;
            obj.count = rareCount == 1 ? set.rare : count;
            rareCount--;

            upgradeObjects.TryAdd(obj);
        }

        if (epicCount > 0 && UnityEngine.Random.Range(0, 5) == 0)
        {
            InventoryObject obj = all.GetMaxClone(EInventoryObjectRarity.epic);
            int count = Mathf.Clamp(set.epic / 3, 1, set.epic);
            set.epic -= count;
            obj.count = epicCount == 1 ? set.epic : count;
            epicCount--;

            upgradeObjects.TryAdd(obj);
        }


        while (commonCount >= 1)
        {
            InventoryObject obj = GetRandomClone(EInventoryObjectRarity.common, 0);

            while (upgradeObjects.Contains(obj.location))
            {
                obj = GetRandomClone(EInventoryObjectRarity.common, 0);
            }

            if (commonCount == 1)
            {
                obj.count = set.common;
                set.common = 0;
            }
            else
            {
                int count = UnityEngine.Random.Range(Mathf.Clamp(set.common / commonCount / 2, 1, set.common), set.common / commonCount);
                obj.count = count;
                set.common -= count;
            }
            upgradeObjects.TryAdd(obj);

            commonCount--;
        }


        while (rareCount >= 1)
        {
            InventoryObject obj = GetRandomClone(EInventoryObjectRarity.rare, 0);

            while (upgradeObjects.Contains(obj.location))
            {
                obj = GetRandomClone(EInventoryObjectRarity.rare, 0);
            }

            if (rareCount == 1)
            {
                obj.count = set.rare;
                set.rare = 0;
            }
            else
            {
                int count = UnityEngine.Random.Range(Mathf.Clamp(set.rare / rareCount / 2, 1, set.rare), set.rare / rareCount);
                obj.count = count;
                set.rare -= count;
            }
            upgradeObjects.TryAdd(obj);

            rareCount--;
        }


        while (epicCount >= 1)
        {
            InventoryObject obj = GetRandomClone(EInventoryObjectRarity.epic, 0);

            while (upgradeObjects.Contains(obj.location))
            {
                obj = GetRandomClone(EInventoryObjectRarity.epic, 0);
            }

            if (commonCount == 1)
            {
                obj.count = set.epic;
                set.epic = 0;
            }
            else
            {
                int count = UnityEngine.Random.Range(Mathf.Clamp(set.epic / epicCount / 2, 1, set.epic), set.epic / epicCount);
                obj.count = count;
                set.epic -= count;
            }
            upgradeObjects.TryAdd(obj);

            epicCount--;
        }



        return upgradeObjects;
    }

    public class UpgradeSet
    {
        public int common;
        public int rare;
        public int epic;



        public UpgradeSet(int common, int rare, int epic)
        {
            this.common = common;
            this.rare = rare;
            this.epic = epic;
        }
    }

    public static UpgradeSet GetUpgradeSet(PlayerData.CarData.Level level)
    {
        switch(level)
        {
            case PlayerData.CarData.Level.zero:
                return new UpgradeSet(15, 3, 0);


            case PlayerData.CarData.Level.one:
                return new UpgradeSet(35, 5, 0);


            case PlayerData.CarData.Level.two:
                return new UpgradeSet(50, 8, 0);


            case PlayerData.CarData.Level.three:
                return new UpgradeSet(45, 9, 1);


            case PlayerData.CarData.Level.four:
                return new UpgradeSet(60, 12, 1);


            case PlayerData.CarData.Level.five:
                return new UpgradeSet(60, 12, 2);


            case PlayerData.CarData.Level.six:
                return new UpgradeSet(70, 15, 2);


            case PlayerData.CarData.Level.seven:
                return new UpgradeSet(60, 17, 3);


            case PlayerData.CarData.Level.eight:
                return new UpgradeSet(50, 18, 4);


            case PlayerData.CarData.Level.nine:
                return new UpgradeSet(35, 20, 5);

            default:
                throw new NotImplementedException();
        }
    }

    public enum EInventoryChestType
    {
        small, middle, big,
    }

    public static Color GetColor(EInventoryObjectRarity rarity)
    {
        switch (rarity)
        {
            case Inventory.EInventoryObjectRarity.none:
                return new Color(0f, 0f, 0f, 0f);

            case Inventory.EInventoryObjectRarity.common:
                return new Color(150f / 255f, 150f / 255f, 150f / 255f, 1f);

            case Inventory.EInventoryObjectRarity.rare:
               return new Color(1f, 120f / 255f, 20f / 255f, 1f);

            case Inventory.EInventoryObjectRarity.epic:
                return new Color(1f, 40f / 255f, 20f / 255f, 1f);
        }

        throw new NotImplementedException();
    }
}