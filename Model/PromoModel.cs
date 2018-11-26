using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AllAddOnsAPI.Models 
{
    [Table("Promos")]

    public class Promos : BaseEntity
    {
        public Int64 PromID { get; set;}

        public string Promoname { get; set;}

        public Int64 Price { get; set;}

        public string  PromoDescription {get; set;}

        public Int64 GroupId {get; set;}

        public string  IsPromoRecurring {get; set;}

        public string  RecurringPromoId {get; set;}

        public string Spiel {get; set;}

    }
    
}
