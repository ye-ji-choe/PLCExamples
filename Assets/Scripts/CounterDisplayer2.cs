using UnityEngine;
using UnityEngine.UI;

public class CounterDisplayer2: MonoBehaviour
{
    public Text text;               //UI에서 텍스트 표시하는 변수
    public Counter spawnCounter;    //생성 갯수
    public Counter metalCounter;   //정상 갯수
    public Counter weirdCounter;

    // Update is called once per frame
    void Update()
    {


        text.text =
            $"생성갯수 : {spawnCounter.count}개, " +
            $"\r\n금속 : {metalCounter.count}개" +
            $"\r\n비금속 : {spawnCounter.count - metalCounter.count}개" +
            $"\r\n불량 : {weirdCounter.count}개";
    }
}
