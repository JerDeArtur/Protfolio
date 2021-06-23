package baza;

import javax.swing.*;
import javax.swing.event.ListDataListener;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Scanner;

public class MyJListModel implements ListModel<String> {

    ArrayList<String> list = new ArrayList<>();

    MyJListModel(String path){
        Scanner fr = null;
        try {
            fr = new Scanner(new File(path));
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        while (fr.hasNext()){
            list.add(fr.nextLine());
        }
    }

    @Override
    public int getSize() {
        return list.size();
    }

    @Override
    public String getElementAt(int index) {
        return list.get(index);
    }

    @Override
    public void addListDataListener(ListDataListener l) {

    }

    @Override
    public void removeListDataListener(ListDataListener l) {

    }
}
