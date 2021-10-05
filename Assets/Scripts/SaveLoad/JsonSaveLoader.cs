using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSaveLoader : ISaveLoader
{
    private bool _isFirstLoad = false;



    public bool isFirstLoad => _isFirstLoad;



    public void Save(PlayerData playerData, string fileName)
    {
        string save = Convert(playerData);


        File.WriteAllText(GetAllPath(fileName), save);
    }

    public PlayerData Load(string fileName)
    {
        if (File.Exists(GetAllPath(fileName)))
        {
            string data = File.ReadAllText(GetAllPath(fileName));
            _isFirstLoad = false;


            return Convert(data);
        }
        else
        {
            _isFirstLoad = true;


            return new PlayerData();
        }
    }


    public string Convert(PlayerData playerData)
    {
        string dat = JsonUtility.ToJson(playerData);

        Data data = new Data(Data.ESerialization.one, dat);


        return JsonUtility.ToJson(data);
    }

    public PlayerData Convert(string data)
    {
        Data dat = JsonUtility.FromJson<Data>(data);


        return JsonUtility.FromJson<PlayerData>(dat.decriptedData);
    }



    private string GetAllPath(string fileName)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
    return Path.Combine(Application.persistentDataPath, fileName);
#elif UNITY_EDITOR || UNITY_STANDALONE_WIN
        return Path.Combine(Application.dataPath, fileName);
#endif
    }
}