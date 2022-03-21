using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }
    public Vector3 MainCameraPosition { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }
    public void ReloadScene()
    {
        MainCameraPosition = Camera.main.transform.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
