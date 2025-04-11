namespace ToDoApp.Mobile.Models;

public class FieldDetailModel(string caption, string value)
{
    public string Caption { get; set; } = caption;

    public string Value { get; set; } = value;
}