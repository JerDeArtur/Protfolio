import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import java.io.FileWriter;
import java.io.IOException;


public class Main extends Application {

    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        Parent root = FXMLLoader.load(getClass().getResource("start.fxml"));
        Scene start = new Scene(root,600,400);
        primaryStage.setResizable(false);
        primaryStage.setScene(start);
        primaryStage.show();
    }

    static void addScore(String player, int eggs){
        try {
            FileWriter fw = new FileWriter("Z:\\GUI\\Project3\\src\\scores.txt",true);
            fw.write("Player: "+player+" Score: "+eggs+" eggs\n");
            fw.flush();
            fw.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
