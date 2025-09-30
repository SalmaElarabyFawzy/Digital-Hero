using UnityEngine;
using TMPro;
public class PasswordField : MonoBehaviour
{
    public TextMeshProUGUI[]  passwordCells;
    private int _currentIndex = 0;
    public void AddCharacter(string character)
    {
        if (_currentIndex < passwordCells.Length)
        {
            passwordCells[_currentIndex].text = character;
            _currentIndex++;
        }
    }
    
    public void RemoveCharacters()
    {
        foreach (var character in passwordCells)
        {
            character.text = "";
        }
    }
}
