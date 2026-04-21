using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 데스씬을 2초 보여준 뒤 ReturnToGame 함수 실행
        Invoke(nameof(ReturnToGame), 2.0f);
    }

    void ReturnToGame()
    {
        // [추가] 아까 저장했던 스테이지 번호를 꺼내옵니다.
        // 만약 저장된 게 없다면(기본값) 0번 씬으로 가게 설정합니다.
        int lastIndex = PlayerPrefs.GetInt("LastScene", 0);

        // 불러온 번호의 씬으로 다시 이동!
        SceneManager.LoadScene(lastIndex);
    }
}
