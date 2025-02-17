﻿using System.ComponentModel.DataAnnotations;

namespace Proto.PatientRecordSystem.DTOs
{
    public class ContactPhone
    {
        [Phone]
        public required string Value { get; set; }
        public string? Use { get; set; }
    }
}
