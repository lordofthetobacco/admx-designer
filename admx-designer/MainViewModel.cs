using System.Collections.ObjectModel;

namespace admx_designer;

public class MainViewModel{
    public static ObservableCollection<AdmxPolicyKey> Items { get; set; } 

    public MainViewModel() {
        Items = new ObservableCollection<AdmxPolicyKey>();
    }

}