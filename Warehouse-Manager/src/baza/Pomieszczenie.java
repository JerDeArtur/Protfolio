package baza;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class Pomieszczenie{
    private int id;
    private static int counter = 0;
    double powierzchnia;
    double wolno;
    ArrayList<Cos> zajetosc = new ArrayList<>();
    boolean czyMozna = true;
    Osoba najemca;
    LocalDate rozpoczecie;
    int counter_dni;
    int dni;

    public Pomieszczenie(double powierzchnia) {
        this.id = counter++;
        this.powierzchnia = powierzchnia;
        wolno = powierzchnia;
    }

    public Pomieszczenie(double x,double y, double z) {
        this(x*y*z);
    }

    void przedawninie(){
        for(Cos cos : zajetosc) {
            boolean flag = true;
            for (Pomieszczenie pomieszczenie : najemca.wynajeto) {
                if(pomieszczenie != this) {
                    if((pomieszczenie.wolno-cos.powierzchnia) > 0 && flag) {
                        try {
                            cos.polozycDo(pomieszczenie);
                            flag=false;
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                }
            }
        }
        wolno = powierzchnia;
        zajetosc.clear();
    }

    public void getZajetosc() {
        System.out.println(toString()+"\n"+zajetosc);
    }

    @Override
    public String toString() {
        return "\nPomieszczenie numer "+id+"\nWolne miejsce " + wolno+'\n';
    }

}
