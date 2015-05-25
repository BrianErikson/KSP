

namespace NavballUpDefault
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class NavballUpDefault : UnityEngine.MonoBehaviour
    {
        void Start()
        {
            MapView mapView = MapView.fetch;
            if (!mapView.MapCollapse_navBall.expanded)
            {
                mapView.maneuverModeToggle.OnPress.Invoke();
            }
            mapView = null;
        }

        void Update()
        {
        }

        void OnDestroy()
        {

        }
    }
}
