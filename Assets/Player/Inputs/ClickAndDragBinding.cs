using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.InputSystem.Editor;
#endif

namespace UnityEngine.InputSystem.Composites
{

#if UNITY_EDITOR
    [InitializeOnLoad] // Automatically register in editor.
#endif

    [DisplayStringFormat("{MouseButton}+{MouseVector}")]
    public class ClickAndDragBinding : InputBindingComposite<Vector2>
    {
        [InputControl(layout = "Button")]
        public int MouseButton;

        [InputControl(layout = "Vector2")]
        public int MouseVector;

        public override Vector2 ReadValue(ref InputBindingCompositeContext context)
        {
            if (context.ReadValueAsButton(MouseButton))
                return context.ReadValue<Vector2, Vector2MagnitudeComparer>(MouseVector)/10; //hack

            return default;
        }

        public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
        {
            return ReadValue(ref context).magnitude/2;
        }

        static ClickAndDragBinding()
        {
            InputSystem.RegisterBindingComposite<ClickAndDragBinding>();
        }

        //https://forum.unity.com/threads/inputsystem-samples-error-no-binding-composite-with-name-pointerinput-has-been-registered.817419/
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init() { } // Trigger static constructor.
    }
}
