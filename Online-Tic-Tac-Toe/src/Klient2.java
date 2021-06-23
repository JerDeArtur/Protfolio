import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;

public class Klient2 {
    public static void main(String args[]) {
        Socket socket = null;
        PrintWriter out = null;
        BufferedReader in = null;
        int port = 44444;
        try {
            socket = new Socket("127.0.0.1", port);
            out = new PrintWriter(socket.getOutputStream(), true);
            in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        }
        catch (UnknownHostException e) {
            System.out.println("Unknown host");
            System.exit(-1);
        }
        catch  (IOException e) {
            System.out.println("No I/O");
            System.exit(-1);
        }

        Scanner scanner = new Scanner(System.in);
        try {
            String tmp = scanner.nextLine();
            while(!tmp.equals("0")) {
                out.println(scanner.nextLine());
                String line;
                while ((line = in.readLine()) != null && !line.isEmpty()) {
                    System.out.println(line);
                }
            }
        } catch (IOException e) {
            System.out.println("Error during communication");
            System.exit(-1);
        }

        try {
            socket.close();
        }
        catch (IOException e) {
            System.out.println("Cannot close the socket");
            System.exit(-1);
        }

    }
}
