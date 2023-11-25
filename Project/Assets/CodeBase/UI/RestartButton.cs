using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace CodeBase.UI
{
    public class RestartButton : MonoBehaviour
    {
        public Button button;

        public void InitButton(UnityAction onButtonClickedAction)
        {
            button.onClick.AddListener(onButtonClickedAction);
        }
    }
}