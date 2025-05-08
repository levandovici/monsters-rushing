using System.IO;
using UnityEngine;

public class PlayerPrefsSaveLoader : ISaveLoader
{
    private bool _isFirstLoad = false;



    public bool isFirstLoad => _isFirstLoad;



    public void Save(PlayerData playerData, string fileName)
    {
        string save = Convert(playerData);

        PlayerPrefs.SetString(fileName, save);
    }

    public PlayerData Load(string fileName)
    {
        if (PlayerPrefs.HasKey(fileName))
        {
            string data = PlayerPrefs.GetString(fileName);
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
}
