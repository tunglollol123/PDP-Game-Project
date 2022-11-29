using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharDataBase : ScriptableObject
{
    public Character[] Char;

    public int CharactersCount
    {
        get { return Char.Length; }
    }
    public Character GetCharacter(int index)
    {
        return Char[index];
    }
}
