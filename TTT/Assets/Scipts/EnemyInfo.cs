using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int Hp = 100;
    [SerializeField] double Damage = 20;
    [SerializeField] int Defence = 0;
    [SerializeField] string name = "";

    void Start()
    {
        InvokeRepeating("Hungering", 0, 45);
        InvokeRepeating("Bleeding", 0, 7);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamageNoDefence(int hp)
    {
        Hp -= hp;
        CheckDeath();
    }

    public void TakeDamageSimpleDefence(int hp)
    {
        int deal;
        deal = hp - Defence;
        if (deal < 0)
        {
            deal = 0;
        }
        Hp -= deal;
        CheckDeath();
    }

    public void CheckDeath()
    {
        if (Hp < 0)
        {
            Debug.Log("Death");
        }
    }

    public void SetDefence(int amount)
    {
        Defence = amount;
    }

    public void SetDamage(int amount)
    {
        Damage = amount;
    }

    public double GetDamage()
    {
        return Damage;
    }
}
