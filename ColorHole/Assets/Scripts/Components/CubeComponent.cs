using System;
using UnityEngine;
using DG.Tweening;
using MyNameSpace;

public class CubeComponent : MonoBehaviour
{
    [SerializeField] private Transform m_transform;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private GameSettings m_gameSettings;

    private void FixedUpdate()
    {
        CheckDistance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CommonTypes.TAG_HOLE)
        {
            transform.DOJump(new Vector3(m_transform.position.x, m_transform.position.y, m_transform.position.z),1,1,0.5f).OnComplete(()=>
            {
                Destroy(gameObject);
            });
        }
    }

    /// <summary>
    /// This function help  allows for an effect between the cube and the hole at a specific distance
    /// </summary>
    private void CheckDistance()
    {
        Vector3 holeCenterPoint = new Vector3(m_transform.position.x, m_transform.GetComponent<SphereCollider>().bounds.max.y, m_transform.position.z);
        Vector3 direction = holeCenterPoint - transform.position;
        
        
        if (Vector3.Distance(holeCenterPoint, transform.position) < m_gameSettings.Distance)
        {
            Debug.Log(Vector3.Distance(holeCenterPoint,transform.position));
            m_rb.AddForce(m_gameSettings.FallForce * direction, ForceMode.Force);
        }
    }
}
