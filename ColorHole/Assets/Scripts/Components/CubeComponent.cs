using System;
using UnityEngine;
using DG.Tweening;
using MyNameSpace;

public class CubeComponent : MonoBehaviour
{
    [SerializeField] private HoleComponent m_holeComponent;
    [SerializeField] private Transform m_transform;
    [SerializeField] private Transform m_hole;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private GameSettings m_gameSettings;

    private void FixedUpdate()
    {
        CheckDistance();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == CommonTypes.TAG_HOLE)
        {
            Destroy(gameObject,1.5f);
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
            m_rb.AddForce(m_gameSettings.FallForce * direction, ForceMode.Force);
        }
    }
}
