//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mgok2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lesson
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public long DateTimeStart { get; set; }
        public long DateTimeEnd { get; set; }
        public string RoomNumber { get; set; }
        public int TeacherId { get; set; }
        public Nullable<bool> AdditionalEducation { get; set; }
        public string Address { get; set; }
    
        public virtual Subject Subject { get; set; }
        public virtual User User { get; set; }
    }
}
