package baza;

public class Przedmiot extends Cos {

    Przedmiot(String nazwa, double powierzchnia, boolean czyRozklada, double powierzchniaRozk) {
        super(nazwa, powierzchnia, czyRozklada, powierzchniaRozk);
    }

    Przedmiot(String nazwa, double x, double y, double z, boolean czyRozklada, double rozx, double rozy, double rozz) {
        super(nazwa, x, y, z, czyRozklada, rozx, rozy, rozz);
    }

    @Override
    public String toString() {
        return "\nPrzedmiot" +"\n"+
                "Nazwa " + nazwa + '\n' +
                "Powierzchnia " + powierzchnia+'\n';
    }
}
