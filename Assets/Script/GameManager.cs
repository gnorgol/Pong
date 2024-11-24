using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Ball ball;  // Référence à l'objet Balle
    public Transform playerPaddle;  // Référence à la raquette du joueur
    public Transform aiPaddle;  // Référence à la raquette de l'IA

    public TextMeshProUGUI playerScoreText;  // UI pour le score du joueur
    public TextMeshProUGUI aiScoreText;  // UI pour le score de l'IA

    private int playerScore = 0;
    private int aiScore = 0;
    public static GameManager Instance { get; private set; }

    public Button startGameButton;

    public bool isGameStarted = false;

    private void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
        ResetGame();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
         
    }

    public void PlayerScores()
    {
        playerScore++;
        UpdateScoreUI();
        ResetBall();
    }

    public void AIScores()
    {
        aiScore++;
        UpdateScoreUI();
        ResetBall();
    }

    private void UpdateScoreUI()
    {
        playerScoreText.text = playerScore.ToString();
        aiScoreText.text = aiScore.ToString();
    }

    private void ResetBall()
    {
        // Remet la balle au centre et relance le jeu
        ball.ResetBall();
    }

    private void ResetGame()
    {
        playerScore = 0;
        aiScore = 0;
        UpdateScoreUI();
        ResetBall();
    }
    private void StartGame()
    {
        Time.timeScale = 1;
        isGameStarted = true;
        startGameButton.gameObject.SetActive(false);
    }

}
