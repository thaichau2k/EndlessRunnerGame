using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  bool gameHasEnded = false;
  public AirplaneController airplane;
  private float timeScore = 0;
  public Text timeScoreText;

  private void Update()
  {
    timeScore += Time.deltaTime;
    timeScoreText.text = timeScore.ToString("0");
  }
  public void GameOver(float restartDelay)
  {
    if (gameHasEnded == false)
    {
      gameHasEnded = true;
      Invoke("Restart", restartDelay);
    }
  }

  void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
