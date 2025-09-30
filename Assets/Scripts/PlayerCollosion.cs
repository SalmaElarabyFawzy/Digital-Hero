using UnityEngine;

public class PlayerCollosion : MonoBehaviour
{

    public string password = "";
    public PasswordField passwordField;
    public AudioSource collectSound;
    public AudioSource successSound;
    public AudioSource failureSound;
    private bool _lowerCase = false;
    private bool _upperCase = false;
    private bool _number = false;
    private bool _specialChar = false;
    private void OnTriggerEnter(Collider other)
    {
        if(password.Length >= 15) return;
        if (other.CompareTag("Collectable"))
        {
            string charName = other.gameObject.name;
            passwordField.AddCharacter(other.gameObject.name);
            password += other.gameObject.name;
            if(charName == "!" || charName == "?" || charName == "$")
                _specialChar = true;
            else if(charName == charName.ToUpper())
                _upperCase = true;
            else if(charName == charName.ToLower())
                _lowerCase = true;
            else if(int.TryParse(charName, out int n))
                _number = true;
            PlayCollectSound();
            Debug.Log(password);
            Destroy(other.gameObject);
            if (password.Length >= 15)
            {
                if (IsValidPassword()) 
                    successSound.Play();
                else
                    failureSound.Play();
                    
            }
        }
    }
    public bool IsValidPassword()
    {
        return password.Length >= 15 && _lowerCase && _upperCase && _number && _specialChar;
    }
    
    private void PlayCollectSound()
    {
        if (collectSound != null)
        {
            collectSound.Play();
        }
    }
}
