using System;
using System.ComponentModel.DataAnnotations.Schema;
using SampleAuth.Microservice.Entities;
using SampleAuth.Microservice.Repositories.Role.DtoModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SampleAuth.Microservice.Repositories.User.DtoModels {

    [Table("Users")]
    public class UserDtoModel : BaseEntity {
       
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public string Address { get; set; }
        public int Created_at { get; set;}
        public int RoleId { get ; set;}
        public RoleDtoModel Role {get; set;}
        

    }

    

}