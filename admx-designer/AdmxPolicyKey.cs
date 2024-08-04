namespace admx_designer;

public class AdmxPolicyKey {
    public Guid Id { get; }
    public string KeyName { get; set; }
    public EPolicyControlType ControlType { get; set; }
    public string RegistryPath { get; set; }
    public string PolicyClass { get; set; }

    public AdmxPolicyKey(string keyName, EPolicyControlType controlType, string registryPath, string policyClass) {
        this.Id = Guid.NewGuid();
        KeyName = keyName;
        ControlType = controlType;
        RegistryPath = registryPath;
        PolicyClass = policyClass;
    }
}