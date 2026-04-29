using TMPro;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    public TextMeshProUGUI Stage1;
    public TextMeshProUGUI Stage2;
    public TextMeshProUGUI Stage3;
    public TextMeshProUGUI Stage4;
    public TextMeshProUGUI Stage5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Stage1.text ="STAGE 1 : "  + HighScore.Load(1).ToString(); 
        Stage2.text ="STAGE 2 : "  + HighScore.Load(2).ToString(); 
        Stage3.text ="STAGE 3 : "  + HighScore.Load(3).ToString(); 
        Stage4.text ="STAGE 4 : "  + HighScore.Load(4).ToString(); 
        Stage5.text ="STAGE 5 : "  + HighScore.Load(5).ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
