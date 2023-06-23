using System;
using System.Runtime.InteropServices;

namespace BeatAndTempoLib;

// The idea here is to create a clean interface which could either contain the SWIG-generated classes, or a pure C# implementation.
// However, given the number of functions in the SWIG-generated classes, it may be easier to just use them directly.

public class BeatAndTempoTracker : IDisposable {

    // may be private in future
    public SWIGTYPE_p_Opaque_BTT_Struct instance { get; private set; }

    public BeatAndTempoTracker() {
        instance = BTT.btt_new_default();
    }

    ~BeatAndTempoTracker() {
        Dispose(false);
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing) {
        //if (instance != IntPtr.Zero) {
        //    BTT_free(instance);
        //    instance = IntPtr.Zero;
        //}
        if (instance != null) {
            BTT.btt_destroy(instance);
            instance = null;
        }
    }
}
