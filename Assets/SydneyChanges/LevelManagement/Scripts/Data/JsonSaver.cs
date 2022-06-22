using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Security.Cryptography;

namespace LevelManagement.Data
{
    public class JsonSaver
    {
        private static readonly string _filename = "saveData1.sav";

        public static string GetSaveFilename()
        {
            return Application.persistentDataPath + "/" + _filename;
        }

        public void Save(SaveData data)
        {
            data.hashValue = String.Empty;

            string json = JsonUtility.ToJson(data);

            data.hashValue = GetSHA256(json);
            json = JsonUtility.ToJson(data);

            string saveFilename = GetSaveFilename();

            FileStream fileStream = new FileStream(saveFilename, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        public bool Load(SaveData data)
        {
            string loadFilename = GetSaveFilename();
            if (File.Exists(loadFilename))
            {
                using (StreamReader reader = new StreamReader(loadFilename))
                {
                    string json = reader.ReadToEnd();

                    if (CheckData(json))
                    {
                        JsonUtility.FromJsonOverwrite(json, data);
                    }
                    else
                    {
                        Debug.LogWarning("JSONSAVER Load: invalid hash. Aborting file read...");
                    }
                }
                return true;
            }
            return false;
        }

        private bool CheckData(string json)
        {
            SaveData tempSaveData = new SaveData();
            JsonUtility.FromJsonOverwrite(json, tempSaveData);

            string oldHash = tempSaveData.hashValue;
            tempSaveData.hashValue = String.Empty;

            string tempJson = JsonUtility.ToJson(tempSaveData);
            string newHash = GetSHA256(tempJson);

            return (oldHash == newHash);
        }

        public void Delete()
        {
            File.Delete(GetSaveFilename());
        }

        public string GetHexStringFromHash(byte[] hash)
        {
            string hexString = String.Empty;

            foreach(byte b in hash)
            {
                hexString += b.ToString("x2");
            }
            return hexString;
        }

        private string GetSHA256(string text)
        {
            byte[] textToByte = Encoding.UTF8.GetBytes(text);
            SHA256Managed mySHA256 = new SHA256Managed();

            byte[] hashValue = mySHA256.ComputeHash(textToByte);

            return GetHexStringFromHash(hashValue);
        }
    } 
}
