//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamTraining
{
    using System;
    using System.Collections.Generic;
    
    public partial class RealEstateSet
    {
        public int id { get; set; }
        public string address_city { get; set; }
        public string address_street { get; set; }
        public string address_house { get; set; }
        public string address_number { get; set; }
        public Nullable<double> coordinate_latitude { get; set; }
        public Nullable<double> coordinate_longtitude { get; set; }
        public int type { get; set; }
        public Nullable<double> total_area { get; set; }
        public Nullable<int> total_floors { get; set; }
        public Nullable<int> rooms { get; set; }
        public Nullable<int> floor { get; set; }
    }
}
