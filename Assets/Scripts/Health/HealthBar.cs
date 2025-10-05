using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Health
{
    public Image healthFill;
    public AddedPointsUI addedPointsUI;


    protected override void Start()
    {
        base.Start(); // call the Health Start() so health initializes properly
    }

    private void Update()
    {
        if (healthFill != null)
        {
            healthFill.fillAmount = PercentHealth();
        }
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        if (healthFill != null)
        {
            healthFill.fillAmount = PercentHealth();
        }

        if (addedPointsUI != null)
        {
            addedPointsUI.ShowPoints((int)amount);
        }
    }


    public override void InstaKill()
    {
        base.InstaKill();
        if (healthFill != null)
        {
            healthFill.fillAmount = PercentHealth();
        }
    }
}
