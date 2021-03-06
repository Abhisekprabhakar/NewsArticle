//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {   [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[ a-zA-Z]+$", ErrorMessage = "**Name Must only contain Alphabets**")]
        [MinLength(3, ErrorMessage = "** Name must be of length of 3 or more **")]
        public string name { get; set; }
        [EmailAddress(ErrorMessage = "Enter Valid Email Address")]
        [Required]
        public string username { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[@)#$%^&+=]).*$", ErrorMessage = "**Atleast One Special Character is Required **")]
        [MinLength(5, ErrorMessage = "** Password must be of length of 5 or more **")]
        public string password { get; set; }
        public string role { get; set; }
    }
}
