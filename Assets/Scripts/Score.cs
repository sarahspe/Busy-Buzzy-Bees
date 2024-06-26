using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    private double _score;
    private double _endingScore;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null){
            instance = this;
        }
    }

    private void Start(){
        _currentScoreText.text = _score.ToString();
    }


    // Update is called once per frame
    public void UpdateScore()
    {
        _score+=.5;
        _currentScoreText.text = _score.ToString();
        if (_score >= 10){
            SceneManager.LoadScene("endingscene");
        }
    }
}
