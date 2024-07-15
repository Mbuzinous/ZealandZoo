﻿using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Models
{
    public class MailDto
    {
        [Required(ErrorMessage = " - Skriv venligst dit fornavn.")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = " - Email adresse er påkrævet.")]
        [EmailAddress(ErrorMessage = " - Email adressen er ikke en gyldig email adresse")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = " - Skriv venligst hvad det drejer sig om."), MaxLength(30)]
        public string Subject { get; set; }

        [Required(ErrorMessage = " - Forklar med få ord, hvordan vi kan hjælpe dig.")  ]
        public string Body { get; set; } 
    }
}
