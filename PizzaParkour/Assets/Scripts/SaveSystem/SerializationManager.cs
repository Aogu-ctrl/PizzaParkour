using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationManager
{
    public static string SAVE_DIRECTORY_PATH = Application.persistentDataPath + "/saves/";
    public static string SAVE_FILE_EXTENSION = ".pizza";

    public static BinaryFormatter formatter = new BinaryFormatter();

    public static bool Save(string saveName, object saveData)
    {
        if (!Directory.Exists(SAVE_DIRECTORY_PATH))
        {
            Directory.CreateDirectory(SAVE_DIRECTORY_PATH);
        }

        string path = SAVE_DIRECTORY_PATH + saveName + SAVE_FILE_EXTENSION;
        FileStream file = File.Create(path);
        formatter.Serialize(file, saveData);
        file.Close();
        Debug.LogFormat("File save at {0}.", path);
        return true;
    }

    public static object Load(string saveName)
    {
        string path = SAVE_DIRECTORY_PATH + saveName + SAVE_FILE_EXTENSION;
        if (!File.Exists(path))
        {
            Debug.LogErrorFormat("File at {0} does not exist.", path);
            return null;
        }

        Debug.LogFormat("File at {0} exists.", path);
        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            SaveData saveData = (SaveData) save;
            Debug.Log(saveData.isLevelCompleted[Level.Staircase]);
            Debug.Log(saveData.isLevelCompleted[Level.ParkingLot]);
            Debug.Log(saveData.isLevelCompleted[Level.DarkRoom]);
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}.", path);
            return null;
        }
        finally
        {
            file.Close();
        }
    }
}
