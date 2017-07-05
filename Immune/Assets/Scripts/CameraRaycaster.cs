using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
	public enum Layer {
		Unit = 8,
		Enemy = 9,
		Statics = 10,
		Movable = 11,
		RaycastEndStop = -1
	}

    public Layer[] layerPriorities = {
		Layer.Unit,
        Layer.Enemy,
		Layer.Statics,
		Layer.Movable,
    };

    private float distanceToBackground = 100f;
    private Camera viewCamera;

    private RaycastHit m_hit;
	private Layer m_layerHit;

    public RaycastHit hit
    {
        get { return m_hit; }
    }

    public Layer layerHit
    {
        get { return m_layerHit; }
    }

    void Awake()
    {
        viewCamera = Camera.main;
    }

    void Update()
	{
		// Look for and return priority layer hit
		foreach (Layer layer in layerPriorities) {
			var hit = RaycastForLayer (layer);
			if (hit.HasValue) {
				m_hit = hit.Value;
				m_layerHit = layer;
				return;
			}
		}

		// Otherwise return background hit
		m_hit.distance = distanceToBackground;
		m_layerHit = Layer.RaycastEndStop;

	}

    RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer; // See Unity docs for mask formation
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit; // used as an out parameter
        bool hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
        if (hasHit)
        {
            return hit;
        }
        return null;
    }


}
