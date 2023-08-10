using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class BestScoreManager : MonoBehaviour
{
    public Text BestScoreText;
    // Start is called before the first frame update
    void Update(){
        StartManager.Instance.LoadBestScore();
        BestScoreText.text = $"Best Score : {StartManager.Instance.BestScore}";
    }
}
