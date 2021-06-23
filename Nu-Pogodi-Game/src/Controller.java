import javafx.event.ActionEvent;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import java.io.IOException;

public class Controller {

    public void scores(ActionEvent event){

    }

    public void start(ActionEvent event) {
        try {
            ((Node)event.getSource()).getScene().setRoot(FXMLLoader.load(getClass().getResource("game.fxml")));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void exit(){
        System.exit(0);
    }

}
