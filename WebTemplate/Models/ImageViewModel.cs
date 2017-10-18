﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTemplate.Models
{
    public class ImageViewModel
    {
        public int ImgId { get; set; }
        public string ImgTitle { get; set; }
        public byte[] ImgByte { get; set; }
        public string ImgPath { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}