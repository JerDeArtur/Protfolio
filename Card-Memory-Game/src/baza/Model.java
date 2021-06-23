package baza;

import javax.swing.*;
import java.awt.*;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;

public class Model {



    private ArrayList<ImageIcon> icons = new ArrayList<>();
    private ImageIcon back;
    String scores = "Z:\\GUI\\Project2\\src\\baza\\Scores.dane";

    Model(){
        back=new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\TrollFace.jpg").getImage().getScaledInstance(100,100,Image.SCALE_SMOOTH));
        icons.add(new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\a4def-1518655532-800.jpg").getImage().getScaledInstance(100,100, Image.SCALE_SMOOTH)));
        icons.add(new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\WWE-news-salaries-how-much-wrestlers-get-paid-John-Cena-Undertaker-695494.jpg").getImage().getScaledInstance(100,100, Image.SCALE_SMOOTH)));
        icons.add(new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\Mexicos-dwarf-wrestlers.jpg").getImage().getScaledInstance(100,100, Image.SCALE_SMOOTH)));
        icons.add(new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\dwayne-the-rock-johnson-looks-on-during-his-match-against-news-photo-142809003-1553006862.jpg").getImage().getScaledInstance(100,100, Image.SCALE_SMOOTH)));
        icons.add(new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\Новый точечный рисунок1.jpg").getImage().getScaledInstance(100,100, Image.SCALE_SMOOTH)));
        icons.add(new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\Новый точечный рисунок.jpg").getImage().getScaledInstance(100,100, Image.SCALE_SMOOTH)));
        icons.add(new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\photo_2019-05-22_21-28-50.jpg").getImage().getScaledInstance(100,100, Image.SCALE_SMOOTH)));
        icons.add(new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\photo_2019-05-22_21-28-38.jpg").getImage().getScaledInstance(100,100, Image.SCALE_SMOOTH)));
    }

    ArrayList<ImageIcon> getIcons() {
        return icons;
    }

    ImageIcon getBack() {
        return back;
    }

    ArrayList<Card> drawCards(int amount){
        ArrayList<Card> tmp = new ArrayList<>();
        for(int i = 0;i < amount && i < icons.size();i++){
            tmp.add(new Card(icons.get(i),back));
            tmp.add(new Card(icons.get(i),back));
        }
        return tmp;
    }

    ArrayList<Card> shufle(ArrayList<Card> cards){
        Card tmp;
        int first;
        int second;
        for(int i = 0; i < 50; i++){
            first =(int) (Math.random()*(cards.size()));
            second =(int) (Math.random()*(cards.size()));
            tmp = cards.get(first);
            cards.set(first,cards.get(second));
            cards.set(second,tmp);
        }
        return cards;
    }

    ArrayList<Card> makeCards(int amount){
        return shufle(drawCards(amount));
    }

    void addScore(Record record){
        try {
            FileWriter fw = new FileWriter(scores,true);
            fw.write(record.toString());
            fw.flush();
            fw.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public int getMaxGrid(){
        return (int) Math.sqrt(icons.size());
    }

    MyGrid[] getGrid(){
        MyGrid[] tmp = {new MyGrid(2,2),
                new MyGrid(2,3),
                new MyGrid(2,4),
                new MyGrid(2,5),
                new MyGrid(3,4),
                new MyGrid(2,7),
                new MyGrid(4,4)};
        return tmp;
    }

}
