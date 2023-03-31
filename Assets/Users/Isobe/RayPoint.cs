using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPoint : MonoBehaviour
{
    //ClearのCanvas
    public GameObject ClearCanvas;
    //あたっているかの確認
    public bool HitColl;
    [SerializeField, Header("Clear判定ならチェック")]
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
    //Ray初期化
    public void RayInitialization()
    {
        rayStart = null;
        rayPoint = null;
        HitColl = false;
        if (lineRenderer.enabled == true && lineRenderer != null)
            lineRenderer.enabled = false;
    }
    //Ray処理
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
        //（デバッグ用）新しい反射用レイを作成する
        Ray reflect_ray = new Ray(vector1, vector2);
        //Rayを出す長さや角度
        if (Physics.Raycast(reflect_ray, out RaycastHit hitInfo))
        {


            lineRenderer.SetPosition(0, reflect_ray.origin);
            lineRenderer.SetPosition(1, hitInfo.point);
            //（デバッグ用）レイを画面に表示する
            Debug.DrawLine(reflect_ray.origin, hitInfo.point, Color.red, 0, false);

            //レイがあたった座標
            Vector3 positon = hitInfo.point;

            //レイがあたった当たり判定オブジェクトの面の法線
            Vector3 normal = hitInfo.normal;

            //レイの方向ベクトル
            Vector3 direction = reflect_ray.direction;

            //反射ベクトル（反射方向を示すベクトル）
            Vector3 reflect_direction = 2 * normal * Vector3.Dot(normal, -direction) + direction;

            //レイと反射ベクトルのなす角度(ラジアン）
            float rad = Mathf.Acos(Vector3.Dot(-reflect_ray.direction, reflect_direction) / reflect_ray.direction.magnitude * reflect_direction.magnitude);

            //ラジアンを度に変換
            float deg = rad * Mathf.Rad2Deg;

            if (hitInfo.collider.gameObject.GetComponent<RayPoint>() != null)
                hitInfo.collider.gameObject.GetComponent<RayPoint>().RayProcessy(true, positon, reflect_direction, null, this.gameObject.GetComponent<RayPoint>());
        }
        else
        {
            //（デバッグ用）レイを画面に表示する
            lineRenderer.SetPosition(0, reflect_ray.origin);
            lineRenderer.SetPosition(1, reflect_ray.origin + reflect_ray.direction * 10000);
            Debug.DrawLine(reflect_ray.origin, reflect_ray.origin + reflect_ray.direction * 10000, Color.red, 0, false);
        }


    }
    //Clear処理
    private void ClearIndication()
    {
        Debug.Log("Goal Check");
        ClearCanvas.SetActive(true);
    }


}
