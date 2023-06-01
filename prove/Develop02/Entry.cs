public class Entry{
public string _userEntry;
public string _prompt;
public string _date;


public Entry(){

}
//Create the date and store it in the atribute _date
public void storeDate(){
    DateTime date = DateTime.Today;
    _date = date.ToString();
}

};