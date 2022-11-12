using CommunityToolkit.Maui.Alerts;

namespace Color_Maker;

public partial class MainPage : ContentPage
{
    private string HexValue;

    public MainPage()
    {
        InitializeComponent();
    }

    private void sld_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var red = sldRed.Value;
        var green = sldGreen.Value;
        var blue = sldBlue.Value;

        Color color = Color.FromRgb(red, green, blue);

        SetColor(color);
    }
    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        var random = new Random();
        var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;

        SetColor(color);
    }
    private void SetColor(Color color)
    {
        btnRandom.BackgroundColor = color;
        Container.BackgroundColor = color;
        HexValue = color.ToHex();
        lblHex.Text = HexValue;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(HexValue);
        var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);

        await toast.Show();
    }
}

