using System;
using System.ComponentModel.DataAnnotations;

namespace AlintaEnergy_API.Models
{
    public interface IEmployee
    {        
        string Id { get; }
        DateTime DateOfBirth { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}