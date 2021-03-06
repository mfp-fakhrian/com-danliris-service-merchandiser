﻿using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Com.Danliris.Service.Merchandiser.Lib.ViewModels
{
    public class BuyerViewModel : BasicOldViewModel, IValidatableObject
    {
        public string code { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.name))
                yield return new ValidationResult("Nama Pembeli harus diisi", new List<string> { "Name" });

            if (string.IsNullOrWhiteSpace(this.email))
                yield return new ValidationResult("Email Pembeli harus diisi", new List<string> { "Email" });
            else if (!Helpers.Email.IsValid(this.email))
                yield return new ValidationResult("Format Email tidak benar", new List<string> { "Email" });
        }
    }
}
