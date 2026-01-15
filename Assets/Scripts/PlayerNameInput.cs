using UnityEngine;
using Photon.Pun; // Needed for PhotonNetwork
using TMPro; // Needed for TMP_InputField

public class PlayerNameInput : MonoBehaviour
{
    const string playerNamePrefKey = "PlayerName";
    private TMP_InputField mInputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string defaultName = string.Empty;
        mInputField = this.GetComponent<TMP_InputField>();

        if (mInputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                mInputField.text = defaultName;
            }
        }
        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName()
    {
        string value = mInputField.text;
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }
        
        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString(playerNamePrefKey, value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
