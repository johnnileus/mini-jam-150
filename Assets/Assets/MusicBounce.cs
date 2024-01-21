using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicBounce : MonoBehaviour
{

    public AudioSource src;
    public float ampMult = 100.0f;
    public int fromSpec = 0;
    public int toSpec = 32;
    private Vector3 startScale;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[64];
        src.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        float offset = spectrum.Skip(fromSpec).Take(toSpec).Average() * ampMult;

        transform.localScale = startScale + new Vector3(offset, offset, offset);
    }
}
