using UnityEngine;
using UnityEngine.UI;

public class CounterDisplayer : MonoBehaviour
{
    public Text text;               //UI에서 텍스트 표시하는 변수
    public Counter spawnCounter;    //생성 갯수
    public Counter normalCounter;   //정상 갯수
    public Counter errorCounter;    //불량 갯수

    // Update is called once per frame
    void Update()
    {


        text.text = 
            $"생성갯수 : {spawnCounter.count}개, " +
            $"불량률({((float)errorCounter.count / spawnCounter.count) * 100:0.##}%)" +
            $"\r\n정상 : {normalCounter.count}개" +
            $"\r\n불량 : {errorCounter.count}개";
    }
}
