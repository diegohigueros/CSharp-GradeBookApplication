using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        // This constructor calls the base constructor. 
        public StandardGradeBook(string name, bool weighted) : base(name, weighted) 
        {
            Type = GradeBookType.Standard;
        }


    }
}
