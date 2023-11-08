namespace TetrLoader.JsonClass
{ 
    public class Points
    {
        public int? primary { get; set; } = null;
        public double? secondary { get; set; } = null;
        public double? tertiary { get; set; } = null;
        public Extra? extra { get; set; } = null;
        public double[]? secondaryAvgTracking { get; set; } = null;
        public double[]? tertiaryAvgTracking { get; set; } = null;
        public ExtraAvgTracking? extraAvgTracking { get; set; } = null;

    }

}
