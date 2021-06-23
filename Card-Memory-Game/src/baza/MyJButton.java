package baza;

import javax.swing.*;

public class MyJButton extends JButton {

    Card card;
    Controller controller;

    MyJButton(Card card,Controller controller){
        this.card = card;
        this.controller = controller;
        this.card.conteiner = this;
        addActionListener(e -> {
            if (!card.flag & Controller.sleep.flag) {
                setIcon(card.getIcon());
                if (!controller.check(card)){
                    Controller.sleep= new MyThread();
                    Controller.sleep.start();
                }
            }
        });
    }
}
