package baza;

public class Rower extends Cos {

    private int przezutki;
    private String tymHamolcow;
    private boolean amortzacja;
    private int liczbaAmor;

    Rower(String nazwa, double powierzchnia, boolean czyRozklada, double powierzchniaRozk, int przezutki, String tymHamolcow, boolean amortzacja, int liczbaAmor) {
        super(nazwa, powierzchnia, czyRozklada, powierzchniaRozk);
        this.przezutki = przezutki;
        this.tymHamolcow = tymHamolcow;
        this.amortzacja = amortzacja;
        this.liczbaAmor = liczbaAmor;
    }

    Rower(String nazwa, double x, double y, double z, boolean czyRozklada, double rozx, double rozy, double rozz, int przezutki, String tymHamolcow, boolean amortzacja, int liczbaAmor) {
        super(nazwa, x, y, z, czyRozklada, rozx, rozy, rozz);
        this.przezutki = przezutki;
        this.tymHamolcow = tymHamolcow;
        this.amortzacja = amortzacja;
        this.liczbaAmor = liczbaAmor;
    }

    @Override
    public String toString() {
        return "\nRower" + "\n"+
                super.toString()+
                "przezutki " + przezutki +"\n"+
                "Typ hamolcow " + tymHamolcow + '\n' +
                "Amortzacja " + amortzacja +"\n"+
                "LiczbaAmortyzatorow " + liczbaAmor +"\n";
    }
}
