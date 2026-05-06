using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_InputField inputField;

    public Button gameStartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameStartButton.onClick.AddListener(OnGameStartBottonClicked);
    }

    // Update is called once per frame
    public void OnGameStartBottonClicked()
    {
        string playerName = inputField.text;
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("플레이어의 이름을 입력하세요.");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        Debug.Log("플레이어 이름 저장 됨: " + playerName);

        SceneManager.LoadScene("Level_1");
        
    }
}
