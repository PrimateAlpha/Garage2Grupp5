namespace Garage2Grupp5.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation properties        

        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }

        //Car,
        //Buss,
        //Boat
    }
}