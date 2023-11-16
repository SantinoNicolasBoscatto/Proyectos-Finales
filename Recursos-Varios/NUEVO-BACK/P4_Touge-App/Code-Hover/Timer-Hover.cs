private Timer timer;
private const int DuracionTransicion = 1000;
private const int AnchoMax = 300;
private const int AltoMax = 225;
private int initialWidth;
private int initialHeight;
private DateTime transitionStartTime;
private Timer Backtimer;
private const int BackTransicion = 2000;
private const int AnchoMin = 275;
private const int AltoMin = 214;
private int BackWidth;
private int BackHeight;
private DateTime BacktransitionStartTime;
bool bd;

public Form1()
{
    InitializeComponent();
    InitializeTransition(BotonPistas);
    InitializeTransition(AutosBoton);
    InitializeBackTransition();
}
private void InitializeTransition(Button Boton)
{
    timer = new Timer();
    timer.Interval = 20;
    timer.Tick += Timer_Tick;
    Boton.MouseEnter += TrackButton_MouseEnter;
    Boton.MouseLeave += TrackButton_MouseLeave;
    initialWidth = BotonPistas.Width;
    initialHeight = BotonPistas.Height;
    Boton.Tag = new Size(Boton.Width, Boton.Height);
}
private void InitializeBackTransition()
{
    Button Boton = new Button();
    Backtimer = new Timer();
    Backtimer.Interval = 20;
    Backtimer.Tick += Timer_Tick;
    Boton.MouseEnter += TrackButton_MouseEnter;
    Boton.MouseLeave += TrackButton_MouseLeave;
    BackWidth = BotonPistas.Width;
    BackHeight = BotonPistas.Height;
}
private void TrackButton_MouseEnter(object sender, EventArgs e)
{
    timer.Start();
    bd = true;
    trackBD = true;
    transitionStartTime = DateTime.Now;
}

private void TrackButton_MouseLeave(object sender, EventArgs e)
{
    timer.Stop();
    bd = false;
    trackBD = false;
    Backtimer.Start();
    BacktransitionStartTime = DateTime.Now;
}

bool AutosBD;
private void AutosBoton_MouseEnter(object sender, EventArgs e)
{
    timer.Start();
    bd = true;
    AutosBD = true;
    transitionStartTime = DateTime.Now;
}

private void AutosBoton_MouseLeave(object sender, EventArgs e)
{
    timer.Stop();
    bd = false;
    AutosBD = false;
    Backtimer.Start();
    BacktransitionStartTime = DateTime.Now;
}

private void Timer_Tick(object sender, EventArgs e)
{
    if (bd)
    {
        if (AutosBD)
            BotonEnter(AutosBoton);
        else if (trackBD)
            BotonEnter(BotonPistas);
    }

    else if (bd == false)
    {
        if (AutosBoton.Width != 255 || AutosBoton.Height != 187)
            BotonLeave(AutosBoton);
        if (BotonPistas.Width != 255 || BotonPistas.Height != 187)
            BotonLeave(BotonPistas);
    }

}

private void BotonEnter(Button Boton)
{
    double progress = (DateTime.Now - transitionStartTime).TotalMilliseconds / DuracionTransicion;

    progress = Math.Min(progress, 1.0);


    int currentWidth = initialWidth + (int)((AnchoMax - initialWidth) * progress);
    int currentHeight = initialHeight + (int)((AltoMax - initialHeight) * progress);

    Boton.Width = currentWidth;
    Boton.Height = currentHeight;


    if (progress >= 1.0)
    {

        timer.Stop();
    }
}

private void BotonLeave(Button Boton)
{
    double progress = (DateTime.Now - BacktransitionStartTime).TotalMilliseconds / BackTransicion;
    progress = Math.Min(progress, 1.0);
    int currentWidth = Boton.Width + (int)((AnchoMin - Boton.Width) * progress);
    int currentHeight = Boton.Height + (int)((AltoMin - Boton.Height) * progress);

    Boton.Width = currentWidth;
    Boton.Height = currentHeight;

    if (progress >= 1.0)
    {
        Backtimer.Stop();
    }
}