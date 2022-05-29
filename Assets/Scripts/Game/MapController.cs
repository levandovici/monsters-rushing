using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private int _mapLength = 3;

    private float _nextMapPosition = 0;
    private List<Antity> _map = new List<Antity>();
    private List<Obj> _allObjects = new List<Obj>();
    private Car _player;

    [SerializeField]
    private Car[] _cars;
    [SerializeField]
    private LevelSet[] _levels;
    [SerializeField]
    private Transform _world;

    private int _waterForDestroy;
    private int _waterForSpecial;
    private int _alivePrice = 1;



    public event Action OnGameOver;
    public event Action<int> OnAddWater;



    public Car Car => _player;

    public int Distance => (int)_player.transform.position.z;

    public int WaterForDestroy => _waterForDestroy;

    public int WaterForSpecial => _waterForSpecial;



    public void AddWater(int destroy, int special)
    {
        _waterForDestroy += destroy;
        _waterForSpecial += special;

        OnAddWater.Invoke(destroy + special);

        Tasks.TasksHelper.Trigger(Tasks.ETaskPoint.collect_water, destroy + special);
    }


    public void SetUp(int index, PlayerData.CarData data)
    {
        ObjectsController.Reset();
        int max = ObjectsController.MaxCount;
        if (max <= 64)
        {
            _mapLength = 2;
        }
        else if (max <= 128)
        {
            _mapLength = 3;
        } 
        else
        {
            _mapLength = 4;
        }

        _player = Instantiate(_cars[index], new Vector3(0f, 2f, 0f), Quaternion.identity, _world);
        _player.SetUp(PlayerData.CarData.GetCarUpgrade(index).CurrentHealth(data.healthLevel),
            PlayerData.CarData.GetCarUpgrade(index).CurrentDamage(data.damageLevel),
            PlayerData.CarData.GetCarUpgrade(index).CurrentCapacity(data.capacityLevel),
            PlayerData.CarData.GetCarUpgrade(index).CurrentFuel(data.fuelLevel));
        
        _player.OnGameOver += OnGameOver.Invoke;

        StartCoroutine(Builder());
    }

    public void Alive()
    {
        _player.Alive();
    }

    public void FillUp()
    {
        _player.FillUp();
    }



    private IEnumerator Builder()
    {
        while (true)
        {
            List<Antity> normal = new List<Antity>();

            foreach(Antity g in _map)
            {
                if (g.transform.position.z + 75f >= _player.transform.position.z)
                {
                    normal.Add(g);
                }
                else
                {
                    ObjectsController.DestroyAntity(g);
                    Destroy(new Vector3(-50f, 0f, -100f), new Vector3(50f, 0f, g.transform.position.z + 50f));
                }
            }

            _map = normal;

            for (int i = 0; i < _mapLength - _map.Count; i++)
            {
                Spawn();
            }

            yield return null;
        }
    }



    private void Spawn()
    {
        float mapPosition = _nextMapPosition;
        _nextMapPosition += 100f;

        if (mapPosition <= 0f)
            _player.transform.position = new Vector3(0f, 2f, 0f);


        LevelSet ls = null;
        if (mapPosition / 1000f >= _levels.Length)
        {
            ls = RandomizableSet.GetRandom(_levels);
        }
        else
        {
            ls = _levels[(int)mapPosition / 1000];
        }

        Antity map = ObjectsController.InstantiateAntity(ls.map, new Vector3(0f, 0f, mapPosition));


        if (mapPosition >= 100f)
        {
            //setting
            //-10 0 10 // -45 45
            int count = ls.objectsCount;
            Table table = new Table(3, 19);

            while (table.isFree() && count > 0)
            {
                Table.Coordinates coordinates = table.RandomCoordinates();
                float w = coordinates.x * 5f;
                float l = coordinates.y * 5f;


                ObjSet set = RandomizableSet.GetRandom(ls.objects);
                Obj o = ObjectsController.InstantiateAntity(set.obj, new Vector3(w, 0f, l + mapPosition)) as Obj;
                o.SetUp(set.health, set.bumpDamage, set.waterPrice);

                _allObjects.Add(o);

                count--;
            }

            count = ls.monstersCount;

            if (count > 0)
            {
                while (table.isFree() && count > 0)
                {
                    Table.Coordinates coordinates = table.RandomCoordinates();
                    float w = coordinates.x * 5f;
                    float l = coordinates.y * 5f;


                    MonsterSet set = RandomizableSet.GetRandom(ls.monsters);

                    if (set != null)
                    {
                        Monster o = ObjectsController.InstantiateAntity(set.obj, new Vector3(w, 0f, l + mapPosition)) as Monster;
                        o.SetUp(set.health, set.bumpDamage, set.waterPrice, set.damage, set.coolDown, set.speed, set.visionRadius);

                        _allObjects.Add(o);
                    }


                    count--;
                }
            }


            count = ls.towersCount;

            if (count > 0)
            {
                while (table.isFree() && count > 0)
                {
                    Table.Coordinates coordinates = table.RandomCoordinates();
                    float w = coordinates.x * 5f;
                    float l = coordinates.y * 5f;


                    TowerSet set = RandomizableSet.GetRandom(ls.towers);
                    Tower o = ObjectsController.InstantiateAntity(set.obj, new Vector3(w, 0f, l + mapPosition)) as Tower;
                    o.SetUp(set.health, set.bumpDamage, set.waterPrice, set.damage, set.coolDown, set.visionRadius);

                    _allObjects.Add(o);

                    count--;
                }
            }
        }


        //spawning bg
        Table left = new Table(4, 19);
        Table right = new Table(4, 19);

        int max = ObjectsController.MaxCount / _mapLength / 2;

        while (left.isFree() && max-- > 0)
        {
            Table.Coordinates coordinates = left.uRandomCoordinates();
            float w = coordinates.x * -5f - 10f;
            float l = coordinates.y * 5f;

            ObjSet set = RandomizableSet.GetRandom(ls.objects);
            if (!set.obj.BGLine1 && coordinates.x == 0)
                continue;

            if (!set.obj.BGLine2 && coordinates.x == 1)
                continue;

            if (!set.obj.BGLine3 && coordinates.x == 2)
                continue;

            if (!set.obj.BGLine4 && coordinates.x == 3)
                continue;

            Obj o = ObjectsController.InstantiateAntity(set.obj, new Vector3(w, 0f, l + mapPosition)) as Obj;
            o.SetUp(set.health, set.bumpDamage, set.waterPrice);

            _allObjects.Add(o);
        }

        max = ObjectsController.MaxCount / _mapLength / 2;

        while (right.isFree() && max-- > 0)
        {
            Table.Coordinates coordinates = right.uRandomCoordinates();
            float w = coordinates.x * 5f + 10f;
            float l = coordinates.y * 5f;

            ObjSet set = RandomizableSet.GetRandom(ls.objects);
            if (!set.obj.BGLine1 && coordinates.x == 0)
                continue;

            if (!set.obj.BGLine2 && coordinates.x == 1)
                continue;

            if (!set.obj.BGLine3 && coordinates.x == 2)
                continue;

            if (!set.obj.BGLine4 && coordinates.x == 3)
                continue;

            Obj o = ObjectsController.InstantiateAntity(set.obj, new Vector3(w, 0f, l + mapPosition)) as Obj;
            o.SetUp(set.health, set.bumpDamage, set.waterPrice);

            _allObjects.Add(o);
        }



        _map.Add(map);

        if(ls.playerSpeed > _player.MoveSpeed)
        _player.SetMoveSpeed(ls.playerSpeed);
    }



    public void Destroy(float radius)
    {
        Destroy(radius, _player.transform.position);
    }

    public void Destroy(float radius, Vector3 pos)
    {
        List<Obj> normalObjs = new List<Obj>();

        if (_allObjects != null)
            foreach (Obj go in _allObjects)
                if (go != null)
                    if (Vector3.Distance(go.transform.position, pos) < radius)
                    {
                        go.Kill();
                    }
                    else normalObjs.Add(go);

        _allObjects = normalObjs;
    }

    public void Destroy(Vector3 at, Vector3 to)
    {
        List<Obj> normalObjs = new List<Obj>();

        if (_allObjects != null)
            foreach (Obj go in _allObjects)
                if (go != null)
                {
                    Vector3 pos = go.transform.position;

                        if (pos.x >= at.x && pos.x <= to.x &&
                            pos.z >= at.z && pos.z <= to.z)
                        {
                            ObjectsController.DestroyAntity((Antity)go);
                        }
                        else normalObjs.Add(go);
                }

        _allObjects = normalObjs;
    }



    private void OnDestroy()
    {
        _player.OnGameOver -= OnGameOver.Invoke;
    }
}