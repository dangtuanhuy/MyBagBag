﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BagBag.Models
{
    [MetadataType(typeof(Order.OrderMetaData))]
    public partial class Order
    {
        internal sealed class OrderMetaData
        {
            [Required(ErrorMessage ="Address can not null")]
            public string OrderAddress { get; set; }
            [Required(ErrorMessage = "Phone can not null")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
            public string OrderPhone { get; set; }
        }
    }
}