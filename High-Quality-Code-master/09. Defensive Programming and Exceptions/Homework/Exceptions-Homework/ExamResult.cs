using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new Exception("Grade must be positive.");
        }
        
        if (minGrade < 0)
        {
            throw new Exception("Min grade must be positive.");
        }
        
        if (maxGrade <= minGrade)
        {
            throw new Exception("Max grade must be equal or greater than min grade.");
        }
        
        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentNullException("Comment can not be null or empty.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
