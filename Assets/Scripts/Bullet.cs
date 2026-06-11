using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;       //충돌 시 생성하고 싶은 파티클
    public float lifeTime = 10f;    //살아 있는 시간
    public LayerMask detectLayer1;
    public LayerMask detectLayer2;

    private float deadTime;         //죽어야 하는 시간
    private void Start()
    {
        //태어나자마자 죽어야 되는 시간 계산해서 저장
        deadTime = Time.time + lifeTime;
    }

    private void Update()
    {
        //죽어야 되는 시간이 지났는지 확인하고 지났으면 스스로 파괴
        if (deadTime < Time.time)
            Destroy(gameObject); 
    }

    
    //충돌 시 콜백되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        // [추가] 0. 만약 detectLayer2에 체크된 레이어에 부딪혔다면?
        bool isLayer2 = (detectLayer2.value & (1 << collision.gameObject.layer)) != 0;
        if (isLayer2)
        {
            // 이펙트도 안 만들고, Destroy도 안 하고, 여기서 함수를 끝냅니다.
            return;
        }


        // 1. 충돌한 상대방의 레이어가 detectLayer1에 포함되어 있는지 확인
        bool isTargetLayer = (detectLayer1.value & (1 << collision.gameObject.layer)) != 0;

        // 2. 만약 지정된 레이어가 '아닐 때만' 이펙트를 생성합니다.
        if (!isTargetLayer)
        {
            Instantiate<GameObject>(effect, collision.contacts[0].point,
                Quaternion.LookRotation(collision.contacts[0].normal));
        }

        // 3. 총알 스스로 파괴 (detectLayer2가 아닐 때만 여기까지 내려와서 파괴됨)
        Destroy(gameObject);


    }

}
