using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Classe che si occupa di salvare e caricare i dati di gioco e le impostazioni
public static class SaveSystem
{
    private static readonly string gameDataPath = Application.persistentDataPath + "/data.aesir";

    // Salva un oggetto in un file binario
    private static void Save<T>(T data, string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    // Carica un oggetto da un file binario che verrà castato in seguito dalla funzione chiamante
    private static object Load(string path)
    {
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            object data = formatter.Deserialize(stream);
            stream.Close();
            return data;
        } else {
            return null;
        }
    }


    public static void SavePosition(Vector3 position)
    {
        float[] tmp = {position.x, position.y, position.z};
        Save(tmp, gameDataPath);
    }

    public static Vector3 LoadPosition()
    {
        var data = Load(gameDataPath);

        if (data != null)
        {
            float[] tmp = data as float[];
            return new Vector3(tmp[0], tmp[1], tmp[2]);
        }
        else
        {
            return Vector3.zero;
        }
    }
}
