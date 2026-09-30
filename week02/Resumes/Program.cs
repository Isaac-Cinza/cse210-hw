using System;

class Program
{
    static void Main(string[] args)
    {
        Resume myResume = new Resume();
        myResume._name = "Isaac MWEMBIA CINZA";

        // Most recent start dates first. Jobs that are still ongoing use 2026 as the end year.
        myResume._jobs.Add(CreateJob("Founder & Research Consultant", "CINZA Research Hub", 2023, 2026));
        myResume._jobs.Add(CreateJob("Journalist", "RTDK Radio Television", 2023, 2026));
        myResume._jobs.Add(CreateJob("Communication Manager", "Smart Brain Investment", 2024, 2025));
        myResume._jobs.Add(CreateJob("Nursing & Public Health Intern", "HGR Bonzola", 2024, 2024));
        myResume._jobs.Add(CreateJob("Laboratory Intern", "Cliniques Universitaires de Mbujimayi", 2025, 2025));
        myResume._jobs.Add(CreateJob("Provincial Administrative Commissioner", "ASKOR Scouts", 2021, 2026));

        myResume.Display();
    }

    // Creates one Job instance and fills in its member variables.
    static Job CreateJob(string jobTitle, string company, int startYear, int endYear)
    {
        Job job = new Job();
        job._jobTitle = jobTitle;
        job._company = company;
        job._startYear = startYear;
        job._endYear = endYear;
        return job;
    }
}