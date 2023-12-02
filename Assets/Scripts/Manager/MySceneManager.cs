using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MySceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator LoadSceneAsync(string nextSceneName)
    {
        GameObject loadingScreen = Instantiate(Resources.Load<GameObject>("Loading Screen"), GameObject.Find("Canvas").transform);

        // 로딩 화면을 활성화
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        Slider slider = loadingScreen.GetComponentInChildren<Slider>();

        // 다음 씬을 비동기적으로 로드
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(nextSceneName);
        loadOperation.allowSceneActivation = false; // 씬을 바로 활성화하지 않음

        float startTime = Time.time;

        // 로딩이 90%까지 완료되면 활성화
        while (!loadOperation.isDone)
        {
            // 진행 상황을 0에서 0.9 사이의 값으로 정규화
            float normalizedProgress = Mathf.Clamp01(loadOperation.progress / 0.9f) * 0.1f;

            // 의도적으로 1초 더 늘리기
            float additionalProgress = Mathf.Clamp01((Time.time - startTime) / 1.0f) * 0.9f;
            float progress = Mathf.Clamp01(normalizedProgress + additionalProgress);

            // 로딩 바 업데이트
            slider.value = progress;

            // 로딩이 90% 이상일 때 활성화
            if (progress >= 0.999f)
            {
                loadOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
