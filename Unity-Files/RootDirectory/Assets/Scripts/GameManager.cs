using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Ball ball;
    public Text playerScoreText;
    public Text computerScoreText;
    public Paddle playerPaddle;
    public Paddle computerPaddle;

    private int _playerScore;
    private int _computerScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

    }

    public void PlayerScores()
    {
        _playerScore++;

        this.playerScoreText.text = _playerScore.ToString();
        resetRound();
    }

    public void ComputerScores()
    {
        _computerScore++;

        this.computerScoreText.text = _computerScore.ToString();
        resetRound();
    }    
    
    private void resetRound()
    {
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
    }

}
