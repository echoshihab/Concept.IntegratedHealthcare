﻿using System.ComponentModel.DataAnnotations;

namespace Concept.PatientRecordSystem.DTOs
{
    public class ContactPhone
    {
        [Phone]
        public string? Value { get; set; }
        public string? Use { get; set; }
    }
}
