namespace SMCEBI_Navigator.Models;

public class Building : BuildingElement
{
    public uint Version { get; set; }
    public List<Floor> Floors { get; set; }
    

    public Building()
    {
        Name = "";
        Floors = new();
        Version = 0;
    }
}
