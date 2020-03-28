using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationManager
{
    public static string SAVE_DIRECTORY_PATH = Application.persistentDataPath + "/saves/";
    public static string SAVE_FILE_NAME = "Save.pizza";
    public static string SAVE_PATH = SAVE_DIRECTORY_PATH + SAVE_FILE_NAME;

    public static BinaryFormatter formatter = new BinaryFormatter();

    public static bool Save(object saveData)
    {
        if (!Directory.Exists(SAVE_DIRECTORY_PATH))
        {
            Directory.CreateDirectory(SAVE_DIRECTORY_PATH);
        }

        FileStream file = File.Create(SAVE_PATH);
        formatter.Serialize(file, saveData);
        file.Close();
        Debug.LogFormat("File save at {0}.", SAVE_PATH);
        return true;
    }

    public static object Load()
    {
        if (!File.Exists(SAVE_PATH))
        {
            Debug.LogErrorFormat("File at {0} does not exist.", SAVE_PATH);
            return null;
        }

        Debug.LogFormat("File at {0} exists.", SAVE_PATH);
        FileStream file = File.Open(SAVE_PATH, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            SaveData saveData = (SaveData) save;
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}.", SAVE_PATH);
            return null;
        }
        finally
        {
            file.Close();
        }
    }

    public static void Delete()
    {
        if (File.Exists(SAVE_PATH))
        {
            Debug.LogFormat("File at {0} deleted.", SAVE_PATH);
            File.Delete(SAVE_PATH);
        }
    }

    public static bool SaveExists()
    {
        return File.Exists(SAVE_PATH);
    }
}
