using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public static class UpgradePlayerPrefs
{
    //Const-Fields...
    const string Gun_FireRate_Key = "gun firerate";
    const string Missile_Recharge_Time_Key = "missile recharge time";
    const string Gun_Damage_Key = "gun damage";
    const string Missile_Damage_Key = "missile damage";
    const string Bus_Max_Move_Speed = "bus max move speed";

    //Setters...
    public static void SetGunDamage(float Damage)
    {
        PlayerPrefs.SetFloat(Gun_Damage_Key, Damage);
    }
    public static void SetMissileDamage(float Damage)
    {
        PlayerPrefs.SetFloat(Missile_Damage_Key, Damage);
    }
    public static void SetMissileRechargeTime(float rechargeTime)
    {
        PlayerPrefs.SetFloat(Missile_Recharge_Time_Key, rechargeTime);
    }
    public static void SetGunFireRate(float gunFireRate)
    {
        PlayerPrefs.SetFloat(Gun_FireRate_Key, gunFireRate);
    }
    public static void SetBusMaxMoveSpeed(float busMoveSpeed)
    {
        PlayerPrefs.SetFloat(Bus_Max_Move_Speed, busMoveSpeed);
    }

    //Getters...
    public static float GetGunDamage()
    {
        return PlayerPrefs.GetFloat(Gun_Damage_Key);
    }
    public static float GetMissileDamage()
    {
        return PlayerPrefs.GetFloat(Missile_Damage_Key);
    }
    public static float GetGunFireRate()
    {
        return PlayerPrefs.GetFloat(Gun_FireRate_Key);
    }
    public static float GetMissileRechargeTime()
    {
        return PlayerPrefs.GetFloat(Missile_Recharge_Time_Key);
    }
    public static float GetBusMaxMoveSpeed()
    {
        return PlayerPrefs.GetFloat(Bus_Max_Move_Speed);
    }
}
