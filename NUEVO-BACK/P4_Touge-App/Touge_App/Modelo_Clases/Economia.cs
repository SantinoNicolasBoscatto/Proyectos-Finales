using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Clases
{
    public class Economia
    {
        public int CantidadDeDinero { get; set; }
        public int CambioDeAceite { get { return 50; } }
        public int Mantenimiento { get { return 50; } }
        public int Gomas { get { return 50; } }
        public float Combustible { get; set; }
        public int MotorNuevo { get; set; }
        public int ReduccionPeso { get; set; }
        public int Lavado { get { return 50; } }
        public Ropa Ropa { get;}
        public Comida Comida { get;}
        public Alquiler Alquiler { get; }
        public Facturas Facturas { get; }
        public Muebles Muebles { get; }
        public Casa Casa { get; }
        public SeguroAuto Seguro { get; }
        public Tecnologia Tecnologia { get; }
        public Higiene Higiene { get; }
        public CarDealer CarDealer { get; set; }
    }
    public class Ropa {
        public int RemeraBasica { get { return 25; } }
        public int RemeraMedia { get { return 50; } }
        public int RemeraAlta { get { return 90; } }
        public int Camisa { get { return 150; } }
        public int PantalonBasico { get { return 40; } }
        public int PantalonMedio { get { return 70; } }
        public int PantalonAlto { get { return 105; } }
        public int ZapatillasBasicas { get { return 60; } }
        public int ZapatillasMedias { get { return 85; } }
        public int ZapatillasAltas { get { return 125; } }
        public int RelojBasico { get { return 20; } }
        public int RelojMedio { get { return 100; } }
        public int RelojAlto { get { return 2500; } }
        public int CamperaBasica { get { return 80; } }
        public int CamperaMedia { get { return 140; } }
        public int CamperaAlta { get { return 200; } }
        public int Mochila { get { return 100; } }
        public int Lentes { get { return 200; } }
        public int LentesSol { get { return 150; } }
        public int Boxer { get { return 30; } }
    }
    public class Comida {
        public int SuperBasico { get { return 550; } }
        public int Basico { get { return 750; } }
        public int Medio { get { return 900; } }
        public int Alta { get { return 1100; } }
        public int SuperAlta { get { return 1500; } }
        public int Yerba { get { return 150; } }
    }
    public class Alquiler {
        public int SuperBasico { get; set; }
        public int Basico { get; set; }
        public int Medio { get; set; }
        public int Alta { get; set; }
        public int SuperAlta { get; set; }
    }
    public class Facturas {
        public int SuperBasico { get { return 105; } }
        public int Basico { get { return 130; } }
        public int Medio { get { return 180; } }
        public int Alta { get { return 250; } }
        public int SuperAlta { get { return 350; } }
    }
    public class Muebles {
        public int Cama { get { return 1500; } }
        public int Escritorio { get { return 110; } }
        public int AireAcondicionado { get { return 850; } }
        public int EscritorioTV { get { return 225; } }
        public int SillaGamer { get { return 215; } }
        public int Afeitadora { get { return 150; } }
        public int GuardaRopa { get { return 125; } }
        public int Volante { get { return 2500; } }
        public int Aspiradora { get { return 300; } }
        public int Auriculares { get { return 20; } }
        public int Teclado { get { return 50; } }
        public int Sarten { get { return 70; } }
        public int Olla { get { return 55; } }
        public int Lavarropa { get { return 250; } }
        public int CepilloElectrico { get { return 60; } }
        public int Microondas { get { return 145; } }
        public int Estufa { get { return 45; } }
        public int Heladera { get { return 700; } }
        public int MiniHeladera { get { return 200; } }
        public int Cafetera { get { return 110; } }
        public int Almohada { get { return 25; } }
    }
    public class Casa {
        public int SuperBasico { get { return 200000; } }
        public int Basico { get { return 250000; } }
        public int Medio { get { return 310000; } }
        public int Alta { get { return 400000; } }
        public int SuperAlta { get { return 650000; } }
    }
    public class SeguroAuto {
        //Devuelve un 10% del total del Auto
        public int SeguroBasico { get{ return 250; } }
        //Devuelve un 25% del total del Auto
        public int SeguroTerceros { get{ return 535; } }
        //Devuelve un 50% del total del Auto
        public int SeguroMedio { get{ return 750; } }
        //Devuelve un 100% del total del Auto
        public int SeguroTotal { get{ return 1350; } }
    }
    public class Tecnologia {
        public int NotebookBaja {get { return 400; } }
        public int NotebookMedia { get { return 710; } }
        public int NotebookAlta { get { return 925; } }
        public int NotebookSuperAlta { get { return 1150; } }
        public int CelularBaja { get { return 250; } }
        public int CelularMedia { get { return 425; } }
        public int CelularAlta { get { return 650; } }
        public int CelularSuperAlta { get { return 800; } }
        public int TelevisorBaja { get { return 1350; } }
        public int TelevisorMedia { get { return 1625; } }
        public int TelevisorAlta { get { return 2700; } }
        public int TelevisorSuperAlta { get { return 4750; } }
        public int GafasVR { get { return 400; } }
        public int Ps2 { get { return 340; } }
        public int Ps3 { get { return 390; } }
        public int Ps4 { get { return 350; } }
        public int GBA { get { return 360; } }
        public int DS { get { return 180; } }
        public int Nitendo3ds { get { return 320; } }
        public int Juegos3ds { get { return 20; } }
        public int JuegosDS { get { return 50; } }
    }
    public class Higiene {
        public int Basico { get { return 40; } }
        public int Medio { get { return 65; } }
        public int Alto { get { return 80; } }
    }
    public class CarDealer {
        //Sitio =   https://www.beforward.jp/
    }
}
