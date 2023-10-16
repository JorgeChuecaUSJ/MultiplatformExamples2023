using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemInClass
{
    static string Path { get { return Application.persistentDataPath + "/player.funny"; } }

    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(Path, FileMode.Create);

        bf.Serialize(fs, new PlayerDataInClass(player));

        fs.Close();
    }

    public static PlayerDataInClass LoadPlayer()
    {
        if (File.Exists(Path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Path, FileMode.Open);

            PlayerDataInClass playerData = bf.Deserialize(fs) as PlayerDataInClass;
            fs.Close();

            return playerData;
        }
        else
        {
            Debug.LogError("Could not find file: " + Path);
            return null;
        }
    }

}

[Serializable]
public class PlayerDataInClass
{
    public string name;
    public Vector3S position;
    public QuaternionS rotation;
    public int score;

    public PlayerDataInClass(PlayerController player) 
    { 
        name = player.m_PlayerName;
        position = new Vector3S(player.transform.position);
        rotation = new QuaternionS(player.transform.rotation);
        score = player.m_Score;
    }
}

[Serializable]
public class Vector3S
{
    float x, y, z;

    public Vector3S(Vector3 vector3)
    {
        x = vector3.x;
        y = vector3.y;
        z = vector3.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}

[Serializable]
public class QuaternionS
{
    float x, y, z, w;

    public QuaternionS(Quaternion quat)
    {
        x = quat.x;
        y = quat.y;
        z = quat.z;
        w = quat.w;
    }

    public Quaternion ToQuaternion()
    {
        return new Quaternion(x, y, z, w);
    }
}
