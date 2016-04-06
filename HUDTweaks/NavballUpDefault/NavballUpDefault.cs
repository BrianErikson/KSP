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

            // Just opened map view
            if (curShow != showing && showing == false && !navToggle.panel.expanded)
            {
                OpenNavball();
                showing = curShow;
            }
            // Just closed map view
            else if (curShow != showing && showing == true)
            {
                showing = curShow;
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
