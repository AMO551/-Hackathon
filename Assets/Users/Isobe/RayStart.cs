using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayStart : MonoBehaviour
{
    RayPoint rayPoint;
    private Vector3 _origin;
    private Vector3 _direction;
    public bool HitColl=false;
    Ray ray;
    float maxDistance = 10;
    LineRenderer lineRenderer;
    private void Start()
    {
        _origin = this.transform.position;
        _direction = this.transform.forward * 1000;
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        ray = new Ray(_origin, _direction);

    }
    private void Update()
    {
        #region ray����

        _origin = this.transform.position;
        _direction = this.transform.forward * 1000;
        ray = new Ray(_origin, _direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {

            if (rayPoint == null)
                rayPoint = hitInfo.collider.gameObject.GetComponent<RayPoint>();
            if ( hitInfo.collider.gameObject.CompareTag("mirror"))
            {
                Debug.Log(hitInfo.collider.gameObject.tag);
                HitColl = true;
            }
            else
                HitColl = false;

            lineRenderer.SetPosition(0, ray.origin);
            lineRenderer.SetPosition(1, hitInfo.point);
    
            //���C�������������W
            Vector3 positon = hitInfo.point;

            //���C���������������蔻��I�u�W�F�N�g�̖ʂ̖@��
            Vector3 normal = hitInfo.normal;

            //���C�̕����x�N�g��
            Vector3 direction = ray.direction;

            //���˃x�N�g���i���˕����������x�N�g���j
            Vector3 reflect_direction = 2 * normal * Vector3.Dot(normal, -direction) + direction;
            //���C�Ɣ��˃x�N�g���̂Ȃ��p�x(���W�A���j
            float rad = Mathf.Acos(Vector3.Dot(-ray.direction, reflect_direction) / ray.direction.magnitude * reflect_direction.magnitude);

            //���W�A����x�ɕϊ�
            float deg = rad * Mathf.Rad2Deg;

            if (hitInfo.collider.gameObject.GetComponent<RayPoint>() != null)
                hitInfo.collider.gameObject.GetComponent<RayPoint>().RayProcessy(true, positon, reflect_direction,this.gameObject.GetComponent<RayStart>(),null);
        }
        else
        {
            if (rayPoint != null)
            {
                rayPoint.RayInitialization();
                rayPoint = null;

            }
            lineRenderer.SetPosition(0, _origin);
            lineRenderer.SetPosition(1, _direction);

        }

        #endregion
    }


}




