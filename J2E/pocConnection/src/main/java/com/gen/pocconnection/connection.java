/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.pocconnection;

import com.rabbitmq.client.AMQP;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import com.rabbitmq.client.Consumer;
import com.rabbitmq.client.DefaultConsumer;
import com.rabbitmq.client.Envelope;
import java.io.IOException;
import javax.ejb.Stateless;

/**
 *
 * @author Cyril
 */
@Stateless
public class connection {

    private final static String QUEUE_NAME_SEND = "result";
    private final static String QUEUE_NAME_RCV = "decrypt";
    public void send()
    {
        try{
        System.out.println("debut de la transaction");
        ConnectionFactory factory = new ConnectionFactory();
        factory.setHost("localhost");
        Connection connection = factory.newConnection();
        Channel channel = connection.createChannel();
        channel.queueDeclare(QUEUE_NAME_SEND,false,false,false,null);
        String message = "Hello World!";
        channel.basicPublish("", QUEUE_NAME_SEND, null, message.getBytes());
        System.out.println(" [x] Sent '" + message + "'");
        }catch(Exception e){
           System.out.println("exception :"+ e);
        }
    }
    public void receive(){
        final connection workerObject = new connection();
        Thread t = new Thread(){
            public void run(){
                workerObject.recv();
            }
        };
        t.start();
    }
    private void recv() {
        try {
            System.out.println("debut de l'écoute");
            ConnectionFactory factory = new ConnectionFactory();
            factory.setHost("localhost");
            Connection connection = factory.newConnection();
            Channel channel = connection.createChannel();

            channel.queueDeclare(QUEUE_NAME_RCV, false, false, false, null);
            System.out.println(" [*] Waiting for messages. To exit press CTRL+C");
            Consumer consumer = new DefaultConsumer(channel) {
                @Override
                public void handleDelivery(String consumerTag, Envelope envelope, AMQP.BasicProperties properties, byte[] body) throws IOException {
                    String message = new String(body, "UTF-8");
                    System.out.println(" [x] Received '" + message + "'");
                }
            };
            channel.basicConsume(QUEUE_NAME_RCV, true, consumer);
            System.in.read();
        }catch(Exception e){
            
        }
    }
}
