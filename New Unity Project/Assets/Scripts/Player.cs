using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SyncVar]
    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }
    [SerializeField]
    private int maxHealth = 100;

    [SyncVar]
    private int currentHealth;
    [SerializeField]
    private Behaviour[] disableOnDeath;
    private bool[] wasEnabled;

    void Setup ()
    {
        SetDefaults();
    }

    [ClientRpc]
    public void RpcTakeDamage(int _amount)
    {
        if (isDead)
            return;
        currentHealth -= _amount;
        Debug.Log(transform.name + " now has " + currentHealth + " health.");

        if(currentHealth<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        //DISABLE COMPONENTS
        Debug.Log(transform.name + " is Dead!");

        //CALL RESPAWN METHOD
    }

    public void SetDefaults()
    {
        currentHealth = maxHealth;
    }
}
