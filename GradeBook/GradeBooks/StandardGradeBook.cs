using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        // This constructor calls the base constructor. 
        StandardGradeBook(string name) : base(name) 
        {
            Type = GradeBookType.Standard;
        }


    }
}
