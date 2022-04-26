namespace uTrackLib
{
    public interface ITOAProcessor
    {
        void TOAProcess(BaseIDs baseID, double baseLat_deg, double baseLon_deg, double baseDpt_m, double baseBat_V, double baseMSR_dB, int pcode, double TOAs);

        void UpdateRelativePosition(double slat_deg, double slon_deg);
    }
}
