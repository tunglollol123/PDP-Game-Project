using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Properties
{
    public string CharName;
    public Sprite CharSprite;
}

[CreateAssetMenu]
public class CharDataBase : ScriptableObject
{
    public Properties[] Char;


    public int CharactersCount
    {
        get { return Char.Length; }
    }
    public Properties GetCharacter(int index)
    {
        return Char[index];
    }
}
