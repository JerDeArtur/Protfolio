package baza;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class  Card extends JButton{

    private ImageIcon icon;
    private ImageIcon back;
    boolean flag = false;
    Object conteiner;

    Card(ImageIcon icon, ImageIcon back) {
        this.icon = icon;
        this.back = back;
    }

    public ImageIcon getIcon() {
        return icon;
    }

    public ImageIcon getBack() {
        return back;
    }

    @Override
    public String toString() {
        return "Card{" +
                "icon=" + icon +
                ", back=" + back +
                '}'+'\n';
    }
}
