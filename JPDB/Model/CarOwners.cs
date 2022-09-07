using System.ComponentModel.DataAnnotations;

namespace JPDB.Model
{

    public class CarOwner
    {
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }

    }

    public class Car {
        [Key]
        public int Id { get; set; }
        public string? CarName { get; set; }
public IList<CarOwner>? CarOwners { get; set; }
}

    public class CarInputModel
    {
        [Key]
        public int Id { get; set; }
        public string? CarName { get; set; }
    }

    public class Owner
    {
        [Key]
        public int Id { get; set; }

        public string? OwnerName { get; set; }
        public IList<CarOwner>? CarOwners { get; set; }

    }

    public class OwnerInputModel
    {
        [Key]
        public int Id { get; set; }
        public string? OwnerName { get; set; }

        public int CarId { get; set; }
    }

    public class OwnerInputWithNewCarModel
    {
        [Key]
        public int Id { get; set; }
        public string? OwnerName { get; set; }
        public string? CarName { get; set; }
    }
}
