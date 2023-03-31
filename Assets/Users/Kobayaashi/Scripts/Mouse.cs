using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField, Header("��x�ɉ�]����p�x")]
    private int _rotateAngle = 45;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //���C���J������̃}�E�X�|�C���^�̂���ʒu����ray���΂�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Ray�����������I�u�W�F�N�g�̖��O���w�肵�������������]������
                if (hit.collider.gameObject.tag == "mirror")
                {
                    hit.collider.gameObject.transform.Rotate(0, _rotateAngle, 0);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //���C���J������̃}�E�X�|�C���^�̂���ʒu����ray���΂�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Ray�����������I�u�W�F�N�g�̖��O���w�肵�������������]������
                if (hit.collider.gameObject.tag == "mirror")
                {
                    hit.collider.gameObject.transform.Rotate(0, _rotateAngle*-1, 0);
                }
            }
        }
    }
}