using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    //the starting health for this unit
    public int MaxHP = 100;

    //all units have health
    //_health stores the actual value
    //while health allows us to modify _health through its methods
    private int _health;
    public int health
    {
        set
        {
            _health = value;

            if (_health <= 0)
            {
                Die();
            }
        }

        get
        {
            return _health;
        }
    }

    protected void Start()
    {
        health = MaxHP;
    }
    //the function called when this unit dies
    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }

    public virtual void Damage(int dmg)
    {
        health -= dmg;
    }
}
