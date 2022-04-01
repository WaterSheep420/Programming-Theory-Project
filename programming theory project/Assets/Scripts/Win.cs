using System.Collections;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Win : MonoBehaviour
{
    [SerializeField] private float timeUntilByeBye;
    [SerializeField] private GameObject WinSparkles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinSparkles.SetActive(true);
        StartCoroutine(CloseGame());
    }

    IEnumerator CloseGame()
    {
        AudioManager.Instance.Play("Fireworks");

        yield return new WaitForSeconds(timeUntilByeBye);

        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}
