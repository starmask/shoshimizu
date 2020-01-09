using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用
    Slider _slider;

    // Use this for initialization
    void Start()
    {
        step_time = 0.0f;       // 経過時間初期化
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    float _hp = 0;
    // Update is called once per frame
    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 1秒後に画面遷移（scene2へ移動）
        if (step_time >= 5.0f)
        {
            SceneManager.LoadScene("field");
        }

        _hp = step_time/5.0f;
        if (_hp > 1)
        {
            // 最大を超えたら0に戻す
            _hp = 1;
        }

        // HPゲージに値を設定
        _slider.value = _hp;
    }
}

