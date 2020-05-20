using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        AsyncOperation asyncOper = SceneManager.LoadSceneAsync("Title");
        asyncOper.completed += (obj) =>
        {
            var title = GameObject.FindObjectOfType<Title>();
            Debug.LogFormat("title: {0}", title);
            title.Init();
        };


    }

}
