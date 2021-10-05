


public interface ISaveLoader : ISaveLoaderConverter
{
    bool isFirstLoad { get; }



    PlayerData Load(string fileName);
    void Save(PlayerData data, string fileName);
}