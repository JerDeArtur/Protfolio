import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.control.TextField;

import java.io.IOException;

public class Scores {
    @FXML
    private TextField field;

    public void button(ActionEvent event){
        Main.addScore(field.getText(),SecondController.counter2);
        System.out.println(field.getText());
        System.out.println(SecondController.counter2);
        try {
            ((Node)event.getSource()).getScene().setRoot(FXMLLoader.load(getClass().getResource("start.fxml")));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
