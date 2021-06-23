import javafx.application.Application;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.text.TextAlignment;
import javafx.stage.Stage;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.nio.file.*;
import java.nio.file.attribute.BasicFileAttributes;
import java.util.*;

public class Main extends Application {

    public static void main(String[] args) {

        launch();
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        Path source = Paths.get(System.getProperty("user.dir")+"\\languages");
        ArrayList<Item> itemList = new ArrayList<>();
        HashSet<InputWag> wags = new HashSet<>();
        try {
            Files.walkFileTree(source, new FileVisitor<Path>() {
                @Override
                public FileVisitResult preVisitDirectory(Path dir, BasicFileAttributes attrs) {
                    return FileVisitResult.CONTINUE;
                }
                @Override
                public FileVisitResult visitFile(Path file, BasicFileAttributes attrs) throws IOException {
                    if (Files.isRegularFile(file)) {
                        try(BufferedReader in = new BufferedReader(new FileReader(file.toFile()))){
                            String tmp;
                            StringBuilder sb = new StringBuilder();
                            while((tmp=in.readLine())!=null)
                                sb.append(tmp);
                            String[] a = file.toFile().getParent().split("\\\\");
                            InputWag wag = new InputWag(a[a.length-1],1,0.1);
                            wags.add(wag);
                            itemList.add(new Item(a[a.length-1],sb.toString()));
                        }
                    }
                    return FileVisitResult.CONTINUE;
                }
                @Override
                public FileVisitResult visitFileFailed(Path file, IOException exc) {
                    return FileVisitResult.SKIP_SUBTREE;
                }
                @Override
                public FileVisitResult postVisitDirectory(Path dir, IOException exc) throws IOException {
                    if(Files.isSameFile(dir, source)){
                        return FileVisitResult.TERMINATE;
                    }
                    return FileVisitResult.CONTINUE;
                }
            });
        } catch (IOException e) {
            e.printStackTrace();
        }
        Collections.shuffle(itemList);
        Layer layer = new Layer(wags,itemList);

        Group group = new Group();

        TextArea text = new TextArea();
        text.setPrefSize(500,500);
        Label label = new Label("result");
        label.setWrapText(true);
        label.setPrefSize(300,50);
        label.setLayoutY(625);
        label.setLayoutX(100);
        label.setTextAlignment(TextAlignment.RIGHT);

        Button check = new Button("check");
        check.setOnAction((e)-> label.setText(layer.getResult(new Item("",text.getText()))));
        check.setPrefSize(300,50);
        check.setLayoutY(525);
        check.setLayoutX(100);

        group.getChildren().addAll(check,text,label);

        Scene scene = new Scene(group,500,700);
        primaryStage.setScene(scene);
        primaryStage.show();
    }
}
