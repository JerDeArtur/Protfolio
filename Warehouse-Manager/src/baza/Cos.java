package baza;

public abstract class Cos{
    String nazwa;
    double powierzchnia;
    private double powierzchniaZmienna;
    private boolean CzyRozklada = false, zlozony = true;
    private Pomieszczenie lokalizacja;

    Cos(String nazwa, double powierzchnia, boolean czyRozklada, double powierzchniaRozk)
    {
        this.nazwa = nazwa;
        this.powierzchnia = powierzchnia;
        this.powierzchniaZmienna = powierzchniaRozk;
        CzyRozklada = czyRozklada;
    }

    Cos(String nazwa, double x, double y, double z, boolean czyRozklada,double rozx, double rozy, double rozz) {
        this.nazwa=nazwa;
        powierzchnia=x*y*z;
        powierzchniaZmienna = rozx*rozy*rozz;
        CzyRozklada = czyRozklada;
    }

    void polozycDo(Pomieszczenie pomieszczenie) throws Exception{
        if((pomieszczenie.wolno-powierzchnia) < 0)
            throw new TooManyThingsException("Niema wolnego miejsca");
        else {
            pomieszczenie.zajetosc.add(this);
            pomieszczenie.wolno -= powierzchnia;
            lokalizacja = pomieszczenie;
        }
    }

    public void zmienicStan()throws Exception{
        if(CzyRozklada) {
            if (lokalizacja.wolno - powierzchniaZmienna + powierzchnia < lokalizacja.powierzchnia) {
                zlozony = !zlozony;
                Pomieszczenie tmp = this.lokalizacja;
                usunancCos();
                double tmpp;
                tmpp = this.powierzchnia;
                this.powierzchnia = powierzchniaZmienna;
                powierzchniaZmienna = tmpp;
                try {
                    polozycDo(tmp);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }else throw new TooManyThingsException("Nie mozna zmienic stan");
        }
        else throw new Exception("Nie rozklada sie");
    }

    void usunancCos(){
        lokalizacja.zajetosc.remove(this);
        lokalizacja.wolno += powierzchnia;
        lokalizacja = null;
    }

    @Override
    public String toString() {
        return "Nazwa " + nazwa + '\n' +
                "Powierzchnia " + powierzchnia +"\n"+
                "Czy rozklada " + CzyRozklada+'\n';
    }


}
