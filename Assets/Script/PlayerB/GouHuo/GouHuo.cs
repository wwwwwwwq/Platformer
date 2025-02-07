using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GouHuo : MonoBehaviour
{
    public GameObject portalPanel; // ����UI���
    public bool isActive;//�Ƿ񼤻�
    public bool isPanel;//�Ƿ��������
    public bool isRange;

    private void Start()
    {
        isActive = false;
        isPanel = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            portalPanel.SetActive(true);
            isActive = true;
            isPanel = true;
            //player.rb.velocity.zero���ƽ�������ƶ�
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            portalPanel.SetActive(false);
            isPanel = false;
        }
    }
}
