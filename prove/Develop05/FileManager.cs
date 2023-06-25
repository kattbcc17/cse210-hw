public static class FileManager
{
    public static void SaveGoals(string filename, List<Goal> goalList, int score)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            outputFile.WriteLine(score);

            foreach (Goal goal in goalList)
            {
                outputFile.WriteLine(goal.StrimGoal());
            }
        }
    }

    public static int LoadGoals(string filename, List<Goal> goalist, int score)
    {
        // Clean the list before loading goals
        goalist.Clear();
        // Strim the stringGoals perLine and add them to the empty list.
        string[] lines = System.IO.File.ReadAllLines(filename);
        // This Counter is to skip the first line
        int counter = 0;
        foreach (string line in lines)
        {
            // Skip the first line of code
            if (counter == 0)
            {
                // Actualizar el score    
                score = int.Parse(line);
                counter += 1;
                continue;
            }

            string[] parts = line.Split(",");
            string goalType = parts[0];
            string checkMark = " ";

            if (goalType == "Simple" || goalType == "Eternal")
            {
                string name = parts[1];
                string description = parts[2];
                int value = int.Parse(parts[3]);
                bool iscompleted = bool.Parse(parts[4]);

                switch (goalType)
                {
                    case "Simple":
                        Simple simpleGoal = new Simple(name, description, value, iscompleted);
                        goalist.Add(simpleGoal);
                        break;

                    case "Eternal":
                        Eternal EternaleGoal = new Eternal(name, description, value, iscompleted);
                        goalist.Add(EternaleGoal);
                        break;
                }
            }
            else
            {
                string name = parts[1];
                string description = parts[2];
                int value = int.Parse(parts[3]);
                int bonus = int.Parse(parts[4]);
                int times = int.Parse(parts[5]);
                int timesCompleted = int.Parse(parts[6]);
                bool iscompleted = bool.Parse(parts[7]);
                CheckList checkListGoal = new CheckList(name, description, value, times, bonus, iscompleted, timesCompleted);
                goalist.Add(checkListGoal);
            }
        }

        return score;
    }
}
