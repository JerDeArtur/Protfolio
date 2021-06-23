package baza;

public class Samochod extends Cos {

    private double PojemSiln;
    private String typSilnika;

    Samochod(String nazwa, double powierzchnia, boolean czyRozklada, double powierzchniaRozk, double pojemSiln, String typSilnika) {
        super(nazwa, powierzchnia, czyRozklada, powierzchniaRozk);
        PojemSiln = pojemSiln;
        this.typSilnika = typSilnika;
    }

    Samochod(String nazwa, double x, double y, double z, boolean czyRozklada, double rozx, double rozy, double rozz, double pojemSiln, String typSilnika) {
        super(nazwa, x, y, z, czyRozklada, rozx, rozy, rozz);
        PojemSiln = pojemSiln;
        this.typSilnika = typSilnika;
    }

    @Override
    public String toString() {
        return "\nSamochod" +"\n"+
                super.toString()+
                "Typ silnika " + typSilnika + '\n' +
                "Pojemnosc silnika " + PojemSiln +'\n';
    }
}
