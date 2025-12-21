using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private int akmAmmoCount = 20;
    private int shotgunAmmoCount = 10;

    [SerializeField] private Text akmAmmoText;
    [SerializeField] private Text shotgunAmmoText;

    
    private void Start()
    {
        UpdateText();
    }

    public void AddAkmAmmo(int amount)
    {
        akmAmmoCount += amount;

        UpdateText();
    }

    public void AddShotgunAmmo(int amount)
    {
        shotgunAmmoCount += amount;

        UpdateText();
    }

    public bool TryUseAkmAmmo(int amount)
    {
        if (akmAmmoCount >= amount)
        {
            akmAmmoCount -= amount;

            UpdateText();

            return true;
        }

        UpdateText();

        return false;
    }

    public bool TryUseShotgunAmmo(int amount)
    {
        if (shotgunAmmoCount >= amount)
        {
            shotgunAmmoCount -= amount;
            UpdateText();
            return true;
        }
        UpdateText();
        return false;
    }

    public int GetAkmAmmoCount()
    {
        return akmAmmoCount;
    }

    public int GetShotgunAmmoCount()
    {
        return shotgunAmmoCount;
    }


    private void UpdateText() {
        akmAmmoText.text = akmAmmoCount.ToString();
        shotgunAmmoText.text = shotgunAmmoCount.ToString();
    }
}
