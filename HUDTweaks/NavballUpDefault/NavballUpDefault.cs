// LICENSE: Apache License Version 2.0
// By: BrianErikson

using KSP.UI.Screens.Flight;
using KSP;

namespace NavballUpDefault
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class NavballUpDefault : UnityEngine.MonoBehaviour
    {
        NavBallToggle navToggle;
        bool showing = false;

        void Start()
        {
            UnityEngine.Debug.Log("[NavballUpDefault] Started");
            navToggle = NavBallToggle.Instance;
        }

        void Update()
        {
            bool curShow = MapView.MapIsEnabled;

            // Check if we opened/closed map view
            if (curShow != showing)
            {
                // Just closed map view
                if (showing)
                {
                    showing = curShow;
                }
                // Just opened map view
                else //showing is false
                if (!navToggle.panel.expanded)
                {
                    OpenNavball();
                    showing = curShow;
                }
            }
        }

        void OpenNavball()
        {
            if (navToggle != null)
            {
                if (!navToggle.panel.expanded)
                {
                    navToggle.Invoke("TogglePanel", 0f);
                }

                if (!navToggle.ManeuverModeActive)
                {
                    navToggle.OnNavBallToggle();
                }
            }
        }
    }
}
