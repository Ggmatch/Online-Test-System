//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdministratorSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class reading
    {
        public long ID { get; set; }
        public string Content { get; set; }
        public string QuestionA { get; set; }
        public string QuestionB { get; set; }
        public string QuestionC { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public Nullable<int> Score1 { get; set; }
        public Nullable<int> Score2 { get; set; }
        public Nullable<int> Score3 { get; set; }
    }
}
