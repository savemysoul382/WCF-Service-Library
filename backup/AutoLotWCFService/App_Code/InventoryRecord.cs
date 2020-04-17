using System.Runtime.Serialization;

/// <summary>
/// Сводное описание для InventoryRecord
/// </summary>
[DataContract]
public class InventoryRecord
{
    [DataMember]
    public int ID;
    [DataMember]
    public string Make;
    [DataMember]
    public string Color;
    [DataMember]
    public string PetName;
}