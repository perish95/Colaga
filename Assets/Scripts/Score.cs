using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance = null;
    public int currentScore = 0;

    [SerializeField]
    private Text _scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
        

        _scoreText = GetComponent<Text>();
    }

    private void Start()
    {
        StartCoroutine(AddScore());
    }

    private void Update()
    {
        UpdateScoreText();
    }

    private IEnumerator AddScore()
    {
        while (true)
        {
            currentScore += 1;
            yield return new WaitForSeconds(1f);
        }
    }

    public void UpdateScoreText()
    {
        _scoreText.text = string.Format("Score: {0:000}", currentScore);
    }
}
