namespace TVB.Game.GUI { 

    using System.Collections;

    using UnityEngine;
    using UnityEngine.UI;

    using TVB.Core.GUI;
    using TVB.Core.Attributes;

    class GUIGirlHUD : GUIComponent
    {
        // PRIVATE MEMBERS

        [GetComponentInChildren("ProgressBar", true), SerializeField, HideInInspector]
        private Slider                m_ProgressBar;
        [GetComponentInChildren("ChangedValue", true), SerializeField, HideInInspector]
        private Animation             m_Animation;
        [GetComponentInChildren("ChangedValue", true), SerializeField, HideInInspector]
        private TMPro.TextMeshProUGUI m_ChangedValue;


        public void Initialize(int initValue, int maxValue)
        {
            m_ProgressBar.minValue = 1f;
            m_ProgressBar.maxValue = maxValue;
            m_ProgressBar.value    = initValue;
        }

        public IEnumerator ChangeValue(int changedValue)
        {
            m_ChangedValue.text = string.Format("{0}{1}", changedValue > 0 ? "+" : "-", Mathf.Abs(changedValue));
            m_ChangedValue.color = changedValue > 0 ? Color.green : Color.red;

            var step       = changedValue > 0 ? 1 : -1;
            var finalValue = m_ProgressBar.value + changedValue;
            var wait       = new WaitForSeconds(0.05f);

            m_ChangedValue.SetActive(true);
            yield return m_Animation.PlayAndWait();
            m_ChangedValue.SetActive(false);

            while (m_ProgressBar.value != finalValue)
            {
                var newValue = m_ProgressBar.value + step;

                if (newValue <= m_ProgressBar.minValue || newValue >= m_ProgressBar.maxValue)
                    yield break;
                m_ProgressBar.value = newValue;

                yield return wait;
            }

            m_ProgressBar.value = finalValue;
        }
    }
}
