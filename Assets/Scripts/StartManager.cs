using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class StartManager : MonoBehaviour
{
    public static StartManager Instance;

    public int BestScore = 0;

    private void Awake(){
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    // Update is called once per frame
    [System.Serializable]
    class SaveData
    {
        public int BestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
        }
    }
    
}
