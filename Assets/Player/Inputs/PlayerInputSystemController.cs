using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ActionMap
{
    Character,
    Inventory
}

// Mainly manage input action map sets
public class PlayerInputSystemController : MonoBehaviour
{
    static public string USE_BUTTON_NAME = "E";

    // Components //

    private PlayerInput inputs;

    // Tools //

    private Dictionary<ActionMap, InputActionMap> actionMaps;
    private ActionMap lastActionMap;

    // ---------- Mains ------------ //

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();

        actionMaps = new Dictionary<ActionMap, InputActionMap>
        {
            { ActionMap.Character, inputs.actions.actionMaps.Where(x => x.name.Contains("Character")).FirstOrDefault() },
            { ActionMap.Inventory, inputs.actions.actionMaps.Where(x => x.name.Contains("Inventory")).FirstOrDefault() }
        };

        lastActionMap = ActionMap.Character;
    }

    // ----------- Public ---------- //

    public Dictionary<ActionMap, InputActionMap> ActionMaps => actionMaps;

    // On / Off Inventory
    public void SwitchToInventoryActionMap()
    {
        //Debug.Log("InputController :"+context.phase);
        //if (!context.started)
        //    return;

        ActionMap currentMap = actionMaps.FirstOrDefault(x => x.Value == inputs.currentActionMap).Key;

        // From X to inventory
        if (currentMap != ActionMap.Inventory)
        {
            lastActionMap = currentMap;
            SwitchToActionMap(ActionMap.Inventory);
        }
        // From inventory to X
        else
        {
            SwitchToActionMap(lastActionMap);
        }
    }

    // Switch to specific action map
    public void SwitchToActionMap(ActionMap actionMap)
    {
        //inputs.currentActionMap = actionMaps[actionMap];
        inputs.SwitchCurrentActionMap(actionMaps[actionMap].name);
    }
}
