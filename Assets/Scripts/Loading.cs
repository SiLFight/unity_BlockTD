using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

    public Text text;
    public Slider slider;

    AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        async =  SceneManager.LoadSceneAsync("GameScene");

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = async.progress;
        text.text = "游戏加载中..." + (int)async.progress * 100 + "%"; 
    }


}
