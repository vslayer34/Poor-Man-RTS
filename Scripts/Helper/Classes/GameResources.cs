using Godot;
using Godot.Collections;
using PoorManRTS.Helper.Enums;
namespace PoorManRTS.Helper.Classes;
public class GameResources
{
    private int goldAmount;
    private int woodAmount;


    public int AddWood(int amount) => WoodAmount += amount;

    public int RemoveWood(int amount) => WoodAmount -= amount;

    public int AddGold(int amount) => GoldAmount += amount;

    public int RemoveGold(int amount) => GoldAmount -= amount;


    public bool RemoveProductionResources(Dictionary<ResourceType, int> resources, out GameResources newResources)
    {
        newResources = new GameResources { GoldAmount = goldAmount, WoodAmount = woodAmount };

        if (resources[ResourceType.Gold] > goldAmount || resources[ResourceType.Wood] > woodAmount)
        {
            
            return false;
        }

        newResources = new GameResources();

        foreach (var resource in resources)
        {
            switch (resource.Key)
            {
                case ResourceType.Gold:
                    newResources.GoldAmount = RemoveGold(resource.Value);
                    break;

                case ResourceType.Wood:
                    newResources.WoodAmount = RemoveWood(resource.Value);
                    break;
                
                default:
                    break;
            }
        }

        GD.Print(GoldAmount);

        return true;
    }

    // Getters & Setters---------------------------------------------------------------------------

    public int GoldAmount
    {
        get => goldAmount;
        set
        {
            goldAmount = value >= 0 ? value : 0;
        }
    }

    public int WoodAmount
    {
        get => woodAmount;
        set
        {
            woodAmount = value >= 0 ? value : 0;
        }
    }
}