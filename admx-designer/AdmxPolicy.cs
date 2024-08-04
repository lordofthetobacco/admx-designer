namespace admx_designer;

public class AdmxPolicy {
    public Guid id { get; set; }
    public string RegistryKey { get; set; }
    public HashSet<AdmxPolicyKey> PolicyKeys { get; set; }
    
}