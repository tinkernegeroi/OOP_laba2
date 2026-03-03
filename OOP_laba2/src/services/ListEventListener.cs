using OOP_laba2.classes;

namespace OOP_laba2.services;

public class ListEventListener
{
    private TextBox _textBox;

    public ListEventListener(AirportCollection list, TextBox textBox)
    {
        this._textBox = textBox;
        list.ItemAdded += (message) => { this._textBox.Text += message; };
        list.ItemRemoved += (message) => { this._textBox.Text += message; };
    }
}