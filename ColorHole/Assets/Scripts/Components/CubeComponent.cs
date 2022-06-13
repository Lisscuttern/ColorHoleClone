using UnityEngine;
using DG.Tweening;
using MyNameSpace;

public class CubeComponent : MonoBehaviour
{
    #region Serialize Fields

    [SerializeField] private Transform m_transform;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private GameSettings m_gameSettings;
    [SerializeField] private LevelManager m_levelManager;

    #endregion
    

    private void FixedUpdate()
    {
        CheckDistance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CommonTypes.TAG_HOLE)
        {
            transform.DOJump(new Vector3(m_transform.position.x, m_transform.position.y, m_transform.position.z),1,1,1f).OnComplete(()=>
            {
                Destroy(gameObject);
                m_levelManager.LevelProgress();
            });

            if (this.gameObject.tag == CommonTypes.TAG_WRONG_CUBE)
            {
                
                transform.DOJump(new Vector3(m_transform.position.x, m_transform.position.y-1, m_transform.position.z),1,1,0.5f).OnComplete(()=>
                {
                    Destroy(gameObject);
                    m_levelManager.GameOver();
                });
            }
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
