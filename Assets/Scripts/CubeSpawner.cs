//using UnityEngine;

//public class CubeSpawner : MonoBehaviour
//{
//    public GameObject[] prefabs;           //주기적으로 생성할 게임오브젝트
//    public Transform spawnPosition;     //생성 위치
//    public float startSpawnTime = 3f;   //활성화 시 처음 생성되기까지 걸리는 시간
//    public float spawnInterval = 2.5f;  //생성 주기
//    private float nextSpawnTime;        //다음 생성 시간

//    private void Start()
//    {
//        nextSpawnTime = Time.time + startSpawnTime;    
//    }

//    private void Update()
//    {
//        if(nextSpawnTime < Time.time)
//        {
//            nextSpawnTime = Time.time + spawnInterval;
//            //Instantiate 함수 => 동적으로 지정된 게임오브젝트를 씬에 생성하는 함수
//            GameObject nextCube =
//                Instantiate<GameObject>(prefabs[Random.Range(0, prefabs.Length)], spawnPosition.position, spawnPosition.rotation, spawnPosition);

//        }
//    }
//}

using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Header("생성 설정")]
    public GameObject[] prefabs;        // 주기적으로 생성할 게임오브젝트 (반드시 3개 이상 할당 필요)
    public Transform spawnPosition;     // 생성 위치
    public float startSpawnTime = 3f;   // 활성화 시 처음 생성되기까지 걸리는 시간

    // 요청하신 대로 기본 생성 주기를 2초로 변경했습니다.
    public float spawnInterval = 2.0f;  // 생성 주기 

    private float nextSpawnTime;        // 다음 생성 시간 기록용

    private void Start()
    {
        // 게임 시작 시, 첫 생성 타임라인을 설정합니다.
        nextSpawnTime = Time.time + startSpawnTime;
    }

    private void Update()
    {
        // 현재 게임 진행 시간(Time.time)이 설정해둔 다음 생성 시간을 넘었는지 체크
        if (nextSpawnTime < Time.time)
        {
            // 1. 조건 만족 시, 다음 생성 타임을 미리 2초 뒤로 갱신해 둡니다.
            nextSpawnTime = Time.time + spawnInterval;

            // 2. 0부터 99까지 난수 발생 (확률 제어용)
            int randomChance = Random.Range(0, 100);
            GameObject selectedPrefab = null;

            // 3. 난수 구간에 따라 프리팹을 결정합니다.
            if (randomChance < 50)
            {
                selectedPrefab = prefabs[0]; // 0 ~ 44 (45% 확률)
            }
            else if (randomChance < 96)
            {
                selectedPrefab = prefabs[1]; // 45 ~ 89 (45% 확률)
            }
            else
            {
                selectedPrefab = prefabs[2]; // 90 ~ 99 (10% 확률)
            }

            // 4. Instantiate 함수 => 동적으로 지정된 게임오브젝트를 씬에 생성
            GameObject nextCube = Instantiate<GameObject>(selectedPrefab, spawnPosition.position, spawnPosition.rotation, spawnPosition);
        }
    }
}
