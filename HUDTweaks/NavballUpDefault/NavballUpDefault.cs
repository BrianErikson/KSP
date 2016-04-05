// LICENSE: Apache License Version 2.0
// By: BrianErikson

using KSP.UI.Screens.Flight;
using KSP;

namespace NavballUpDefault
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class NavballUpDefault : UnityEngine.MonoBehaviour
    {

        void Start()
        {
            UnityEngine.Debug.Log("[NavballUpDefault] Started");
            MapView.OnEnterMapView += new Callback(OpenNavball);
        }

        void OpenNavball()
        {
            NavBallToggle navToggle = NavBallToggle.Instance;
            if (navToggle != null && !navToggle.panel.expanded)
            {
                navToggle.Invoke("TogglePanel", 0f);

                if (!navToggle.ManeuverModeActive)
                {
                    navToggle.OnNavBallToggle();
                }
            }
        }
    }
}
