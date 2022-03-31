using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace Helperland.Models
{
    public partial class ContactU
    {
        public int ContactUsId { get; set; }

        [Required]
        public string Name { get; set; }
        [NotMapped]
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string SubjectType { get; set; }
        public string Subject { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Please Enter Valid Phone No")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Message { get; set; }
        public string UploadFileName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? Status { get; set; }
        public int? Priority { get; set; }
        public int? AssignedToUser { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public IFormFile Attach { get; set; }
        public string FileName { get; set; }
    }
}
