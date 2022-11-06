using bankapp;
using Terminal.Gui;

FileDB.Init();
Application.Init();
try
{
    Toplevel Top = Application.Top;
    Top.Add(new LoginView());
    Application.Run(Top);
}
finally
{
    FileDB.Save();
    Application.Shutdown();
}