using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OyuncuTabani.Models
{
    public class FutbolcuMetaData
    {
        [StringLength(50)]
        [Display(Name = "Adı")]
        public string Fadi { get; set; }
        [StringLength(50)]
        [Display(Name = "Soyadı")]
        public string Fsoyadi { get; set; }
        [Display(Name = "Doğum Tarihi")]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
        public Nullable<System.DateTime> Dtarih { get; set; }
        [Display(Name = "Pozisyon")]
        public string Fmevki { get; set; }
    }

    public class TakimMetaData
    {
        [Display(Name = "Oynadığı Takım")]
        public string TakimAdi { get; set; }
    }
}