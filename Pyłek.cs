﻿using System;
using System.Collections.Generic;

// Klasa reprezentująca ikonę
class Icon
{
    public string Name { get; private set; }

    public Icon(string name)
    {
        Name = name;
        // Dodaj inne właściwości ikony, jeśli są wymagane
    }

    public void Display()
    {
        Console.WriteLine("Displaying icon: " + Name);
    }
}

// Klasa fabryki ikon
class IconFactory
{
    private Dictionary<string, Icon> icons = new Dictionary<string, Icon>();

    public Icon GetIcon(string name)
    {
        if (!icons.ContainsKey(name))
        {
            icons[name] = new Icon(name);
        }
        return icons[name];
    }
}

// Prosty interfejs użytkownika (UI) do wyświetlania ikon
class UI
{
    private IconFactory iconFactory;

    public UI(IconFactory factory)
    {
        iconFactory = factory;
    }

    public void DisplayIcon(string name)
    {
        Icon icon = iconFactory.GetIcon(name);
        icon.Display();
    }
}

// Przykładowe użycie
class Program
{
    static void Main(string[] args)
    {
        IconFactory iconFactory = new IconFactory();
        UI ui = new UI(iconFactory);

        ui.DisplayIcon("icon1");
        ui.DisplayIcon("icon2");
        ui.DisplayIcon("icon3");
    }
}







