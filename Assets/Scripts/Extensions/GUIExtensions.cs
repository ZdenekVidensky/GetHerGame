using TVB.Core.GUI;

static class GUIExtensions
{
    public static void SetActive(this GUIComponent @this, bool state)
    {
        @this.gameObject.SetActive(state);
    }
}
