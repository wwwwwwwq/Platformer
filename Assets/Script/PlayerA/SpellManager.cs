using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpellManager : MonoBehaviour
{
    public List<Spell> spells=new List<Spell>();//魔法列表
    public int selectedSpellIndex = 0;//当前选择的魔法索引
    public float currentMana = 100;//当前魔法值
    public float manaRegentRate = 10;//魔法回复速度
    //特殊对待滴一些魔法
    private bool isLightBallActive = false;//光球是否激活(设定：光球存在期间右键无法切换魔法 左键改为摧毁光球)(左键摧毁光球代码在LightBallSpell中)
    private float originalAmbientIntensity;

    void Start()
    {
        // 保存原始环境光强度
        originalAmbientIntensity = RenderSettings.ambientIntensity;

        // 降低环境光强度
        RenderSettings.ambientIntensity = 0.1f;
    }
    private void Update()
    {
        currentMana += manaRegentRate * Time.deltaTime;//魔法回复
        currentMana = Mathf.Clamp(currentMana, 0, 100);//魔法值限制
        foreach (var spell in spells)//更新冷却时间
        {
            spell.UpdateCoolDown(Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(1))//切换魔法
        {
            if (!isLightBallActive)//光球存在期间右键无法切换魔法
            { selectedSpellIndex = (selectedSpellIndex + 1) % spells.Count; }
        }
        if (Input.GetMouseButtonDown(0))//释放魔法
        {
            CastSpell();
        }
    }
    private void CastSpell()//释放魔法
    {
        var selectedSpell = spells[selectedSpellIndex];//当前选择的魔法
        if (currentMana >= selectedSpell.manaCost && selectedSpell.isReady)
        {
            selectedSpell.CastSpell(transform);
            currentMana -= selectedSpell.manaCost;
            if (selectedSpell is LightBallSpell)
            {
                isLightBallActive = true; // 激活光球
            }
        }
        if (isLightBallActive == true && selectedSpell is LightBallSpell lightBallSpell)//订阅委托销毁光球
        {
            lightBallSpell.onLightBallDestroyed = () =>
            {
                isLightBallActive = false; // 光球销毁后，允许切换魔法
            };
        }
    }
}
