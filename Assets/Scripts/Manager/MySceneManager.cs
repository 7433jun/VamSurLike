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

        // �ε� ȭ���� Ȱ��ȭ
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        Slider slider = loadingScreen.GetComponentInChildren<Slider>();

        // ���� ���� �񵿱������� �ε�
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(nextSceneName);
        loadOperation.allowSceneActivation = false; // ���� �ٷ� Ȱ��ȭ���� ����

        float startTime = Time.time;

        // �ε��� 90%���� �Ϸ�Ǹ� Ȱ��ȭ
        while (!loadOperation.isDone)
        {
            // ���� ��Ȳ�� 0���� 0.9 ������ ������ ����ȭ
            float normalizedProgress = Mathf.Clamp01(loadOperation.progress / 0.9f) * 0.1f;

            // �ǵ������� 1�� �� �ø���
            float additionalProgress = Mathf.Clamp01((Time.time - startTime) / 1.0f) * 0.9f;
            float progress = Mathf.Clamp01(normalizedProgress + additionalProgress);

            // �ε� �� ������Ʈ
            slider.value = progress;

            // �ε��� 90% �̻��� �� Ȱ��ȭ
            if (progress >= 0.999f)
            {
                loadOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
