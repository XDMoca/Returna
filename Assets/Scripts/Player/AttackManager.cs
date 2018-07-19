using UnityEngine;

public class AttackManager : MonoBehaviour {

	private CharacterStats playerStats;
	
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attackWidth;
    [SerializeField]
    private bool DebugMode;

	void Awake()
	{
		playerStats = AssetLoadHelper.GetPlayerStats();
	}

    public void AttackCast()
    {
        if(DebugMode)
            DebugHelper.DrawBoxCastBox(transform.position, new Vector3(attackWidth, 1, 0), transform.forward, transform.rotation, attackRange, Color.green, 0.5f);

        RaycastHit[] hits = Physics.BoxCastAll(transform.position, new Vector3(attackWidth, 1, 0), transform.forward, transform.rotation, attackRange, LayerMask.GetMask(Constants.Layers.Enemy));
        if (hits.Length > 0)
        {
            foreach(RaycastHit hit in hits)
            {
                hit.collider.gameObject.GetComponent<EnemyDamageReceiver>().ReceiveDamage(playerStats.Attack);
            }
        }
    }
}
