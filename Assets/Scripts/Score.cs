using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    private double _score;

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
    }
}
