package baza;

public class Motocykl extends  Cos {

    private boolean homologacja;

    Motocykl(String nazwa, double powierzchnia, boolean czyRozklada, double powierzchniaRozk, boolean homologacja) {
        super(nazwa, powierzchnia, czyRozklada, powierzchniaRozk);
        this.homologacja = homologacja;
    }

    Motocykl(String nazwa, double x, double y, double z, boolean czyRozklada, double rozx, double rozy, double rozz, boolean homologacja) {
        super(nazwa, x, y, z, czyRozklada, rozx, rozy, rozz);
        this.homologacja = homologacja;
    }

    @Override
    public String toString() {
        return "\nMotocykl\n" +
                super.toString()+
                "Homologacja " + homologacja +"\n";
    }
}
