using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] LeaderboardManager leaderboardManager;

    private void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    private IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboardManager.FetchTopHighScoresRoutine();
    }

    private IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerId", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start LootLocker session");
                done = true;
            }
        });

        yield return new WaitWhile(() => done == false);
    }

    public void SetPlayerName(string playerName)
    {
        LootLockerSDKManager.SetPlayerName(playerName, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully set player name");
            }
            else
            {
                Debug.Log("Could not set player name: " + response.Error);
            }
        });
    }
}
