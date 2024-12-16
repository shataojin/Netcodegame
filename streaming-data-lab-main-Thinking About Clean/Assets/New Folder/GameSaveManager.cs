using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class GameSaveManager
{
    const string SaveFileName = "PartySaveData.txt";

    public static void SaveParty()
    {
        LinkedList<string> serializedData = SerializationHelper.SerializePartyData(GameContent.partyCharacters);
        FileHelper.WriteToFile(SaveFileName, serializedData);
        Debug.Log("Party saved successfully!");
    }

    public static void LoadParty()
    {
        if (!File.Exists(SaveFileName))
        {
            Debug.LogError("Save file not found!");
            return;
        }

        LinkedList<string> serializedData = FileHelper.ReadFromFile(SaveFileName);
        GameContent.partyCharacters = SerializationHelper.DeserializePartyData(serializedData);
        GameContent.RefreshUI();
        Debug.Log("Party loaded successfully!");
    }
}
