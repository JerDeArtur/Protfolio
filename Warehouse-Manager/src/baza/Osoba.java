package baza;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class Osoba {

    private String imie;
    private String nazwisko;
    private String PESEL;
    private String adres;
    private LocalDate data_urodzenia;
    private LocalDate pierwszy;
    ArrayList<Pomieszczenie> wynajeto = new ArrayList<>();

    Osoba(String imie, String nazwisko, String PESEL, String adres, LocalDate data_urodzenia) {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.PESEL = PESEL;
        this.adres = adres;
        this.data_urodzenia = data_urodzenia;
    }

    void wynajac(Pomieszczenie pomieszczenie, int dni) throws Exception{
        if(!pomieszczenie.czyMozna)
            throw new ZakazWynajmowania("Wynajecie niemozliwe");
        else {
            pomieszczenie.najemca = this;
            pomieszczenie.rozpoczecie = LocalDate.now();
            pomieszczenie.counter_dni = dni;
            pomieszczenie.dni = dni;
            pomieszczenie.czyMozna = false;
            wynajeto.add(pomieszczenie);
            if(pierwszy == null)
                pierwszy = pomieszczenie.rozpoczecie;
        }
    }

    private LocalDate getPierwszy() throws Exception{
        if(pierwszy == null){
            throw new NeverRentException("Nie ma takiej daty");
        }
        else{
            return pierwszy;}
    }

    @Override
    public String toString() {
        String a = "\nImie " + imie + '\n' +
                "Nazwisko " + nazwisko + '\n' +
                "PESEL " + PESEL + '\n' +
                "Adres " + adres + '\n' +
                "Data urodzenia " + data_urodzenia + '\n';
        try {
            a += "Pierwsze wynajecie " + getPierwszy() + '\n';
        } catch (Exception e) {
            a += ("Pierwsze wynajecie ????\n");
            System.err.println(e+": "+imie+" "+nazwisko);
        }
        a += "Wynajeto\n" + wynajeto;
        return a;
    }
}