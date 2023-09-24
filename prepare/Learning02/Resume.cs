using System.Collections.Generic;

public class Resume
{
    private string _personName;
    private List<Job> _jobList;

    public Resume(string personName)
    {
        _personName = personName;
        _jobList = new List<Job>();
    }

    public void AddJob(Job job)
    {
        _jobList.Add(job);
    }

    public void Display()
    {
        Console.WriteLine(_personName);
        foreach (Job job in _jobList)
        {
            job.Display();
        }
    }
}
