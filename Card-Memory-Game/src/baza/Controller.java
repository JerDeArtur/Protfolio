package baza;

import javax.swing.*;
import java.awt.*;
import java.time.LocalTime;
import java.util.ArrayList;

public class Controller {
    static MyThread sleep = new MyThread();

    MyTimer timer;

    static Card first = null;
    static Card second = null;
    private static int counter = 0;
    private int number;

    Model model = new Model();
    MyView view = new MyView(Controller.this);

    boolean check(Card card){
        if(first == null){
            first = card;
            card.flag = true;
        }else if(card != first){
            second=card;
            card.flag = true;
            if(first.getIcon() == second.getIcon()){
                first = null;
                second = null;
                counter++;
                if(counter == number){
                    timer.stop();
                    setScore();
                    counter = 0;
                }
                return true;
            }else {
                first.flag = false;
                second.flag = false;
                return false;
            }
        }
        return true;
    }

    void start(){
        view.panel.removeAll();
        view.startPanel();
    }

    void gameStart(){
        GridLayout gridLayout = new GridLayout(3,1);
        gridLayout.preferredLayoutSize(view.panel);
        gridLayout.setHgap(50);
        view.panel.setLayout(gridLayout);
        view.panel.removeAll();
        SwingUtilities.invokeLater(()-> {
            view.panel.add(new JLabel("Choose grid"));
            JComboBox<MyGrid> field = new JComboBox<>(model.getGrid());
            field.setPreferredSize(new Dimension(100, 20));
            view.panel.add(field);

            JButton button = new JButton("Choose");
            button.setPreferredSize(new Dimension(100, 20));
            button.addActionListener((event) -> {
                view.panel.removeAll();
                SwingUtilities.invokeLater(()->{
                    number = ((MyGrid)field.getSelectedItem()).x*((MyGrid)field.getSelectedItem()).y/2;
                    view.panel.removeAll();
                    view.drawComponents(model.makeCards(((MyGrid)field.getSelectedItem()).x*((MyGrid)field.getSelectedItem()).y/2),(MyGrid)field.getSelectedItem());
                });
            });

            view.panel.add(button);
            view.frame.pack();
            view.frame.repaint();
            view.frame.setLocationRelativeTo(null);
            view.frame.setVisible(true);
        });
    }

    void setScore(){
        view.panel.removeAll();
        SwingUtilities.invokeLater(()-> {
            GridLayout gridLayout = new GridLayout(1,3);
            gridLayout.setVgap(10);
            gridLayout.preferredLayoutSize(view.panel);

            JLabel player = new JLabel("Write name");

            JTextField field = new JTextField();
            field.setPreferredSize(new Dimension(100,20));

            JButton button = new JButton("Accept");
            button.setPreferredSize(new Dimension(100,30));
            button.addActionListener((e)->{
                model.addScore(new Record(field.getText(),timer.getTime(),view.grid));
                start();
            });

            view.panel.setLayout(gridLayout);
            view.panel.add(player);
            view.panel.add(field);
            view.panel.add(button);

            view.frame.pack();
            view.frame.repaint();
            view.frame.setLocationRelativeTo(null);
            view.frame.setVisible(true);
        });

    }


}
