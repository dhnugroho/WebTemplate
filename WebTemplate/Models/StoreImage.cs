//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTemplate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StoreImage
    {
        public int ImgId { get; set; }
        public string ImgTitle { get; set; }
        public byte[] ImgByte { get; set; }
        public string ImgPath { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public Nullable<int> IsDelete { get; set; }
    }
}
