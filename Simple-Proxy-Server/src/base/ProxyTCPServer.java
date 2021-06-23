package base;

import java.io.*;
import java.net.*;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ProxyTCPServer{
        static int counter = 0;
        //ExecutorService executor = Executors.newFixedThreadPool(50);
    public void listenSocket() {
        ServerSocket server = null;
        Socket client = null;
        try {
            server = new ServerSocket(3333);
        }
        catch (IOException e) {
            System.out.println("Could not listen");
            System.exit(-1);
        }
        System.out.println("Mapper listens on port: " + server.getLocalPort());

        while(true) {
            try {
                client = server.accept();
            }
            catch (IOException e) {
                System.out.println("Accept failed");
                System.exit(-1);
            }
            if (counter < 50)
                new Thread(new ProxyThread(client)).start();
        }

    }

    public static void main(String[] args) {
        ProxyTCPServer server = new ProxyTCPServer();
        server.listenSocket();
    }
}
