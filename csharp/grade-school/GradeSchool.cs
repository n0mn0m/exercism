using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly SortedDictionary<int, SortedSet<string>> _roster = new SortedDictionary<int, SortedSet<string>>();

    public void Add(string student, int grade)
    {
        if (!_roster.TryGetValue(grade, out var students))
        {
            students = new SortedSet<string>();
            _roster[grade] = students;
        }

        students.Add(student);
    }

    public IEnumerable<string> Roster() => _roster.SelectMany(x => x.Value);

    public IEnumerable<string> Grade(int grade) => (_roster.TryGetValue(grade, out var value)) ? value : Enumerable.Empty<string>();
}