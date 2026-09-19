public class FeatureCollection
{
    // The USGS json has a "features" list and each feature has a
    // "properties" object with the stuff we care about (place and mag).
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    // mag comes back as null sometimes so it has to be nullable
    public double? Mag { get; set; }
}
