using System.ComponentModel.DataAnnotations;
namespace HospitalManagement.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        [Required]
        public string FirstName { get; set; }=string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;       
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty;

    }
}
