using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPoint : MonoBehaviour
{
    //Clear��Canvas
    public GameObject ClearCanvas;
    //�������Ă��邩�̊m�F
    public bool HitColl;
    [SerializeField, Header("Clear����Ȃ�`�F�b�N")]
    private bool clearCheck = false;

    int hitback = 0;
    Ray ray;
    RayPoint rayPoint;
    RayStart rayStart;
    LineRenderer lineRenderer;
    private void Start()
    {
        if (this.gameObject.GetComponent<LineRenderer>() != null)
            lineRenderer = this.gameObject.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if (rayStart != null)
            if (!rayStart.HitColl)
                RayInitialization();

        if (rayPoint != null)
            if (!rayPoint.HitColl)
                RayInitialization();
        if (hitback >= 0)
            hitback--;
        if (hitback == -1 && HitColl)
        {
            RayInitialization();
            hitback = 0;
        }
    }
    //Ray������
    public void RayInitialization()
    {
        rayStart = null;
        rayPoint = null;
        HitColl = false;
        if (lineRenderer.enabled == true && lineRenderer != null)
            lineRenderer.enabled = false;
    }
    //Ray����
    public void RayProcessy(bool boolray, Vector3 vector1, Vector3 vector2, RayStart R_start, RayPoint R_point)
    {
        if (clearCheck)
        {
            ClearIndication();
            return;
        }
        hitback++;
        HitColl = true;
        if (rayStart == null && R_start != null)
        {
            rayStart = R_start;
        }
        if (rayPoint == null && R_point != null)
        {
            rayPoint = R_point;
        }
        if (lineRenderer.enabled == false)
            lineRenderer.enabled = true;
        //�i�f�o�b�O�p�j�V�������˗p���C���쐬����
        Ray reflect_ray = new Ray(vector1, vector2);
        //Ray���o��������p�x
        if (Physics.Raycast(reflect_ray, out RaycastHit hitInfo))
        {


            lineRenderer.SetPosition(0, reflect_ray.origin);
            lineRenderer.SetPosition(1, hitInfo.point);
            //�i�f�o�b�O�p�j���C����ʂɕ\������
            Debug.DrawLine(reflect_ray.origin, hitInfo.point, Color.red, 0, false);

            //���C�������������W
            Vector3 positon = hitInfo.point;

            //���C���������������蔻��I�u�W�F�N�g�̖ʂ̖@��
            Vector3 normal = hitInfo.normal;

            //���C�̕����x�N�g��
            Vector3 direction = reflect_ray.direction;

            //���˃x�N�g���i���˕����������x�N�g���j
            Vector3 reflect_direction = 2 * normal * Vector3.Dot(normal, -direction) + direction;

            //���C�Ɣ��˃x�N�g���̂Ȃ��p�x(���W�A���j
            float rad = Mathf.Acos(Vector3.Dot(-reflect_ray.direction, reflect_direction) / reflect_ray.direction.magnitude * reflect_direction.magnitude);

            //���W�A����x�ɕϊ�
            float deg = rad * Mathf.Rad2Deg;

            if (hitInfo.collider.gameObject.GetComponent<RayPoint>() != null)
                hitInfo.collider.gameObject.GetComponent<RayPoint>().RayProcessy(true, positon, reflect_direction, null, this.gameObject.GetComponent<RayPoint>());
        }
        else
        {
            //�i�f�o�b�O�p�j���C����ʂɕ\������
            lineRenderer.SetPosition(0, reflect_ray.origin);
            lineRenderer.SetPosition(1, reflect_ray.origin + reflect_ray.direction * 10000);
            Debug.DrawLine(reflect_ray.origin, reflect_ray.origin + reflect_ray.direction * 10000, Color.red, 0, false);
        }


    }
    //Clear����
    private void ClearIndication()
    {
        Debug.Log("Goal Check");
        ClearCanvas.SetActive(true);
    }


}
