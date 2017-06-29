using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lures.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public int prospectId { get; set; }

        public int customerId { get; set; }

        [StringLength(64)]
        public string firstName { get; set; }

        [StringLength(64)]
        public string lastName { get; set; }

        [StringLength(64)]
        public string address1 { get; set; }

        [StringLength(64)]
        public string address2 { get; set; }

        [StringLength(32)]
        public string city { get; set; }

        [StringLength(32)]
        public string state { get; set; }

        [Range(0, 9999999999)]
        public int zip { get; set; }

        [StringLength(2)]
        public string country { get; set; }

        [Range(0, 999999999999999999)]
        public int phone { get; set; }

        [StringLength(96)]
        public string email { get; set; }

        [StringLength(15)]
        public string ipAddress { get; set; }

        [StringLength(100)]
        public string AFID { get; set; }

        [StringLength(100)]
        public string SID { get; set; }

        [StringLength(100)]
        public string AFFID { get; set; }

        [StringLength(100)]
        public string C1 { get; set; }

        [StringLength(100)]
        public string C2 { get; set; }

        [StringLength(100)]
        public string C3 { get; set; }

        [StringLength(100)]
        public string AID { get; set; }

        [StringLength(100)]
        public string OPT { get; set; }

        [StringLength(255)]
        public string click_id { get; set; }

        public int campaignId { get; set; }

        [StringLength(255)]
        public string notes { get; set; }
    }
}