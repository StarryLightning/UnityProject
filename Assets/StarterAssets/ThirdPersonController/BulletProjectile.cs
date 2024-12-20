using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    [SerializeField] private Transform vfxHitEnemy;
    [SerializeField] private Transform vfxHitElse;

    private Rigidbody bulletRigidbody;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        float speed = 40f;
        //前进方向向量给予速度
        bulletRigidbody.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BulletTarget>()!=null)
        {
            //击中敌人显示一种碰撞特效
            Instantiate(vfxHitEnemy, transform.position, Quaternion.identity);
        }else{
            //击中了其他物体显示另一种特效
            Instantiate(vfxHitElse, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
