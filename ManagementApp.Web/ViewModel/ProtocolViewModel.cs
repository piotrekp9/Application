﻿using ManagementApp.Web.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Web.ViewModel
{
    public class ProtocolViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string Proclamation { get; set; }
        
        public bool IsSuccessfull { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }

        [Required]
        [StringLength(500)]
        public string Weather { get; set; }

        [Required]
        public ProtocolType ProtocolType { get; set; }
    }
}
