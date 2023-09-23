namespace SMCEBI_Navigator.Models;

public class Building : BuildingElement
{
    public uint Version { get; set; }
    public List<Floor> Floors { get; set; }
    

    public Building()
    {
        //Floors = new List<Floor>();
        //Version = 1;
    }
}
