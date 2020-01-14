using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlintaEnergy_API.Models
{
    public class Employee : IEmployee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; private set; }
    }
}
