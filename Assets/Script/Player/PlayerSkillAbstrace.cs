using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkillAbstract: MonoBehaviour
{
    public bool cooltimecheck;
    protected float cooltime;
    
    protected IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(cooltime);
        cooltimecheck = true;
    } 
    public abstract void CoolTimeSet();
    public abstract void Skill();
    
}
