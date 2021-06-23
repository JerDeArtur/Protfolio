package baza;

import java.util.*;

public class Main{

    public static void main(String[] args){
        Console_Interface com = new Console_Interface();
        Scanner g = new Scanner(System.in);
        while(true){
            System.out.println("0-wyjscie/1-obranie osoby/2-wypisac dane osoby/3-wolne pomieszczenia/4-wynajac pomieszczenie/" +
                    "5-wybrac wynajete pomiszczenie\n6-wypisac zawartosc pomiszczenia/7-polozyc cos/8-usunanc cos/9-zapisac stan magazynu do pliku");
            try {
                com.DoCommand(g.nextInt());
            } catch (Exception e) {
                e.printStackTrace();
            }
            System.err.flush();
        }
    }


}
