using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSet : RandomizableSet
{
    public Antity map;
    public int towersCount;
    public TowerSet[] towers;
    public int monstersCount;
    public MonsterSet[] monsters;
    public int objectsCount;
    public ObjSet[] objects;
    public AudioClip music;
    public int playerSpeed;
    
}