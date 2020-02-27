using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OyuncuTabani.Models
{
[MetadataType(typeof(FutbolcuMetaData))]
    public  partial class Futbolcu
    {
    }

    [MetadataType(typeof(TakimMetaData))]
    public partial class Takim
    {
    }
}