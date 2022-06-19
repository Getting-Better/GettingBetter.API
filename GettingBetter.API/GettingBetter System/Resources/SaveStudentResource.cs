﻿using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.GettingBetter_System.Resources;

public class SaveStudentResource
{
    [Required]
    [MaxLength(30)] 
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(30)] 
    public string LastName { get; set; }
    
    
    [Required]
    [MaxLength(30)] 
    public string NickName { get; set; }
    
    [Required]
    [MaxLength(30)] 
    public string Email { get; set; }
    
    [Required]
    [MaxLength(30)] 
    public string Password { get; set; } 
    public string UserImage { get; set; } 
   /* [Required]
    public int CoachId { get; set; }*/
}