package baza;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

class Magazyn {

    ArrayList<Pomieszczenie> pomieszczenia = new ArrayList<>();

    void wolne(){
        System.out.println("Wolne pomieszczenia");
        for(Pomieszczenie a : pomieszczenia){
            if(a.najemca == null)
                System.out.println(a);
        }
    }

    void zapisz(){
        try {
            FileWriter fw = new FileWriter(new File("stanMagazynu.txt"));
            for (Pomieszczenie a: pomieszczenia) {
                fw.write(a.toString()+'\n');
                fw.write("Dane najemcy {"+(a.najemca == null ? "Wolne" : a.najemca.toString())+"}\n\n");
                fw.write("Zawartosc"+a.zajetosc.toString()+"\n\n\n");
            }
            fw.flush();
            fw.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
