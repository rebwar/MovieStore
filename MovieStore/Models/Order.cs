using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Order
    {

        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(maximumLength:12,MinimumLength =12,ErrorMessage ="Must Be 12 Digits")]
        public string PhoneNumber { get; set; }

        public string DateCreated { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int Price { get; set; }
        public OrderState State { get; set; }

    }
    public enum OrderState
    {
        New=0,
        Delivered=1
    }
}
