using System.Collections.Generic;

public static class SerializationHelper
{
    const char SepChar = ',';

    public static LinkedList<string> SerializePartyData(LinkedList<PartyCharacter> partyCharacters)
    {
        LinkedList<string> serializedData = new LinkedList<string>();

        foreach (PartyCharacter pc in partyCharacters)
        {
            string concatenatedString = Concatenate(
                SaveDataSignifiers.PartyCharacter.ToString(),
                pc.classID.ToString(), pc.health.ToString(),
                pc.mana.ToString(), pc.strength.ToString(),
                pc.agility.ToString(), pc.wisdom.ToString());

            serializedData.AddLast(concatenatedString);

            foreach (int e in pc.equipment)
            {
                concatenatedString = Concatenate(SaveDataSignifiers.Equipment.ToString(), e.ToString());
                serializedData.AddLast(concatenatedString);
            }
        }

        return serializedData;
    }

    public static LinkedList<PartyCharacter> DeserializePartyData(LinkedList<string> serializedData)
    {
        LinkedList<PartyCharacter> partyCharacters = new LinkedList<PartyCharacter>();
        PartyCharacter pc = null;

        foreach (string line in serializedData)
        {
            string[] csv = line.Split(SepChar);
            int signifier = int.Parse(csv[0]);

            if (signifier == SaveDataSignifiers.PartyCharacter)
            {
                pc = new PartyCharacter(
                    int.Parse(csv[1]), int.Parse(csv[2]),
                    int.Parse(csv[3]), int.Parse(csv[4]),
                    int.Parse(csv[5]), int.Parse(csv[6]));

                partyCharacters.AddLast(pc);
            }
            else if (signifier == SaveDataSignifiers.Equipment && pc != null)
            {
                pc.equipment.AddLast(int.Parse(csv[1]));
            }
        }

        return partyCharacters;
    }

    private static string Concatenate(params string[] stringsToJoin)
    {
        return string.Join(SepChar.ToString(), stringsToJoin);
    }
}
