using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFader : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button btnFadeStart = null;
    [SerializeField] UnityEngine.UI.Button btnSwitchScene = null;
    public string NextScene;
    public GameObject score;
    public GameObject score2;
    public GameObject numscore;     
    public float currentScore;
    public int currentnum;
    // Start is called before the first frame update
    void Start()
    {
    //バトルのシーンから点数を継承する
    currentScore = PlayerPrefs.GetFloat("score");
    currentnum = PlayerPrefs.GetInt("num");
    score.GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString();
    score2.GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString();
    numscore.GetComponent<UnityEngine.UI.Text>().text = currentnum.ToString();

        btnFadeStart.onClick.AddListener(()=>{
            Fader.SwitchScene(NextScene);
        });


        btnSwitchScene.onClick.AddListener(()=>{
            // ボタンが押されたら、フェードアウトして、次のシーンへ切り替える
            Fader.SwitchScene(NextScene);
        });
    }

    void Update() 
    {
        if (Fader.IsEnd){
            // IsEnd プロパティでも終了判定ができます。
        }
    }
}
