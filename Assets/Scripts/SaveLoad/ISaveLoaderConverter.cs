
public interface ISaveLoaderConverter
{
    string Convert(PlayerData playerData);

    PlayerData Convert(string data);
}