/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.ejbconnection;

/**
 *
 * @author Cyril
 */
import javax.jms.ConnectionFactory;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.jms.listener.DefaultMessageListenerContainer;
import org.springframework.jms.listener.adapter.MessageListenerAdapter;

@Configuration
public class coJMS {

private static final Log log = LogFactory.getLog(coJMS.class);

@Bean
public DefaultMessageListenerContainer jmsListener(ConnectionFactory connectionFactory) {
DefaultMessageListenerContainer jmsListener = new DefaultMessageListenerContainer();
jmsListener.setConnectionFactory(connectionFactory);
jmsListener.setDestinationName("rabbit-trader-channel");
jmsListener.setPubSubDomain(true);

MessageListenerAdapter adapter = new MessageListenerAdapter(new Receiver());
adapter.setDefaultListenerMethod("receive");

jmsListener.setMessageListener(adapter);
return jmsListener;
}

protected static class Receiver {
public void receive(String message) {
log.info("Received " + message);
}
}
}