using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ActionMap
{
    CCTVCamera,
    Character
}

// Mainly manage input action map sets
public class PlayerInputSystemController : MonoBehaviour
{
    public static PlayerInputSystemController Instance { get; private set; }

    static public string USE_BUTTON_NAME = "E";

    // Components //

    private PlayerInput inputs;

    // Tools //

    private Dictionary<ActionMap, InputActionMap> actionMaps;

    // ---------- Mains ------------ //

    public string actionMap;

    private void Update()
    {
        actionMap = inputs.currentActionMap.name;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            inputs = GetComponent<PlayerInput>();
            actionMaps = new Dictionary<ActionMap, InputActionMap>
            {
                { ActionMap.Character, inputs.actions.actionMaps.Where(x => x.name.Contains("Player")).FirstOrDefault() },
                { ActionMap.CCTVCamera, inputs.actions.actionMaps.Where(x => x.name.Contains("CCTV")).FirstOrDefault() }
            };

            Instance = this;
        }

        DontDestroyOnLoad(this);

    }

    // ----------- Public ---------- //

    public Dictionary<ActionMap, InputActionMap> ActionMaps => actionMaps;


    // Switch to specific action map
    public void SwitchToActionMap(ActionMap actionMap)
    {
        //inputs.currentActionMap = actionMaps[actionMap];
        inputs.SwitchCurrentActionMap(actionMaps[actionMap].name);
    }
}
