public class Journal{
public string _ownerName = "Kattia";
public string _fileName;
public string _filePath;
public string _loadedFile;


public Journal(){

}


public void saveEntry(Entry entry, string fileName){

     // Find if the file exist   
     if (File.Exists(_filePath)){
         using (StreamWriter sw = File.AppendText(fileName))
        {
         sw.WriteLine($"{entry._prompt} | {entry._userEntry} | {entry._date}");
        }	   
    }
  
    else
    {
        using (StreamWriter sw = File.CreateText(fileName))
            {
             sw.WriteLine($"{entry._prompt} | {entry._userEntry} | {entry._date}");
            }	
    }
}

// Display File Entries
public void DisplayEntries(string loadedFile = "entries.txt" ){
TextReader read = new StreamReader(loadedFile);
Console.WriteLine();
Console.WriteLine(read.ReadToEnd());
read.Close();
}
};