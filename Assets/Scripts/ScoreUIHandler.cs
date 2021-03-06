using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class ScoreUIHandler : UIHandler
{
    public Text ScorePrefab;
    public GameObject ScoreContainer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < DataManager.Instance.ScoreList.Count; i++)
        {
            Text scoreText = Instantiate(ScorePrefab, ScorePrefab.transform.position, Quaternion.identity);
            scoreText.text = $"{DataManager.Instance.ScoreList[i].Name} : {DataManager.Instance.ScoreList[i].Value}";
            scoreText.transform.SetParent(ScoreContainer.transform);
        }
    }

    // Clear the scole list
    public void ClearScore()
    {
        DataManager.Instance.ScoreList = new List<DataManager.ScoreEntry>();
        DataManager.Instance.SaveScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

