using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.Data.Entities
{
    public class Payment
    {
        [BindNever]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Please enter card number")]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Card Number")]
        public int? CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter name on card")]
        [DataType(DataType.Text)]
        [Display(Name = "Name on Card")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter lastname on card")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name on Card")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Expiration Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        public DateTime? ExpritaionDate { get; set; }

        [Required(ErrorMessage = "Please enter CVV Number")]
        [Display(Name = "CVV Number")]
        public int? CVV { get; set; }
        [BindNever]
        public double PaidAmount { get; set; }

    }
}
