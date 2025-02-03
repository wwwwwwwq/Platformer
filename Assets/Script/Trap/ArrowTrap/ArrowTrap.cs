using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowPrefab; // 箭矢的预制体
    public Transform firePoint; // 箭矢发射点
    public float interval = 2.0f; // 箭矢发射速率
    public bool isRight = true; // 箭矢发射方向
    private float timer = 0.0f; // 计时器
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            ShootArrow();
            timer = 0.0f;
        }
    }
    private void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab,firePoint.position,Quaternion.identity);
        if (isRight)
        {
            arrow.gameObject.GetComponent<Arrow>().direction = new Vector2(1, 0);
        }
        else
        {
            arrow.gameObject.GetComponent<Arrow>().direction = new Vector2(-1, 0);
        }
    }
}
