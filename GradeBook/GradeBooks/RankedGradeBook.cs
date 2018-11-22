using System.linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var threshold =(int)(Students.Count * 0.2);
            var List = Students.OrderByDescending(x => x.AverageGrade).ToList();
            if (List[(List.Count-1)-threshold].AverageGrade < AverageGrade)
            {
                return 'A';
            }
            else if (List[(List.Count - 1) - (threshold*2)].AverageGrade < AverageGrade)
            {
                return 'B';
            }
            else if (List[(List.Count - 1) - (threshold * 3)].AverageGrade < AverageGrade)
            {
                return 'C';
            }
            else if (List[(List.Count - 1) - (threshold * 4)].AverageGrade < AverageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';

            }
            
        }
    }
}
