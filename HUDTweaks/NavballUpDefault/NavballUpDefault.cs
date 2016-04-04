// LICENSE: Apache License Version 2.0
// By: BrianErikson

using KSP.UI.Screens.Flight;

namespace NavballUpDefault
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class NavballUpDefault : UnityEngine.MonoBehaviour
    {
        MapView mapView;
        NavBallToggle toggle;
        bool showing;

        void Start()
        {
            mapView = MapView.fetch;
            showing = MapView.MapIsEnabled;
            toggle = NavBallToggle.Instance;
            
            if (showing && !toggle.panel.expanded)
            {
                toggle.panel.Expand();
            }
        }

        void Update()
        {
            bool curShow = MapView.MapIsEnabled;

            // Just opened map view
            if (curShow != showing && showing == false && !toggle.panel.expanded)
            {
                toggle.panel.Expand();
                showing = curShow;
            } 
            // Just closed map view
            else if (curShow != showing && showing == true)
            {
                showing = curShow;
            }
        }

        void OnDestroy()
        {
            mapView = null;
            toggle = null;
        }
    }
}
