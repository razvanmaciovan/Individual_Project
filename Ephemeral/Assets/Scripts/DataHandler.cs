using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataHandler
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.rtd";
        FileStream fs = new FileStream(path, FileMode.Create);

        PlayerData playerData = new PlayerData(player);

        formatter.Serialize(fs, playerData);
        fs.Close();
    }   

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.rtd";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path,FileMode.Open);

            PlayerData data = binaryFormatter.Deserialize(fs) as PlayerData;
            fs.Close();
            return data;
            
        }
        else
        {
           Debug.LogError("Save file not found in " + path);
           return null;
        }
    }
}
