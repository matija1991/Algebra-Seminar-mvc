//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Predbiljezbe
    {
        public int IdPredbiljezba { get; set; }

        [Required]        
        public virtual Nullable<int> IdSeminar { get; set; }


        [Required]
        [StringLength(25, ErrorMessage = "Maksimalno 25 znakova!")]
        public string Ime { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Maksimalno 25 znakova!")]
        public string Prezime { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maksimalno 50 znakova!")]
        public string Adresa { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maksimalno 50 znakova!")]
        public string Email { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Maksimalno 25 znakova!")]
        public string Telefon { get; set; }

        public bool Prihvaceno { get; set; }

        public bool Odbijeno { get; set; }
    
        public virtual Seminari Seminari { get; set; }
    }
}
