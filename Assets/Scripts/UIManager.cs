using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Image[] lives;
    public Text coinText;
    public Text scoreText;
    
    public void UpdateLives(int currentLives) {
        for (int i = 0; i < lives.Length; i++) {
            lives[i].color = currentLives > i ? Color.white : Color.black;
        }
    }

    public void UpdateCoins(int coint) {
        coinText.text = coint.ToString();
    }

    public void UpdateScore(int score) {
        scoreText.text = score.ToString();
    }
}
