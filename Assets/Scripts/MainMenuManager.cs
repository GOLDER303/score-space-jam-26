using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInputField;
    [SerializeField] PlayerManager playerManager;

    public void PlayGame()
    {
        if (playerNameInputField.text.Length > 0)
        {
            playerManager.SetPlayerName(playerNameInputField.text);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
