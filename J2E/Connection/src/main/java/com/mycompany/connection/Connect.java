/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.connection;

import com.rabbitmq.client.AMQP;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import com.rabbitmq.client.Consumer;
import com.rabbitmq.client.DefaultConsumer;
import com.rabbitmq.client.Envelope;
import java.io.IOException;
import java.util.ArrayList;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;


/**
 *
 * @author antoi
 */
@Stateless
@LocalBean
public class Connect {

    private final static String QUEUE_NAME_SEND = "result";
    private final static String QUEUE_NAME_RCV = "decrypt";
    public static ArrayList<String> QueueList = new ArrayList();
    public static boolean isReady = false;    
    public static boolean isDecrypted = false;
    public static Channel channel;
    public void send(String message)
    {
        try{
            System.out.println("debut de la transaction");
            ConnectionFactory factory = new ConnectionFactory();
            factory.setHost("localhost");
            Connection connectionSend = factory.newConnection();
            Channel channelSend = connectionSend.createChannel();
            channelSend.queueDeclare(QUEUE_NAME_SEND,false,false,false,null);
            channelSend.basicPublish("", QUEUE_NAME_SEND, null, message.getBytes());
            System.out.println(" [x] Sent '" + message + "'");
        }catch(Exception e){
           System.out.println("exception :"+ e);
        }
    }
    
    public void recv() {
        try {
            System.out.println("debut de l'écoute");
            ConnectionFactory factory = new ConnectionFactory();
            factory.setHost("localhost");
            System.out.println("Created connection");
            Connection connection = factory.newConnection();
            channel = connection.createChannel();

            channel.queueDeclare(QUEUE_NAME_RCV, false, false, false, null);
            System.out.println(" [*] Waiting for messages. To exit press CTRL+C");
            Consumer consumer = new DefaultConsumer(channel) {
                @Override
                public void handleDelivery(String consumerTag, Envelope envelope, AMQP.BasicProperties properties, byte[] body) throws IOException {
                    String message = new String(body, "UTF-8");
                    if(message.equals("Stop"))
                    {
                        System.out.println("PPPPPPPurgeee queue");
                        channel.queuePurge(QUEUE_NAME_RCV);
                        isDecrypted = true;
                    }
                    QueueList.add(message);
                    isReady = true;
                }
            };
            channel.basicConsume(QUEUE_NAME_RCV, true, consumer);
            
            while(!isDecrypted){}
        }catch(Exception e){
            System.out.println("exception :"+ e);
        }
    }
}
