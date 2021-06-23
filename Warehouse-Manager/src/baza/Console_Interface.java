package baza;

import java.time.LocalDate;
import java.util.*;

public class Console_Interface implements Command {

    private Map<Integer,Command> commandList = new HashMap<>();
    private static Magazyn magazyn = new Magazyn();
    private ArrayList<Osoba> osoby = new ArrayList<>();
    private static Osoba current;
    private static Pomieszczenie tmp;
    private Scanner g = new Scanner(System.in);

    Console_Interface(){
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(7,3,4));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(3,8,2));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(4,3,1));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(50));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(39));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(3,3,8));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(25,2,2));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(15,3,2));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(80));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(15));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(26));
        Console_Interface.magazyn.pomieszczenia.add(new Pomieszczenie(4,8,3));
        osoby.add(new Osoba("John","Cena","9999","Heaven", LocalDate.of(1111,11,11)));
        osoby.add(new Osoba("The","Undertaker","1111","Hell",LocalDate.of(2222,2,22)));
        osoby.add(new Osoba("Hulk","Hogan","6666","Earth", LocalDate.of(3333,3,3)));
        osoby.add(new Osoba("Randy","Orton","7777","USA ***",LocalDate.of(4444,4,4)));
        osoby.add(new Osoba("The","Rock","9999","WWE", LocalDate.of(5555,5,5)));
        osoby.add(new Osoba("Rej","Misterio","6969","Bujaka bujaka",LocalDate.of(6666,6,6)));
        commandList.put(0, System::exit);
        commandList.put(1,(a) ->{
            System.out.println(wypisacList(osoby));
            System.out.println("\nWybierz osobe");
            Console_Interface.current = osoby.get(g.nextInt()-1);
        });
        commandList.put(2,(a) ->{
            if(Console_Interface.current != null)
                System.out.println(Console_Interface.current);
            else throw new Exception("Nie wybrales osoby");
        });
        commandList.put(3,(a) ->{
            Console_Interface.magazyn.wolne();
        });
        commandList.put(4,(a) ->{
            if(Console_Interface.current != null) {
                System.out.println("Wybierz pomiszczenie");
                int b = g.nextInt();
                System.out.println("Wpisz dlugosc wynajecia");
                Console_Interface.current.wynajac(magazyn.pomieszczenia.get(b - 1), g.nextInt());
            }
            else throw new Exception("Nie wybrales osoby");
        });
        commandList.put(5,(a) ->{
            if(Console_Interface.current != null) {
                System.out.println(wypisacList(current.wynajeto));
                System.out.println("Wybierz pomieszczenie");
                Console_Interface.tmp = Console_Interface.current.wynajeto.get(g.nextInt() - 1);
            }
            else throw new Exception("Nie wybrales osoby");
        });
        commandList.put(6,(a) ->{
            if(Console_Interface.tmp != null)
            System.out.println(wypisacList(Console_Interface.tmp.zajetosc));
            else throw new Exception("Nie wybrales pomiszczenia");
        });
        commandList.put(7,(a) ->{
            if(Console_Interface.tmp != null) {
                System.out.println("Co chces dodac\n0-Przedmiot\n1-Samochod\n2-Motocykl\n3-Rower");
                int b = g.nextInt();
                System.out.println("Jak bedziesz wpisywac rozwiar\n1-objetosc\n2-x,y,z");
                int gg = g.nextInt();
                switch (gg) {
                    case 1:
                        switch (b) {
                            case 0:
                                System.out.println("Wpisz nazwe, rozmiar oraz czy rozklada + rozmiar rozlozony (gdy nie rozklada wpisz co chces)");
                                new Przedmiot(g.next(), g.nextDouble(), g.nextBoolean(), g.nextDouble()).polozycDo(tmp);
                                break;
                            case 1:
                                System.out.println("Wpisz nazwe, rozmiar, czy rozklada + rozmiar rozlozony (gdy nie rozklada wpisz co chces), pojemosc silnika i typ");
                                new Samochod(g.next(), g.nextDouble(), g.nextBoolean(), g.nextDouble(), g.nextInt(), g.next()).polozycDo(tmp);
                                break;
                            case 2:
                                System.out.println("Wpisz nazwe, rozmiar, czy rozklada + rozmiar rozlozony (gdy nie rozklada wpisz co chces), czy jest homologacja");
                                new Motocykl(g.next(), g.nextDouble(), g.nextBoolean(), g.nextDouble(), g.nextBoolean()).polozycDo(tmp);
                                break;
                            case 3:
                                System.out.println("Wpisz nazwe, rozmiar, czy rozklada + rozmiar rozlozony (gdy nie rozklada wpisz co chces), ilosc przerzutek, typ hamolcow, czy jest amortyzacja, ilosc amortyzatorow");
                                new Rower(g.next(), g.nextDouble(), g.nextBoolean(), g.nextDouble(), g.nextInt(), g.next(), g.nextBoolean(), g.nextInt()).polozycDo(tmp);
                                break;
                        }
                        break;
                    case 2:
                        switch (b) {
                            case 0:
                                System.out.println("Wpisz nazwe, rozmiar oraz czy rozklada + rozmiar rozlozony (gdy nie rozklada wpisz co chces)");
                                new Przedmiot(g.next(), g.nextInt(), g.nextInt(), g.nextInt(), g.nextBoolean(), g.nextInt(), g.nextInt(), g.nextInt()).polozycDo(tmp);
                                break;
                            case 1:
                                System.out.println("Wpisz nazwe, rozmiar, czy rozklada + rozmiar rozlozony (gdy nie rozklada wpisz co chces), pojemosc silnika i typ");
                                new Samochod(g.next(), g.nextInt(), g.nextInt(), g.nextInt(), g.nextBoolean(), g.nextInt(), g.nextInt(), g.nextInt(), g.nextInt(), g.next()).polozycDo(tmp);
                                break;
                            case 2:
                                System.out.println("Wpisz nazwe, rozmiar, czy rozklada + rozmiar rozlozony (gdy nie rozklada wpisz co chces), czy jest homologacja");
                                new Motocykl(g.next(), g.nextInt(), g.nextInt(), g.nextInt(), g.nextBoolean(), g.nextInt(), g.nextInt(), g.nextInt(), g.nextBoolean()).polozycDo(tmp);
                                break;
                            case 3:
                                System.out.println("Wpisz nazwe, rozmiar, czy rozklada + rozmiar rozlozony (gdy nie rozklada wpisz co chces), ilosc przerzutek, typ hamolcow, czy jest amortyzacja, ilosc amortyzatorow");
                                new Rower(g.next(), g.nextInt(), g.nextInt(), g.nextInt(), g.nextBoolean(), g.nextInt(), g.nextInt(), g.nextInt(), g.nextInt(), g.next(), g.nextBoolean(), g.nextInt()).polozycDo(tmp);
                                break;
                        }
                        break;
                }
            }
            else throw new Exception("Nie wybrales pomieszczenia");
        });
        commandList.put(8,(a) ->{
            if(Console_Interface.tmp != null) {
                System.out.println(wypisacList(tmp.zajetosc));
                System.out.println("Co chcesz usunanc?");
                int c = g.nextInt();
                Console_Interface.tmp.zajetosc.get(c - 1).usunancCos();
            }
            else throw new Exception("Nie wybrales pomiszczenia");
        });
        commandList.put(9,(a) ->{
            Console_Interface.magazyn.zapisz();
        });
    }

    private String wypisacList(ArrayList arr) {
        StringBuilder wynik = new StringBuilder();
        int counter = 1;
        for (Object o : arr) {
            wynik.append('\n').append(counter++).append(" ").append(o.toString()).append('\n');
        }
        return wynik.toString();
    }

    public void timeSkip(int dni){
        for(Osoba osoba : osoby){
            for(Pomieszczenie pomieszczenie : osoba.wynajeto){
                pomieszczenie.counter_dni -= dni;
                if(pomieszczenie.counter_dni <= 0){
                    pomieszczenie.przedawninie();
                    pomieszczenie.najemca = null;
                    pomieszczenie.czyMozna = true;
                }
            }
        }
    }

    @Override
    public void DoCommand(int a) throws Exception{
        commandList.get(a).DoCommand(a);
    }
}
