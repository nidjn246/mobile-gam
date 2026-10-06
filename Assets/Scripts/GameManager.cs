using TMPro;
using Unity.Microsoft.GDK;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
[SerializeField] private GameObject dice;
[SerializeField] private TextMeshProUGUI tekst;
    [SerializeField] private int score;
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(dice);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        tekst.text = "Score: " + score;
    }
}
