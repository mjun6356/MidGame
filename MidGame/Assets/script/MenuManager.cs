using UnityEngine;
using UnityEngine.SceneManagement; // 씬을 넘어가기 위해 꼭 필요한 코드예요!

public class MenuManager : MonoBehaviour
{
    // 방금 만든 도움말 창을 연결할 변수예요.
    public GameObject helpPanel;

    // 1. '게임 시작' 버튼을 누르면 실행될 함수
    public void StartGame()
    {
        // "GameScene"이라는 이름의 씬으로 넘어갑니다.
        // (괄호 안의 이름은 학생이 만든 실제 게임 화면 씬 이름으로 꼭 바꿔주세요!)
        SceneManager.LoadScene("Level_1");
    }

    // 2. '도움말' 버튼을 누르면 실행될 함수
    public void ShowHelp()
    {
        // 도움말 창을 화면에 보이게 켭니다.
        helpPanel.SetActive(true);
    }

    // 3. 도움말 창을 닫고 싶을 때 쓸 함수 (보너스!)
    public void CloseHelp()
    {
        // 도움말 창을 다시 안 보이게 끕니다.
        helpPanel.SetActive(false);
    }
    public void QuitGame()
    {
        // 유니티 에디터 안에서는 게임이 실제로 꺼지지 않기 때문에, 로그를 띄워서 버튼이 잘 눌렸는지 확인합니다.
        Debug.Log("게임을 종료합니다!");

        // 실제 완성된 게임(빌드 파일)에서 게임을 완전히 꺼버리는 마법의 코드!
        Application.Quit();
    }
}