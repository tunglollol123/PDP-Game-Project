using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharManager : MonoBehaviour
{
    public CharDataBase CharData;

    public TMP_Text NameText;
    public SpriteRenderer SpriteRenderer;

    private int SelectableOption = 1;

    //Start is called before the first frame update
    void Start()
    {
        UpdateCharacter(SelectableOption);
    }

    public void NextOption()
    {
        SelectableOption++;
        Debug.Log(CharData);

        if (SelectableOption >= CharData.CharactersCount)
        {
            SelectableOption = 0;
        }
        UpdateCharacter(SelectableOption);
    }
    public void BackOption()
    {
        SelectableOption--;
        if (SelectableOption < 0)
        {
            SelectableOption = CharData.CharactersCount - 1;
        }
        UpdateCharacter(SelectableOption);
    }

    public void UpdateCharacter(int SelectableOption)
    {
        Debug.Log(SelectableOption);
        Character character = CharData.GetCharacter(SelectableOption);
        SpriteRenderer.sprite = character.CharSprite;
        NameText.text = character.CharName;
    }
}