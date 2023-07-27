using UnityEngine;

public class OutlineSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectableValue;

    private OutlineSelector[] _outlineSelectors;
    private ISelecatable _currentSelectable;

    private void Start()
    {
        _selectableValue.OnNewValue += OnSelected;
    }

    private void OnSelected(ISelecatable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }


        SetSelected(_outlineSelectors, false);
        _outlineSelectors = null;

        if (selectable != null)
        {
            _outlineSelectors = (selectable as Component).GetComponentsInParent<OutlineSelector>();
            SetSelected(_outlineSelectors, true);
        }
        else
        {
            if (_outlineSelectors != null)
            {
                SetSelected(_outlineSelectors, false);
            }
        }

        _currentSelectable = selectable;

        static void SetSelected(OutlineSelector[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].SetSelected(value);
                }
            }
        }
    }

}

/*public class OutlineSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;

    private OutlineSelector[] _outlineSelectors;
    private ISelecatable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);
    }

    private void onSelected(ISelecatable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;

        setSelected(_outlineSelectors, false);
        _outlineSelectors = null;

        if (selectable != null)
        {
            _outlineSelectors = (selectable as Component).GetComponentsInParent<OutlineSelector>();
            setSelected(_outlineSelectors, true);
        }

        static void setSelected(OutlineSelector[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].SetSelected(value);
                }
            }
        }
    }
}*/


